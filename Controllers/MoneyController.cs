using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAccounting.Models;
using MyAccounting.Models.Pages;


namespace MyAccounting.Controllers
{
    public class MoneyController : Controller
    {
        private IMoneyRepository repository;
        private IRepository clRrepository;
        public MoneyController(IMoneyRepository repo, IRepository clRepo)
        {
            repository = repo;
            clRrepository = clRepo;
        }
        public IActionResult Index(QueryOptions options)
        {
            return View(repository.GetMoneys(options));
        }
        // public IActionResult Index() => View(repository.Moneys);
        [HttpPost]
        public IActionResult AddMoney(Money money)
        {
            repository.AddMoney(money);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditMoney(long id)
        {
            ViewBag.EditId = id;
            return View("Index", repository.Moneys);
        }
        public IActionResult CopyMoney(long key)
        {
            ViewBag.Clients = clRrepository.Clients;
            return View(key == 0 ? new Money() : repository.GetMoney(key));
        }
        public IActionResult UpdateMoney(long key)
        {
            ViewBag.Clients = clRrepository.Clients;
            return View(key == 0 ? new Money() : repository.GetMoney(key));
        }
        [HttpPost]
        public IActionResult UpdateMoney(Money money)
        {
            repository.UpdateMoney(money);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult DeleteMoney(Money money)
        {
            repository.DeleteMoney(money);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult CopyMoney(Money money)
        {
            if (money.Id == 0)
            {
                repository.AddMoney(money);
            }
            else
            {
                repository.UpdateMoney(money);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
