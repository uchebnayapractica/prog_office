using Office_1.DataLayer;
using Office_1.UI.ViewModels;
using System.Windows;

namespace Office_1.UI.Commands
{
    public class PrintNewRequestsToFilesCommand : CommandBase
    {
        private MainWindowViewModel _mainWindowViewModel;

        public PrintNewRequestsToFilesCommand(MainWindowViewModel vm)
        {
            _mainWindowViewModel = vm;
        }

        public override void Execute(object parameter)
        {
            RequestImportExportManager.ExportCreatedRequests();
            _mainWindowViewModel.AllRequests.GetRequestsCommand.Execute(null);
            MessageBox.Show("Успешно напечатаны в файлы новые заявки!");

        }
    }
}
