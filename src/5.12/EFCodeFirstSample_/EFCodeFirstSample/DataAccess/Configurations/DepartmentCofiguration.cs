using EFCodeFirstSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCodeFirstSample.DataAccess.Configurations
{
    public class DepartmentCofiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(d => d.Name).HasMaxLength(256).IsRequired();

            builder
              .HasMany(d => d.Employees)
              .WithOne(e => e.Department)
              .HasForeignKey(e => e.DepartmentId);

            //builder.HasData( 
            //    new Department() 
            //    { 
            //        Id = new Guid("873a932e-1a85-41be-a929-11fee524aeee"),
            //        Name = "Office"
            //    });
        }
    }
}
