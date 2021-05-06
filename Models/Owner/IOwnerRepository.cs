using MyAccounting.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccounting.Models
{
  public  interface IOwnerRepository
    {
        IEnumerable<Owner> Owners { get; }
        Owner GetOwner(long key);
        PagedList<Owner> GetAllOwners(QueryOptions options);
        void AddOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
    }
}
