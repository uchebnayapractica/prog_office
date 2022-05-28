using Office_1.UI.Commands;
using System.Windows.Input;

namespace Office_1.UI.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            AllRequests = new AllRequestsViewModel();
            Clients = new ClientsViewModel();
            NewRequest = new NewRequestViewModel();
            MakeGridVisible = new ChangeVisibleGridCommand(this);

            VisibleVM = AllRequests;
        }

        public ICommand MakeGridVisible { get; set; }

        public TabViewModel VisibleVM { get; set; }
        public NewRequestViewModel NewRequest { get; set; }
        public AllRequestsViewModel AllRequests { get; set; }
        public ClientsViewModel Clients { get; set; }
    }
}
