using Office_1.UI.ViewModels;
using System.Windows;


namespace Office_1.UI.Commands
{
    internal class PrintNewRequestsToFilesCommand : CommandBase
    {
        private MainWindowViewModel _mainWindowViewModel;

        public PrintNewRequestsToFilesCommand(MainWindowViewModel vm)
        {
            _mainWindowViewModel = vm;
        }

        public override void Execute(object parameter)
        {

        }
    }
}
