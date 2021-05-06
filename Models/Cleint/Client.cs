using System.Collections.Generic;

namespace MyAccounting.Models
{
    public class Client
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public int IdNumber { get; set; }
        public int OKPO { get; set; }
        public string Adress { get; set; }
        public int Phone { get; set; }
        public string Account { get; set; }
        public string CEO { get; set; }
        public IEnumerable<Act> Acts { get; set; }
        public IEnumerable<Money> Moneys { get; set; }
    }
}
