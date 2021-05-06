using MyAccounting.Models.Pages;
using System;
using System.Collections.Generic;

namespace MyAccounting.Models
{
    public interface IRepository
    {
        IEnumerable<Client> Clients { get; }
        PagedList<Client> GetClients (QueryOptions options);
        IEnumerable<Client> GetAllAct();
        IEnumerable<Client> GetAllMoney();
        Client GetClient(long key);
        void AddClient(Client client);
        void UpdateClient(Client client);
        void Delete(Client client);
    }
}
