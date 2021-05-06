using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAccounting.Models;
using System;
using System.Collections.Generic;


namespace MyAccounting.Controllers
{
    public class SellreportController : Controller
    {      
        private IRepository clRrepository;
        public SellreportController(IRepository clRepo)
        {
            clRrepository = clRepo;
        }
        // GET: SellreportController
        public IActionResult Index()
        {
            return View(clRrepository.GetAllAct());
           

        }

        public IActionResult Date()
        {          
            return View();
        }
        public IActionResult DateImns()
        {
            return View();
        }
        public IActionResult Tax(DateTime start, DateTime finish )
        {
            DateTime s = start;
            DateTime f = finish;
            ViewBag.DateS = s;
            ViewBag.DateF = f;
            IEnumerable<Client> Clients = clRrepository.GetAllAct();
            return View(clRrepository.GetAllAct());
           
        }

        public IActionResult Imns(DateTime start, DateTime finish)
        {

            DateTime s = start;
            DateTime f = finish;
            ViewBag.DateS = s;
            ViewBag.DateF = f;
            return View(clRrepository.GetAllAct());
           
        }

        // GET: SellreportController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SellreportController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SellreportController/Create
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

        // GET: SellreportController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SellreportController/Edit/5
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

        // GET: SellreportController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SellreportController/Delete/5
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
