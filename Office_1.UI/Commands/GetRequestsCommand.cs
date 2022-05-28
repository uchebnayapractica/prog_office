using Office_1.BusinessLayer.Models;
using Office_1.UI.ViewModels;
using System.Collections.Generic;

namespace Office_1.UI.Commands
{
    public class GetRequestsCommand : CommandBase
    {
        private readonly AllRequestsViewModel _requestsViewModel;
        public GetRequestsCommand(AllRequestsViewModel ovm)
        {
            _requestsViewModel = ovm;
        }

        public override void Execute(object viewModel)
        {
            _requestsViewModel.Requests.Clear();

            var requests = new List<RequestModel>();

            requests.AddRange(_requestsViewModel.Service.GetSpecialRequests(_requestsViewModel.ShowNew, _requestsViewModel.ShowInProgress, _requestsViewModel.ShowReviewed, _requestsViewModel.ShowCanceled));

            foreach (RequestModel request in requests)
            {
                _requestsViewModel.Requests.Add(request);
            }
        }
    }
}
