using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccounting.Models
{
    public interface ICalendarRepository
    {
        IEnumerable<Calendar> Calendars { get; }
    
        Calendar GetCalendar(long key);
        void AddCalendar(Calendar calendar);
        void Update(Calendar calendar);
        void Delete(Calendar calendar);
    }
}
