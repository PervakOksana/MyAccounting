using Microsoft.EntityFrameworkCore;
using MyAccounting.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccounting.Models
{
    public class OwnerRepository: IOwnerRepository
    {
        private DataContext context;
        public OwnerRepository(DataContext ctx) => context = ctx;

        public IEnumerable<Owner> Owners => context.Owners.ToArray();
        public PagedList<Owner> GetAllOwners(QueryOptions options)
        {
            return new PagedList<Owner>(context.Owners, options);
        }
       
        
        public Owner GetOwner(long key) => context.Owners.Find(key);
        public void AddOwner(Owner owner)
        {
            this.context.Owners.Add(owner);
            this.context.SaveChanges();
        }
        public void UpdateOwner(Owner owner)
        {

            context.Owners.Update(owner);
            context.SaveChanges();
        }
        public void DeleteOwner(Owner owner)
        {
            context.Owners.Remove(owner);
            context.SaveChanges();
        }

        
    }
}
