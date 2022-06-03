using Office_1.UI.ViewModels;


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

        }
    }
}
