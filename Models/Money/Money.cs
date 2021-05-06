using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccounting.Models
{
    public class Money
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public long ClientId { get; set; }
        public Client Client { get; set; }
        public string Text { get; set; }
        public double SummePlus { get; set; }
        public double SummeMinus { get; set; }
        
    }
}
