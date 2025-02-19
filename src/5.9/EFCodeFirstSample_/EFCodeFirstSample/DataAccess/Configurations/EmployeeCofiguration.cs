using EFCodeFirstSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCodeFirstSample.DataAccess.Configurations
{
    public class EmployeeCofiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(50);

            builder.HasData(
                new Employee()
                {
                    Id = new Guid("2c50fd1a-eb6e-40c4-8ff7-62ec12d3da47"),
                    DepartmentId = new Guid("873a932e-1a85-41be-a929-11fee524aeee"),
                    FirstName = "admin",
                    LastName = "admin"
                });
         }
    }
}
