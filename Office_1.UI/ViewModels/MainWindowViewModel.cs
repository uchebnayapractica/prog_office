using Office_1.UI.Commands;
using System.Windows;
using System.Windows.Input;


namespace Office_1.UI.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _inputPath;
        private string _outputPath;

        public MainWindowViewModel()
        {
            AllRequests = new AllRequestsViewModel();
            Clients = new ClientsViewModel();
            NewRequest = new NewRequestViewModel();
            ChangeVisibleGridCommand = new ChangeVisibleGridCommand(this);
            AddRequestCommand = new AddRequestCommand(NewRequest, this);
            PrintNewRequestsToFilesCommand = PrintNewRequestsToFilesCommand(this);
            GetNewRequestsFromFilesCommand = GetNewRequestsFromFilesCommand(this);

            VisibleVM = AllRequests;
        }

        public ICommand ChangeVisibleGridCommand { get; set; }
        public ICommand AddRequestCommand { get; set; }

        //print copy rules
        public ICommand PrintNewRequestsToFilesCommand { get; set; }
        public ICommand GetNewRequestsFromFilesCommand { get; set; }

        public string InputPath
        {
            get => _inputPath;
            set
            {
                if (value != _inputPath)
                {
                    _inputPath = value;
                    OnPropertyChanged(nameof(InputPath));
                    //ChangeInputPath in db
                }
            }
        }

        public string OutputPath
        {
            get => _outputPath;
            set
            {
                if (value != _outputPath)
                {
                    _outputPath = value;
                    OnPropertyChanged(nameof(OutputPath));
                    //ChangeOutputPath in db
                }
            }
        }

        public TabViewModel VisibleVM { get; set; }
        public NewRequestViewModel NewRequest { get; set; }
        public AllRequestsViewModel AllRequests { get; set; }
        public ClientsViewModel Clients { get; set; }
    }
}
