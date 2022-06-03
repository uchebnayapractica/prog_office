using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Office_1.DataLayer;
using Office_1.DataLayer.Models;
using Office_1.DataLayer.Services;

namespace Office_1.Tests;

public class RequestImportExportManagerTests
{

    [SetUp]
    public void SetUp()
    {
        using (var db = new ApplicationContext())
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            db.Database.Migrate();
        }

        SetSettings();
    }

    private void SetSettings()
    {
        var s = SettingsService.GetSettings();
        s.ExportPath = "/Users/noliktop/Desktop/requests/export";
        s.ImportPath = "/Users/noliktop/Desktop/requests/import";
        
        SettingsService.SaveSettings(s);
    }

    [Test]
    public void TestExport()
    {
        RequestTests.MakeSomeRequest(Status.Created, "Иван", "улица Пушкина");
        RequestTests.MakeSomeRequest(Status.Created, "Иван 2", "улица Колотушкина");

        var files = RequestImportExportManager.ExportCreatedRequests();
        Console.WriteLine("Exported files: " + string.Join(", ", files));
        
        Assert.AreEqual(2, files.Count);

        var updRequests = RequestService.GetAllRequests();
        Assert.AreEqual(2, updRequests.Count);

        var first = updRequests[0];
        var second = updRequests[1];
        
        Assert.AreEqual(Status.InReview, first.Status);
        Assert.AreEqual(Status.InReview, second.Status);
    }
    
}