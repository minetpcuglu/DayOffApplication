using DayOffApplication.Core.Entities.LeaveRequests;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
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
    public class LeaveRequestMap : IEntityTypeConfiguration<LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveRequest> builder)
        {
            builder.HasKey(c => c.Id);
			builder.HasOne(t => t.Employee).WithMany(i => i.LeaveRequest).HasForeignKey(i => i.AssignedUserId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(c => c.FormNumber).IsRequired(false).HasMaxLength(500);
            builder.Property(c => c.RequestNumber).IsRequired(false).HasMaxLength(500);
            builder.Property(c => c.Reason).IsRequired(false);
            builder.Property(c => c.StartDate).IsRequired(false);
            builder.Property(c => c.EndDate).IsRequired(false);
        }
    }
}
