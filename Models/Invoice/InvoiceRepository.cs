using Microsoft.EntityFrameworkCore;
using MyAccounting.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccounting.Models
{
    public class InvoiceRepository: IInvoiceRepository
    {
        private DataContext context;
        Client client = new Client();
        public InvoiceRepository(DataContext ctx) => context = ctx;
        public IEnumerable<Invoice> Invoices => context.Invoices.Include(c => c.Client).ToArray();
        //public IEnumerable<Invoice> Invoices1 => context.Invoices.Include(c => c.Lines).ThenInclude(s => s.Service);
        public IEnumerable<InvoiceLine> InvoiceLines => context.InvoiceLines.ToArray();
        public InvoiceLine GetInvoiceLine(long key) => context.InvoiceLines.Find(key);
        public PagedList<Invoice> GetInvoices(QueryOptions options)
        {
            return new PagedList<Invoice>(context.Invoices.Include(p => p.Client), options);
        }
       public Invoice GetInvoice(long key) => context.Invoices.Find(key);
        public Invoice GetInvoiceLines(long key) => context.Invoices.Include(p => p.Lines).First(p => p.Id == key);
        public Invoice GetInvoices(long key) => context.Invoices.Find(key);
        public Client GetClient(long key) => context.Clients.Find(key);
        public void AddInvoice(Invoice invoice)
        {
            this.context.Invoices.Add(invoice);
            this.context.SaveChanges();
        }
        public void AddInvoiceLine(InvoiceLine invoiceLine, long key)
        {
          
            this.context.InvoiceLines.Add(invoiceLine);
            this.context.SaveChanges();
        }
        public void UpdateInvoiceLine(InvoiceLine invoiceLine)
        {
            this.context.InvoiceLines.Update(invoiceLine);
            this.context.SaveChanges();
        }
        public void UpdateInvoice(Invoice invoice)
        {

            context.Invoices.Update(invoice);
            context.SaveChanges();
        }
        public void DeleteInvoice(Invoice invoice)
        {
            context.Invoices.Remove(invoice);
            context.SaveChanges();
        }
        public void DeleteInvoiceLine(InvoiceLine invoiceLine)
        {
            this.context.InvoiceLines.Remove(invoiceLine);
            this.context.SaveChanges();
        }
    }
}
