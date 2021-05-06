using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccounting.Models
{
    public class ActLine
    {
        public long Id { get; set; }
        public long ServiceId { get; set; }
        public Service Service { get; set; }
        public int Quantity { get; set; }
        public long ActId { get; set; }
        public Act Act { get; set; }
    }
}
