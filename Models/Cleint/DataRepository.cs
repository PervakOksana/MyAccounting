using MyAccounting.Models.Pages;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace MyAccounting.Models
{
    public class DataRepository: IRepository
    {
        //private List<Product> data = new List<Product>();
        private DataContext context;
        public DataRepository(DataContext ctx) => context = ctx;
        public IEnumerable<Client> Clients => context.Clients.ToArray();
        public PagedList<Client> GetClients(QueryOptions options)
        {
            return new PagedList<Client>(context.Clients, options);
        }
        public IEnumerable<Client> GetAllAct()
        {
            return context.Clients.Include(s => s.Acts).ThenInclude(p => p.Lines).ThenInclude(s=>s.Service) ;
        }
        public IEnumerable<Client> GetAllMoney()
        {
            return context.Clients.Include(s => s.Moneys);
        }
        public Client GetClient (long key) => context.Clients.Find(key);
        public void AddClient(Client client)
        {
            this.context.Clients.Add(client);
            this.context.SaveChanges();
        }
        public void UpdateClient(Client client )
        {
           
            context.Clients.Update(client);
            context.SaveChanges();
        }
        public void Delete(Client client)
        {
            context.Clients.Remove(client);
            context.SaveChanges();
        }
    }
}
