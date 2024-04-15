using DayOffApplication.Core.Entities.User.Employees;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOffApplication.Core.Entities.LeaveRequests;

namespace DayOffApplication.Infrastructure.DataAccess.EntityTypeConfiguration.FluentAPI
{
    /// <summary>
    ///Fluent API, veritabanı şemasını yapılandırmak için kullanılır ve bu şemayı Code First yaklaşımıyla oluşturmayı sağlar.
    /// </summary>
    public class CumulativeLeaveRequestMap : IEntityTypeConfiguration<CumulativeLeaveRequest>
    {
        public void Configure(EntityTypeBuilder<CumulativeLeaveRequest> builder)
        {
            builder.HasKey(c => c.Id);

			builder.HasOne(t => t.Employee).WithMany(i => i.CumulativeLeaveRequest).HasForeignKey(i => i.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(c => c.TotalHours).IsRequired(false);
            builder.Property(c => c.Years).IsRequired(false);
        }
    }
}
