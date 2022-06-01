using Office_1.UI.Commands;
using System.Windows;
using System.Windows.Input;
using Office_1.DataLayer.Models;
using Office_1.DataLayer.Services;


namespace Office_1.UI.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private Visibility _isToolTipOn;
        private Visibility _filtersVisibility;
        private Visibility _showNewRequestGridButtonVisibility;
        private Visibility _addNewRequestVisibility;


        public MainWindowViewModel()
        {
            AllRequests = new AllRequestsViewModel();
            Clients = new ClientsViewModel();
            NewRequest = new NewRequestViewModel();
            MakeGridVisible = new ChangeVisibleGridCommand(this);
            IsToolTipOn = Visibility.Visible;
            ShowNewRequestGridButtonVisibility = Visibility.Visible;
            AddNewRequestVisibility = Visibility.Hidden;
            FiltersVisibility = Visibility.Visible;

            VisibleVM = AllRequests;
        }

        public ICommand MakeGridVisible { get; set; }

        public Visibility IsToolTipOn
        {
            get => _isToolTipOn;
            set
            {
                if (value != _isToolTipOn)
                {
                    _isToolTipOn = value;

                    OnPropertyChanged(nameof(IsToolTipOn));
                }
            }
        }
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
        public Visibility ShowNewRequestGridButtonVisibility
        {
            get => _showNewRequestGridButtonVisibility;
            set
            {
                if (value != _showNewRequestGridButtonVisibility)
                {
                    _showNewRequestGridButtonVisibility = value;

                    OnPropertyChanged(nameof(ShowNewRequestGridButtonVisibility));
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

        public TabViewModel VisibleVM { get; set; }
        public NewRequestViewModel NewRequest { get; set; }
        public AllRequestsViewModel AllRequests { get; set; }
        public ClientsViewModel Clients { get; set; }
    }
}
