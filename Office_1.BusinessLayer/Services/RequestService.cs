using Office_1.BusinessLayer.Configuration;
using Office_1.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office_1.BusinessLayer.Services
{
    public class RequestService
    {

        private readonly RequestRepository _requestRepository;

        //private Request _request;
        //private ClientService _clientService;

        public RequestService()
        {
            _requestRepository = new RequestRepository();
            //_clientService = new ClientService();
        }

        public List<RequestModel> GetSpecialRequests(bool showNew, bool showInProgress, bool showReviewed, bool showCanceled)
        {
            var requests = GetAllRequests();
            var result = new List<RequestModel>();
            foreach (var request in requests)
            {
                if ((request.Status == "New" && showNew) || 
                    (request.Status == "InProgress" && showInProgress) || 
                    (request.Status == "Reviewed" && showReviewed) || 
                    (request.Status == "Canceled" && showCanceled))
                {
                    result.Add(request);
                }
            }
            return result;
        }

        public List<RequestModel> GetAllRequests()
        {
            var requests = _requestRepository.GetAll();
            List<RequestModel> list = CustomMapper.GetInstance().Map<List<RequestModel>>(requests);

            return list;
        }

        public void UpdateRequest(RequestModel RequestModel)
        {
            Request request = CustomMapper.GetInstance().Map<Request>(RequestModel);
            UpdateRequest(request);
        }

        public Request InsertRequest(RequestModel RequestModel)
        {
            _request = CustomMapper.GetInstance().Map<Request>(RequestModel);
            //_request.ClientId = _clientService.FindClientInDB(RequestModel.Client).Id;
            var idRequest = _requestRepository.Add(_request);
            _request.Id = idRequest;

            return _request;
        }

        private void UpdateRequest(Request request)
        {
            _requestRepository.Update(request);
        }
    }
}
