using Microsoft.EntityFrameworkCore;
using MyAccounting.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyAccounting.Models
{
    public class MoneyRepository: IMoneyRepository
    {
        private DataContext context;
        public MoneyRepository(DataContext ctx) => context = ctx;
        
        public IEnumerable<Money> Moneys => context.Moneys.Include(p => p.Client).ToArray();
        public PagedList<Money> GetMoneys(QueryOptions options)
        {
            return new PagedList<Money>(context.Moneys.Include(p => p.Client), options);
        }
        public Money GetMoney(long key) => context.Moneys.Include(p => p.Client).First(p => p.Id == key);
        
        
        
        public void AddMoney(Money money)
        {
            this.context.Moneys.Add(money);
            this.context.SaveChanges();
        }
        public void UpdateMoney(Money money)
        {
            context.Moneys.Update(money);
            context.SaveChanges();
        }
        public void DeleteMoney(Money money)
        {
            context.Moneys.Remove(money);
            context.SaveChanges();
        }
    }
}
