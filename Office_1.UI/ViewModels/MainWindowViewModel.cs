using Office_1.UI.Commands;
using System.Windows;
using System.Windows.Input;


namespace Office_1.UI.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private Visibility _filtersVisibility;
        private Visibility _changeVisibleGridVisibility;
        private Visibility _addNewRequestVisibility;
        private Visibility _printNewVisibility;

        public MainWindowViewModel()
        {
            AllRequests = new AllRequestsViewModel();
            Clients = new ClientsViewModel();
            NewRequest = new NewRequestViewModel();
            ChangeVisibleGridCommand = new ChangeVisibleGridCommand(this);
            AddRequestCommand = new AddRequestCommand(NewRequest, this);
            ChangeVisibleGridVisibility = Visibility.Visible;
            AddNewRequestVisibility = Visibility.Hidden;
            FiltersVisibility = Visibility.Visible;

            VisibleVM = AllRequests;
        }

        public ICommand ChangeVisibleGridCommand { get; set; }
        public ICommand AddRequestCommand { get; set; }


        public Visibility FiltersVisibility
        {
            get => _filtersVisibility;
            set
            {
                if (value != _filtersVisibility)
                {
                    _filtersVisibility = value;

                    OnPropertyChanged(nameof(FiltersVisibility));
                }
            }
        }
        public Visibility ChangeVisibleGridVisibility
        {
            get => _changeVisibleGridVisibility;
            set
            {
                if (value != _changeVisibleGridVisibility)
                {
                    _changeVisibleGridVisibility = value;

                    OnPropertyChanged(nameof(ChangeVisibleGridVisibility));
                }
            }
        }
        public Visibility AddNewRequestVisibility
        {
            get => _addNewRequestVisibility;
            set
            {
                if (value != _addNewRequestVisibility)
                {
                    _addNewRequestVisibility = value;

                    OnPropertyChanged(nameof(AddNewRequestVisibility));
                }
            }
        }
        public Visibility PrintNewVisibility
        {
            get => _printNewVisibility;
            set
            {
                if (value != _printNewVisibility)
                {
                    _printNewVisibility = value;

                    OnPropertyChanged(nameof(PrintNewVisibility));
                }
            }
        }

        public TabViewModel VisibleVM { get; set; }
        public NewRequestViewModel NewRequest { get; set; }
        public AllRequestsViewModel AllRequests { get; set; }
        public ClientsViewModel Clients { get; set; }
    }
}
