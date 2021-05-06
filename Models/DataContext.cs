using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace MyAccounting.Models
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { Database.EnsureCreated(); }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Act> Acts { get; set; }
        public DbSet<Money> Moneys { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<ActLine> ActLines { get; set; }
        public DbSet<Service> Services { get; set; }


    }
}
