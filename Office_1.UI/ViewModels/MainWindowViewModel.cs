using Office_1.UI.Commands;
using System.Windows;
using System.Windows.Input;


namespace Office_1.UI.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {

        public MainWindowViewModel()
        {
            AllRequests = new AllRequestsViewModel();
            Clients = new ClientsViewModel();
            NewRequest = new NewRequestViewModel();
            ChangeVisibleGridCommand = new ChangeVisibleGridCommand(this);
            AddRequestCommand = new AddRequestCommand(NewRequest, this);

            VisibleVM = AllRequests;
        }

        public ICommand ChangeVisibleGridCommand { get; set; }
        public ICommand AddRequestCommand { get; set; }


        public TabViewModel VisibleVM { get; set; }
        public NewRequestViewModel NewRequest { get; set; }
        public AllRequestsViewModel AllRequests { get; set; }
        public ClientsViewModel Clients { get; set; }
    }
}
