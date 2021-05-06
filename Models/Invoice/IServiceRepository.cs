using MyAccounting.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccounting.Models
{
    public interface IServiceRepository
    {
        IEnumerable<Service> Services { get; }
        PagedList<Service> GetServices(QueryOptions options);
        Service GetService(long key);
        void AddService(Service service);
        void UpdateService(Service service);
        void DeleteService(Service service);
    }
}
