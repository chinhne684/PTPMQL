using Microsoft.EntityFrameworkCore;
using DemoMVC1.Models;

namespace DemoMVC1.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Person> Person { get; set; }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<HeThongPhanPhoi> HeThongPhanPhoi { get; set; }
        public DbSet<DaiLy> DaiLy { get; set; }

    }
}


