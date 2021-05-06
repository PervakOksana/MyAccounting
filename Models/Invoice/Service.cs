using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccounting.Models
{
    public class Service
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public double Summ { get; set; }
        public double Vat { get; set; }
        public double VatSum { get; set; }
        public double Total { get; set; }
    }
}
