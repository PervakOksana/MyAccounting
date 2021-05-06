using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccounting.Models
{
    public class CalendarRepository : ICalendarRepository
    {
        private DataContext context;
        public CalendarRepository(DataContext ctx) => context = ctx;
        public IEnumerable<Calendar> Calendars => context.Calendars.ToArray();

        //public IEnumerable<Calendar> Calendars => context.Calendars;
        public Calendar GetCalendar(long key) => context.Calendars.Find(key);
        public void AddCalendar(Calendar client)
        {
            this.context.Calendars.Add(client);
            this.context.SaveChanges();
        }
        public void Update(Calendar client)
        {

            context.Calendars.Update(client);
            context.SaveChanges();
        }
        public void Delete(Calendar client)
        {
            context.Calendars.Remove(client);
            context.SaveChanges();
        }
    }
}
