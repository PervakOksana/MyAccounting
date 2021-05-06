using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAccounting.Models;
using System;
using System.Collections.Generic;


namespace MyAccounting.Controllers
{
    public class MoneyreportController : Controller
    {
        private IRepository clRrepository;
        public MoneyreportController(IRepository clRepo)
        {
            clRrepository = clRepo;
        }
        // GET: SellreportController
        public IActionResult Index(DateTime start, DateTime finish)
        {
            DateTime s = start;
            DateTime f = finish;
            ViewBag.DateS = s;
            ViewBag.DateF = f;
            //IEnumerable<Money> Clients = (IEnumerable<Money>)clRrepository.GetAllMoney();
            return View(clRrepository.GetAllMoney());
        }

        // GET: MoneyreportController


        // GET: MoneyreportController/Details/5

        public IActionResult Date()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MoneyreportController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoneyreportController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MoneyreportController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MoneyreportController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MoneyreportController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MoneyreportController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
