using Office_1.UI.ViewModels;
using System.Windows;


namespace Office_1.UI.Commands
{
    internal class GetNewRequestsFromFilesCommand : CommandBase
    {
        private MainWindowViewModel _mainWindowViewModel;

        public GetNewRequestsFromFilesCommand(MainWindowViewModel vm)
        {
            _mainWindowViewModel = vm;
        }

        public override void Execute(object parameter)
        {
    

        }
    }
}
