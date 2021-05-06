using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAccounting.Models;
using MyAccounting.Models.Pages;


namespace MyAccounting.Controllers
{
    public class ServiceController : Controller
    {
        private IServiceRepository repository;

        public ServiceController(IServiceRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index(QueryOptions options)
        {
            return View(repository.GetServices(options));
        }


        [HttpPost]
        public IActionResult AddService(Service service)
        {
            repository.AddService(service);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CopyService(long key)
        {

            return View(key == 0 ? new Service() : repository.GetService(key));
        }
        public IActionResult UpdateService(long key)
        {

            return View(key == 0 ? new Service() : repository.GetService(key));
        }
        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            if (service.Id == 0)
            {
                repository.AddService(service);
            }
            else
            {
                repository.UpdateService(service);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteService(Service service)
        {
            repository.DeleteService(service);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult CopyService(Service service)
        {
            if (service.Id == 0)
            {
                repository.AddService(service);
            }
            else
            {
                repository.UpdateService(service);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
