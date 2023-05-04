using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;

namespace ApplicationCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Empoyee { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }

    }

}
