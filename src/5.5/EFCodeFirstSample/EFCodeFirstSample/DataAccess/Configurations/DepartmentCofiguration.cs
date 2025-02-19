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
        }
    }
}
