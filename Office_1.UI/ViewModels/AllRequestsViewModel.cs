using Office_1.BusinessLayer.Models;
using Office_1.BusinessLayer.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;


namespace Office_1.UI.ViewModels
{
    public class AllRequestsViewModel : TabViewModel
    {
        private bool _showNew;
        private bool _showInProgress;
        private bool _showReviewed;
        private bool _showCanceled;

        private bool _showCanceledAvailability;
        private bool _showActiveAvailability;
        private bool _areButtonsAvailable;

        private Visibility _isToolTipOn;

        private RequestModel _selectedItem;
        public AllRequestsViewModel()
        {
            GridVisibility = Visibility.Hidden;
            ShowActiveAvailability = true;
            ShowCanceledAvailability = true;
            Service = new RequestService();
            Requests = new ObservableCollection<RequestModel>();
            IsToolTipOn = Visibility.Visible;

            GetOrdersCommand = new GetOrdersCommand(this);
            CheckIfShouldOpenAddingPaymentGrid = new CheckIfShouldOpenAddingPaymentGrid(Payment, this);
            CancelOrderCommand = new CancelOrderCommand(this);

            ShowNew = true;
            ShowInProgress = true;
        }
        public ObservableCollection<RequestModel> Requests { get; set; }

        public bool ShowNew
        {
            get => _showNew;
            set
            {
                if (value != _showNew)
                {
                    _showNew = value;
                    OnPropertyChanged(nameof(ShowNew));
                    GetOrdersCommand.Execute(null);
                }
            }
        }

        public bool ShowInProgress
        {
            get => _showInProgress;
            set
            {
                if (value != _showInProgress)
                {
                    _showInProgress = value;
                    OnPropertyChanged(nameof(ShowInProgress));
                    GetOrdersCommand.Execute(null);
                }
            }
        }

        public bool ShowReviewed
        {
            get => _showReviewed;
            set
            {
                if (value != _showReviewed)
                {
                    _showReviewed = value;
                    if (value == true) ShowActiveAvailability = false;
                    else ShowActiveAvailability = true;
                    OnPropertyChanged(nameof(GridVisibility));
                    GetOrdersCommand.Execute(null);
                }
            }
        }

        public bool ShowCanceled
        {
            get => _showCanceled;
            set
            {
                if (value != _showCanceled)
                {
                    _showCanceled = value;
                    if (value == true) ShowCanceledAvailability = false;
                    else ShowCanceledAvailability = true;
                    OnPropertyChanged(nameof(ShowCanceled));
                }
            }
        }

        public bool ShowCanceledAvailability
        {
            get => _showCanceledAvailability;
            set
            {
                if (value != _showCanceledAvailability)
                {
                    _showCanceledAvailability = value;
                    OnPropertyChanged(nameof(ShowCanceledAvailability));
                }
            }
        }

        public bool ShowActiveAvailability
        {
            get => _showActiveAvailability;
            set
            {
                if (value != _showActiveAvailability)
                {
                    _showActiveAvailability = value;
                    OnPropertyChanged(nameof(ShowActiveAvailability));
                }
            }
        }

        public bool AreButtonsAvailable
        {
            get => _areButtonsAvailable;
            set
            {
                if (value != _areButtonsAvailable)
                {
                    _areButtonsAvailable = value;
                    OnPropertyChanged(nameof(AreButtonsAvailable));
                }
            }
        }

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

        public RequestModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value != _selectedItem)
                {
                    _selectedItem = value;

                    OnPropertyChanged(nameof(SelectedItem));
                    if (value != null)
                    {
                        AreButtonsAvailable = true;
                        IsToolTipOn = Visibility.Collapsed;
                    }
                    else
                    {
                        AreButtonsAvailable = false;
                        IsToolTipOn = Visibility.Visible;
                    }
                }
            }
        }

        public ICommand GetOrdersCommand { get; set; }

        public ICommand AddPaymentCommand { get; set; }

        public ICommand CheckIfShouldOpenAddingPaymentGrid { get; set; }

        public ICommand CancelOrderCommand { get; set; }

        public RequestService Service;
    }
}
