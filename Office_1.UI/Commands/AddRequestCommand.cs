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

            Request request = new Request
            {
                Client = _requestsViewModel.Client,
                DirectorName = _requestsViewModel.DirectorName,
                Subject = _requestsViewModel.Subject,
                Content = _requestsViewModel.Content,
                Resolution = _requestsViewModel.Resolution,
                Status = _requestsViewModel.Status,
                Remark = _requestsViewModel.Remark
            };

            RequestService.InsertRequest(request);

            _mainWindowViewModel.ChangeVisibleGridCommand.Execute(vm);
        }
    }
}
