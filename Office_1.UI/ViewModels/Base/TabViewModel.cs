using Office_1.DataLayer.Models;
using Office_1.UI.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Office_1.UI.ViewModels
{
    public abstract class TabViewModel : BaseViewModel
    {
        private Visibility _visibility;

        private Client _client;

        private string _clientName;

        private string _clientAddress;

        public TabViewModel()
        {
            Clients = new ObservableCollection<Client>();
            GetClientsCommand = new GetClientsCommand(this);
            GetClientsByPrefixOfNameCommand = new GetClientsByPrefixOfNameCommand(this);
            GetClientsCommand.Execute(null);
        }

        public Visibility GridVisibility
        {
            get => _visibility;
            set
            {
                if (value != _visibility)
                {
                    _visibility = value;
                    OnPropertyChanged(nameof(GridVisibility));
                }
            }
        }

        public Client Client
        {
            get => _client;
            set
            {
                if (value != _client)
                {
                    _client = value;
                    OnPropertyChanged(nameof(Client));
                }
            }
        }

        public string ClientName
        {
            get => _clientName;
            set
            {
                if (value != _clientName)
                {
                    _clientName = value;
                    OnPropertyChanged(nameof(ClientName));
                    if (value != string.Empty)
                        GetClientsByPrefixOfNameCommand.Execute(null);
                    else GetClientsCommand.Execute(null);
                }
            }
        }

        public string ClientAddress
        {
            get => _clientAddress;
            set
            {
                if (value != _clientAddress)
                {
                    _clientAddress = value;
                    OnPropertyChanged(nameof(ClientAddress));
                }
            }
        }

        public ObservableCollection<Client> Clients { get; set; }

        public ICommand GetClientsCommand { get; set; }

        public ICommand GetClientsByPrefixOfNameCommand { get; set; }
    }
}
