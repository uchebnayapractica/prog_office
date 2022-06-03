using Office_1.DataLayer.Models;

namespace Office_1.DataLayer.Services;

public class SettingsService
{

    public static Settings GetSettings()
    {
        using var context = new ApplicationContext();

        if (context.Settings.Any())
        {
            return context.Settings.First();
        }

        var settings = new Settings
        {
            ExportPath = string.Empty,
            ImportPath = string.Empty
        };
        
        context.Settings.Add(settings);
        context.SaveChanges();

        return settings;
    }

    public static void SaveSettings(Settings settings)
    {
        using var context = new ApplicationContext();

        if (!settings.ExportPath.EndsWith('/'))
        {
            settings.ExportPath += '/';
        }
        
        if (!settings.ImportPath.EndsWith('/'))
        {
            settings.ImportPath += '/';
        }

        context.Settings.Update(settings);
        context.SaveChanges();
    }

}