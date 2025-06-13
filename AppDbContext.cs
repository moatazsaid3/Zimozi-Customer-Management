using CustomerManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement
{
    public class AppDbContext : DbContext
    {
            
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
