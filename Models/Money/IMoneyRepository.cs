using MyAccounting.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccounting.Models
{
    public interface IMoneyRepository
    {
        IEnumerable<Money> Moneys { get; }
        Money GetMoney(long key);
        PagedList<Money> GetMoneys(QueryOptions options);
        void AddMoney(Money money);
        void UpdateMoney(Money money);
        void DeleteMoney(Money money);
    }
}
