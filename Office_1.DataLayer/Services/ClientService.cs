using Office_1.DataLayer.Models;

namespace Office_1.DataLayer.Services;

public static class ClientService
{

    public static IEnumerable<Client> GetClientsByPrefixOfName(string prefixOfName)
    {
        using var context = new ApplicationContext();

        return context.Clients.Where(c => c.Name.StartsWith(prefixOfName));
    }

    public static Client GetOrCreateClientByName(string name, string address)
    {
        using var context = new ApplicationContext();

        var clients = context.Clients.Where(c => c.Name.Equals(name));

        if (clients.Any()) // клиент уже есть в базе
        {
            return clients.First();
        }

        // клиента еще нет в базе
        var c = new Client
        {
            Name = name,
            Address = address
        };

        InsertClient(c);

        return c;
    }

    public static IEnumerable<Client> GetAllClients()
    {
        using var context = new ApplicationContext();

        return context.Clients;
    }

    public static void InsertClient(Client client)
    {
        using var context = new ApplicationContext();

        context.Clients.Add(client);
    }

}