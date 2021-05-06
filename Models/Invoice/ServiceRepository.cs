using MyAccounting.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccounting.Models
{
    public class ServiceRepository: IServiceRepository
    {
        private DataContext context;
        public ServiceRepository(DataContext ctx) => context = ctx;
        public IEnumerable<Service> Services => context.Services.ToArray();
        public PagedList<Service> GetServices(QueryOptions options)
        {
            return new PagedList<Service>(context.Services, options);
        }
       
        
        public Service GetService(long key) => context.Services.Find(key);
        public void AddService(Service service)
        {
            this.context.Services.Add(service);
            this.context.SaveChanges();
        }
        public void UpdateService(Service service)
        {

            context.Services.Update(service);
            context.SaveChanges();
        }
        public void DeleteService(Service service)
        {
            context.Services.Remove(service);
            context.SaveChanges();
        }
    }
}
