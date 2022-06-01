using Office_1.DataLayer.Models;
using Office_1.DataLayer.Services;
using Office_1.UI.ViewModels;
using System.Collections.Generic;

namespace Office_1.UI.Commands
{
    public class GetClientsCommand : CommandBase
    {
        private readonly TabViewModel _vm;

        public GetClientsCommand(TabViewModel ovm)
        {
            _vm = ovm;
        }

        public override void Execute(object viewModel)
        {
            _vm.Clients.Clear();

            var clients = new List<Client>();

            clients.AddRange(ClientService.GetAllClients());

            foreach (Client client in clients)
            {
                _vm.Clients.Add(client);
            }
        }
    }
}
