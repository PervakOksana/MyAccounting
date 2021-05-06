using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyAccounting.Models.Pages;

namespace MyAccounting.Models
{
    public class ActRepository : IActRepository
    {
        private DataContext context;
        Client client = new Client();
        public ActRepository(DataContext ctx) => context = ctx;
        public IEnumerable<Act> Acts => context.Acts.Include(p=>p.Client).ToArray();
        public PagedList<Act> GetActs(QueryOptions options)
        {
            return new PagedList<Act>(context.Acts.Include(p => p.Client), options);
        }
        public Act GetAct(long key) => context.Acts.Include(p => p.Client).First(p => p.Id == key);
        public Act GetActAll (long key) => context.Acts.Include(p => p.Lines).First(p => p.Id == key);
        public Act GetActt(long key) => context.Acts.Find(key);
        public Client GetClient (long key) => context.Clients.Find(key);
        public void AddAct(Act act)
        {
          
            this.context.Acts.Add(act);
            this.context.SaveChanges();
        }
        public void UpdateAct(Act act)
        {
            

            context.Acts.Update(act);
            context.SaveChanges();
        }
        public void DeleteAct(Act act)
        {
            context.Acts.Remove(act);
            context.SaveChanges();
        }
    }
}