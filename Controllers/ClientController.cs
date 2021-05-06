using Microsoft.AspNetCore.Mvc;
using MyAccounting.Models;
using MyAccounting.Models.Pages;


namespace MyAccounting.Controllers
{

    public class ClientController : Controller
    {
        private IRepository repository;
      
        public ClientController(IRepository repo)
        {
            repository = repo;           
        }
        public IActionResult Index(QueryOptions options)
        {
            return View(repository.GetClients(options));
        }
       

        [HttpPost]
        public IActionResult AddProduct(Client client)
        {
            repository.AddClient(client);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CopyClient(long key)
        {

            return View(key == 0 ? new Client() : repository.GetClient(key));
        }
        public IActionResult UpdateClient(long key)
        {
            
            return View(key == 0 ? new Client(): repository.GetClient(key));
        }
        [HttpPost]
        public IActionResult UpdateClient(Client client)
        { if (client.Id == 0)
            {
                repository.AddClient(client);
            }
            else { 
                repository.UpdateClient(client);
            }          
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(Client client)
        {
            repository.Delete(client);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult CopyClient(Client client)
        {
            if (client.Id == 0)
            {
                repository.AddClient(client);
            }
            else
            {
                repository.UpdateClient(client);
            }
            return RedirectToAction(nameof(Index));
        }
       
    }
}
