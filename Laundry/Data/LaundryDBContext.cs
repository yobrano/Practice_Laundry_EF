using Laundry.Models;
using Microsoft.EntityFrameworkCore;

namespace Laundry.Data
{
    public class LaundryDBContext: DbContext
    {
        public DbSet<User> User { get; set; } = null!;
        public DbSet<Staff> Staff { get; set; } = null!;
        public DbSet<Customer> Customer { get; set; } = null!;
        public DbSet<Ticket> Ticket { get; set; } = null!;
        public DbSet<TicketDetail> TicketDetail { get; set; } = null!;
        public DbSet<LaundryService> Service { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // From microsoft connection server 
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Laundry;Trusted_Connection=True;");
        }
    }
}
