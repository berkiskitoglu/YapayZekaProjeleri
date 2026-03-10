using Microsoft.EntityFrameworkCore;
using NetCoreAI.Project01_ApiDemo.Entities;

namespace NetCoreAI.Project01_ApiDemo.Context
{
    public class ApiContext : DbContext
    {
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ApiAIDb;Trusted_Connection=True; integrated security = true; trustservercertificate=true;");
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
