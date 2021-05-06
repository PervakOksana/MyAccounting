using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAccounting.Models;
using MyAccounting.Models.Pages;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccounting.Controllers
{
    public class InvoiceController : Controller
    {
        private IInvoiceRepository repository;
        private IRepository clRrepository;
        private IOwnerRepository ownerRrepository;
        private IServiceRepository serviceRepository;
        public InvoiceController(IInvoiceRepository repo, IRepository clRepo, IOwnerRepository ownerRrep, IServiceRepository serviceRep)
        {
            repository = repo;
            clRrepository = clRepo;
            ownerRrepository = ownerRrep;
            serviceRepository = serviceRep;
        }
        public IActionResult Index(QueryOptions options)
        {
            return View(repository.GetInvoices(options));
        }
        
        [HttpPost]
        public IActionResult AddInvoice(Invoice invoice)
        {
            repository.AddInvoice(invoice);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult AddInvoiceLine(InvoiceLine invoiceLine, long key)
        {
            repository.AddInvoiceLine(invoiceLine,  key);
            return RedirectToAction(nameof(Index));
        }

       
        public IActionResult EditInvoice(long key)
        {
            ViewBag.Owners = ownerRrepository.Owners;
            ViewBag.Clients = clRrepository.Clients;
            
            var services = serviceRepository.Services;
            Invoice invoice = key == 0 ? new Invoice() : repository.GetInvoice(key);
            Invoice invoice1 = key == 0 ? new Invoice() : repository.GetInvoiceLines(key);
            IDictionary<long, InvoiceLine> linesMap
            = invoice.Lines?.ToDictionary(l => l.ServiceId)
            ?? new Dictionary<long, InvoiceLine>();
            ViewBag.Lines = services.Select(p => linesMap.ContainsKey(p.Id)
            ? linesMap[p.Id]
            : new InvoiceLine { Service = p, ServiceId = p.Id, Quantity = 0 });
            return View(invoice);
        }
        public IActionResult UpdateInvoice(long key)
        {
            ViewBag.InvoiceLines = repository.InvoiceLines;
            ViewBag.Owners = ownerRrepository.Owners;
            ViewBag.Clients = clRrepository.Clients;
            return View(key == 0 ? new Invoice() : repository.GetInvoice(key));
        }
        public IActionResult UpdateInvoiceLine(long key)
        {
            
            return View(key == 0 ? new InvoiceLine() : repository.GetInvoiceLine(key));
        }
        public IActionResult CopyInvoice(long key)
        {
            //ViewBag.InvoiceLines = repository.InvoiceLines;
            //ViewBag.Owners = ownerRrepository.Owners;
            //ViewBag.Clients = clRrepository.Clients;

            //return View(key == 0 ? new Invoice() : repository.GetInvoice(key));

            ViewBag.Owners = ownerRrepository.Owners;
            ViewBag.Clients = clRrepository.Clients;

            var services = serviceRepository.Services;
            Invoice invoice = key == 0 ? new Invoice() : repository.GetInvoice(key);
            Invoice invoice1 = key == 0 ? new Invoice() : repository.GetInvoiceLines(key);
            IDictionary<long, InvoiceLine> linesMap
            = invoice.Lines?.ToDictionary(l => l.ServiceId)
            ?? new Dictionary<long, InvoiceLine>();
            ViewBag.Lines = services.Select(p => linesMap.ContainsKey(p.Id)
            ? linesMap[p.Id]
            : new InvoiceLine { Service = p, ServiceId = p.Id, Quantity = 0 });
            for (int i=0; invoice.Lines.Count()>i;i++) {
                invoice.Lines.ToList().ElementAt(i).Id = 0;
            }
            return View(invoice);
        }
        public IActionResult ViewAsPdf(long key)
        {
            ViewBag.Services = serviceRepository.Services;
            ViewBag.InvoicesLine = repository.InvoiceLines;
            ViewBag.Invoices = repository.Invoices;
            ViewBag.Owners = ownerRrepository.Owners;
            ViewBag.Clients = clRrepository.Clients;
            Invoice d = repository.GetInvoice(key);
            var report = new Rotativa.AspNetCore.ViewAsPdf("PdfInvoice", d);
            return report;
        }

        [HttpPost]
        public IActionResult AddOrUpdateInvoice(Invoice invoice)
        {
            invoice.Lines = invoice.Lines
            .Where(l => l.Id > 0 || (l.Id == 0 && l.Quantity > 0)).ToArray();
            if (invoice.Id == 0)
            {
                repository.AddInvoice(invoice);
            }
            else
            {
                repository.UpdateInvoice(invoice);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult UpdateInvoice(Invoice invoice)
        {
            if (invoice.Id == 0)
            {
                repository.AddInvoice(invoice);
            }
            else
            {
                repository.UpdateInvoice(invoice);
            }
            return RedirectToAction(nameof(Index));
           
        }
        [HttpPost]
        public IActionResult UpdateInvoiceLine(InvoiceLine invoiceLine, long key)
        {
            if (invoiceLine.Id == 0)
            {
                repository.AddInvoiceLine(invoiceLine, key);
            }
            else
            {
                repository.UpdateInvoiceLine(invoiceLine);
            }
            return RedirectToAction(nameof(Index));
           
        }

        [HttpPost]
        public IActionResult ViewAsPdf(Invoice invoice)
        {

            return new ViewAsPdf("UpdateInvoice");
        }
        [HttpPost]
        public IActionResult DeleteInvoice(Invoice invoice)
        {
            repository.DeleteInvoice(invoice);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult CopyInvoice(Invoice invoice)
        {
            if (invoice.Id == 0)
            {
                repository.AddInvoice(invoice);
            }
            else
            {
                repository.UpdateInvoice(invoice);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
