using MyAccounting.Models.Pages;
using System;
using System.Collections.Generic;


namespace MyAccounting.Models
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> Invoices { get; }
        //IEnumerable<Invoice> Invoices1 { get; }
        IEnumerable<InvoiceLine> InvoiceLines { get; }
        Invoice GetInvoice(long key);
        Invoice GetInvoiceLines(long key);
        public InvoiceLine GetInvoiceLine(long key) ;
        PagedList<Invoice> GetInvoices(QueryOptions options);
        void AddInvoice(Invoice category);
        void AddInvoiceLine(InvoiceLine category, long key);
        void UpdateInvoice(Invoice category);
        void UpdateInvoiceLine(InvoiceLine category);
        void DeleteInvoice(Invoice category);
    }
}
