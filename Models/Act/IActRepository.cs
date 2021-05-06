using MyAccounting.Models.Pages;
using System.Collections.Generic;


namespace MyAccounting.Models
{
    public interface IActRepository
    {
        IEnumerable<Act> Acts { get; }
        Act GetAct(long key);
        Act GetActAll(long key);
        public Act GetActt(long key);
        PagedList<Act> GetActs(QueryOptions options);
        void AddAct(Act category);
        void UpdateAct(Act category);
        void DeleteAct(Act category);
    }
    
    
}
