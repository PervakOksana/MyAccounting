using System;
using System.Collections.Generic;


namespace MyAccounting.Models
{
    public class Invoice
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public long ClientId { get; set; }
        public Client Client { get; set; }
        public long OwnerId { get; set; }
        public Owner Owner { get; set; }
        public IEnumerable<InvoiceLine> Lines { get; set; }
    }
}
