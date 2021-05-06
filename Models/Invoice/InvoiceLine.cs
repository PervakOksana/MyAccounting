using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccounting.Models
{
    public class InvoiceLine
    {
        public long Id { get; set; }
        public long ServiceId { get; set; }
        public Service Service { get; set; }
        public int Quantity { get; set; }
        public long InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
