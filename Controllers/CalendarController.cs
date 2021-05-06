using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAccounting.Models;
using MyAccounting.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccounting.Controllers
{
    public class CalendarController : Controller
    {
        private ICalendarRepository repository;
        // GET: CalendarController
        public CalendarController(ICalendarRepository repo)
        {
            repository = repo;
        }
        public ActionResult Index()
        {
           // System.Console.Clear();
            return View(repository.Calendars);
        }

        public IActionResult IndexCalendarDate(long key)
        {

            return View(key == 0 ? new Calendar() : repository.GetCalendar(key));
        }

        [HttpPost]
        public IActionResult IndexCalendarDate(Calendar client)
        {
            if (client.Id == 0)
            {
                repository.AddCalendar(client);
            }
            else
            {
                repository.Update(client);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddCalendar(Calendar client)
        {
            repository.AddCalendar(client);
            return RedirectToAction(nameof(Index));
        }

        
       

        [HttpPost]
        public IActionResult Delete(Calendar client)
        {
            repository.Delete(client);
            return RedirectToAction(nameof(Index));
        }
    }
}
