using Microsoft.AspNetCore.Mvc;
using MyAccounting.Models;
using MyAccounting.Models.Pages;
using Rotativa.AspNetCore;
using System.Collections.Generic;
using System.Linq;



namespace MyAccounting.Controllers
{
    public class ActController: Controller
    {
        private IActRepository repository;
        private IRepository clRrepository;
        private IOwnerRepository ownerRepository;
        private IServiceRepository serviceRepository;
        public ActController(IActRepository repo, IRepository clRepo, IOwnerRepository ownerRep, IServiceRepository serviceRep) {
            repository = repo;
            clRrepository = clRepo;
            ownerRepository = ownerRep;
            serviceRepository = serviceRep;
        }
        public IActionResult Index(QueryOptions options)
        {
            return View(repository.GetActs(options));
        }
       // public IActionResult Index() => View(repository.Acts);
        [HttpPost]
        public IActionResult AddAct(Act act)
        {
            repository.AddAct(act);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditAct(long key)
        {
            ViewBag.Owners = ownerRepository.Owners;
            ViewBag.Clients = clRrepository.Clients;

            var services = serviceRepository.Services;
            Act act = key == 0 ? new Act() : repository.GetActAll(key);
            Act act1 = key == 0 ? new Act() : repository.GetAct(key);
          
            IDictionary<long, ActLine> linesMap
            = act.Lines?.ToDictionary(l => l.ServiceId)
            ?? new Dictionary<long, ActLine>();
            ViewBag.Lines = services.Select(p => linesMap.ContainsKey(p.Id)
            ? linesMap[p.Id]
            : new ActLine { Service = p, ServiceId = p.Id, Quantity = 0 });
            return View(act);
        }
        public IActionResult UpdateAct(long key)
        {
            ViewBag.Owners = ownerRepository.Owners;
            ViewBag.Clients = clRrepository.Clients;
            return View(key == 0 ? new Act() : repository.GetAct(key));
        }
        public IActionResult CopyAct(long key)
        {
            ViewBag.Owners = ownerRepository.Owners;
            ViewBag.Clients = clRrepository.Clients;

            var services = serviceRepository.Services;
            Act act = key == 0 ? new Act() : repository.GetActAll(key);
            Act act1 = key == 0 ? new Act() : repository.GetAct(key);

            IDictionary<long, ActLine> linesMap
            = act.Lines?.ToDictionary(l => l.ServiceId)
            ?? new Dictionary<long, ActLine>();
            ViewBag.Lines = services.Select(p => linesMap.ContainsKey(p.Id)
            ? linesMap[p.Id]
            : new ActLine { Service = p, ServiceId = p.Id, Quantity = 0 });

            for (int i = 0; act.Lines.Count() > i; i++)
            {
                act.Lines.ToList().ElementAt(i).Id = 0;
            }

            return View(act);
        }
        public IActionResult ViewAsPdf(long key)
        {
            ViewBag.Services = serviceRepository.Services;

            ViewBag.Act = repository.Acts;
            ViewBag.Owners = ownerRepository.Owners;
            ViewBag.Clients = clRrepository.Clients;
            Act d = repository.GetActAll(key);
            var report = new Rotativa.AspNetCore.ViewAsPdf("PdfAct", d);
            return report;
        }

        [HttpPost]
        public IActionResult AddOrUpdateAct(Act act)
        {
            act.Lines = act.Lines
            .Where(l => l.Id > 0 || (l.Id == 0 && l.Quantity > 0)).ToArray();
            if (act.Id == 0)
            {
                repository.AddAct(act);
            }
            else
            {
                repository.UpdateAct(act);
            }
            return RedirectToAction(nameof(Index));
           
        }

        [HttpPost]
        public IActionResult ViewAsPdf(Act act)
        {
            
            return new ViewAsPdf("UpdateAct");
        }
        [HttpPost]
        public IActionResult DeleteAct(Act act)
        {
            repository.DeleteAct(act);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult CopyAct(Act act)
        {
            if (act.Id == 0)
            {
                repository.AddAct(act);
            }
            else
            {
                repository.UpdateAct(act);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
