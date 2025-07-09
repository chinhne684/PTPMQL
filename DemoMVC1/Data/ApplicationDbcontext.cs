using Microsoft.EntityFrameworkCore;
using DemoMVC1.Models;
namespace DemoMVC1.Data
{

    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Person> Person { get; set; }
    }

    
}