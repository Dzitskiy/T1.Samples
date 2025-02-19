using EFCodeFirstSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Reflection;

namespace EFCodeFirstSample.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        /**/private readonly ILazyLoader _lazyLoader;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options
            /**/, ILazyLoader lazyLoader
            ) : base(options)       
        {

            /**/_lazyLoader = lazyLoader;

            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /**/
            optionsBuilder.UseLazyLoadingProxies(options =>
            options.IgnoreNonVirtualNavigations());
             /**/

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), t => t.GetInterfaces().Any(i =>
            i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
                        
            base.OnModelCreating(modelBuilder);
        }
    }
}
