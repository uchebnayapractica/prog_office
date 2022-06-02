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
                (_requestsViewModel.ClientName != string.Empty && _requestsViewModel.ClientAddress != string.Empty))&&
                _requestsViewModel.DirectorName != string.Empty &&
                _requestsViewModel.Subject != string.Empty && 
                _requestsViewModel.Content != string.Empty)
            {
                if (_requestsViewModel.Client == null)
                {
                    //Make new Client
                    _requestsViewModel.Client = new Client
                    {
                        Name = _requestsViewModel.ClientName,
                        Address = _requestsViewModel.ClientAddress
                    };
                }

                Request request = new Request
                {
                    Client = _requestsViewModel.Client,
                    DirectorName = _requestsViewModel.DirectorName,
                    Subject = _requestsViewModel.Subject,
                    Content = _requestsViewModel.Content,
                };

                //RequestService.InsertRequest(request);

                _mainWindowViewModel.ChangeVisibleGridCommand.Execute(vm);
            } else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
    }
}
