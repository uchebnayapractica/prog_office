using Office_1.DataLayer.Models;
using Office_1.DataLayer.Services;
using Office_1.UI.ViewModels;
using System.Windows;

namespace Office_1.UI.Commands
{
    public class AddRequestCommand : CommandBase
    {
        private readonly NewRequestViewModel _requestsViewModel;
        private readonly MainWindowViewModel _mainWindowViewModel;

        public AddRequestCommand(NewRequestViewModel rvm, MainWindowViewModel mvm)
        {
            _requestsViewModel = rvm;
            _mainWindowViewModel = mvm;
        }

        public override void Execute(object viewModel)
        {
            TabViewModel vm = (TabViewModel)viewModel;

            if ((_requestsViewModel.Client != null ||
                (_requestsViewModel.ClientName != string.Empty &&
                _requestsViewModel.ClientAddress != string.Empty &&
                _requestsViewModel.ClientName != null &&
                _requestsViewModel.ClientAddress != null
                )) &&
                _requestsViewModel.DirectorName != string.Empty &&
                _requestsViewModel.DirectorName != null &&
                _requestsViewModel.Subject != string.Empty &&
                _requestsViewModel.Subject != null &&
                _requestsViewModel.Content != string.Empty &&
                _requestsViewModel.Content != null)
            {
                if (_requestsViewModel.Client == null)
                {
                    //Make new Client
                    _requestsViewModel.Client = ClientService.GetOrCreateClientByNameAndAddress(_requestsViewModel.ClientName, _requestsViewModel.ClientAddress);
                }

                Request request = new Request
                {
                    Client = _requestsViewModel.Client,
                    DirectorName = _requestsViewModel.DirectorName,
                    Subject = _requestsViewModel.Subject,
                    Content = _requestsViewModel.Content,
                    Resolution = string.Empty,
                    Status = Status.Created,
                    Remark = string.Empty
                };

                RequestService.InsertRequest(request, _requestsViewModel.Client);

                _requestsViewModel.ClientName = string.Empty;
                _requestsViewModel.ClientAddress = string.Empty;
                _requestsViewModel.Client = null;
                _requestsViewModel.DirectorName = string.Empty;
                _requestsViewModel.Subject = string.Empty;
                _requestsViewModel.Content = string.Empty;

                //Обновляем список
                _mainWindowViewModel.AllRequests.GetRequestsCommand.Execute(null);
                MessageBox.Show("Успешно добавлено!");
                _mainWindowViewModel.ChangeVisibleGridCommand.Execute(vm);
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
    }
}
