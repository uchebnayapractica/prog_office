using Office_1.DataLayer.Models;
using Office_1.UI.ViewModels;
using System.Windows;

namespace Office_1.UI.Commands
{
    public class ChooseClientCommand : CommandBase
    {
        private readonly NewRequestViewModel _requestsViewModel;

        public ChooseClientCommand(NewRequestViewModel rvm)
        {
            _requestsViewModel = rvm;
        }

        public override void Execute(object client)
        {
            if (_requestsViewModel.SelectedItem != null)
            {
                Client ChosenClient = _requestsViewModel.SelectedItem;

                _requestsViewModel.Client = ChosenClient;
                _requestsViewModel.ClientName = ChosenClient.Name;
                _requestsViewModel.ClientAddress = ChosenClient.Address;
            } else
            {
                MessageBox.Show("Для начала выберите нужного клиента в таблице, кликнув на строчку с ним!");
            }
        }
    }
}
