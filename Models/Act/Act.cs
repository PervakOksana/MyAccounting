using System;
using System.Collections.Generic;



namespace MyAccounting.Models
{
    public class Act
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public long ClientId { get; set; }
        public Client Client { get; set; }
        public string Text { get; set; }
        public double Summ { get; set; }
        public long OwnerId { get; set; }
        public Owner Owner { get; set; }
        public IEnumerable<ActLine> Lines { get; set; }

    }
}
