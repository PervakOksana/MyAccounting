using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccounting.Models
{
    public class Owner
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public int IdNumber { get; set; }
        public string Adress { get; set; }
        public int Phone { get; set; }
        public string Account { get; set; }
        public string CEO { get; set; }

    }
}
