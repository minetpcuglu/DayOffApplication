using DayOffApplication.Core.Entities.User.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOffApplication.Infrastructure.DataAccess.EntityTypeConfiguration.FluentAPI
{
    /// <summary>
    /// FLUENT API : veritabanı şemasını yapılandırmak için kullanılır ve bu şemayı Code First yaklaşımıyla oluşturmayı sağlar.
    /// </summary>
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(c => c.Id);
			builder.Property(c => c.FirstName).IsRequired(true).HasMaxLength(500);
            builder.Property(c => c.LastName).IsRequired(true).HasMaxLength(500);
            builder.Property(c => c.Email).IsRequired(true).HasMaxLength(500);
            builder.HasOne(t => t.Manager).WithMany(i => i.Employee).HasForeignKey(i => i.ManagerId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
