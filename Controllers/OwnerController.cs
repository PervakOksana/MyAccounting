using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAccounting.Models;
using MyAccounting.Models.Pages;


namespace MyAccounting.Controllers
{
    public class OwnerController : Controller
    {
        private IOwnerRepository repository;

        public OwnerController(IOwnerRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index(QueryOptions options)
        {
            return View(repository.GetAllOwners(options));
        }


        [HttpPost]
        public IActionResult AddOwner(Owner owner)
        {
            repository.AddOwner(owner);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CopyOwner(long key)
        {

            return View(key == 0 ? new Owner() : repository.GetOwner(key));
        }
        public IActionResult UpdateOwner(long key)
        {

            return View(key == 0 ? new Owner() : repository.GetOwner(key));
        }
        [HttpPost]
        public IActionResult UpdateOwner(Owner owner)
        {
            if (owner.Id == 0)
            {
                repository.AddOwner(owner);
            }
            else
            {
                repository.UpdateOwner(owner);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteOwner(Owner owner)
        {
            repository.DeleteOwner(owner);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult CopyOwner(Owner owner)
        {
            if (owner.Id == 0)
            {
                repository.AddOwner(owner);
            }
            else
            {
                repository.UpdateOwner(owner);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
