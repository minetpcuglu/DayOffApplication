using DayOffApplication.Core.Entities.User.Employees;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOffApplication.Core.Entities.User.Managers;

namespace DayOffApplication.Infrastructure.DataAccess.EntityTypeConfiguration.FluentAPI
{
    /// <summary>
    /// FLUENT API : veritabanı şemasını yapılandırmak için kullanılır ve bu şemayı Code First yaklaşımıyla oluşturmayı sağlar.
    /// </summary>
    public class ManagerMap : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(c => c.Id);
			builder.Property(c => c.Name).IsRequired(true).HasMaxLength(500);
            builder.Property(c => c.Description).IsRequired(false).HasMaxLength(1000);

        }
    }
}
