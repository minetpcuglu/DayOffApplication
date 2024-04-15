using DayOffApplication.Core.Entities.User.Managers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOffApplication.Core.Entities.Notifications;

namespace DayOffApplication.Infrastructure.DataAccess.EntityTypeConfiguration.FluentAPI
{
    /// <summary>
    /// FLUENT API : veritabanı şemasını yapılandırmak için kullanılır ve bu şemayı Code First yaklaşımıyla oluşturmayı sağlar.
    /// </summary>
    public class NotificationMap : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(c => c.Id);
			builder.Property(c => c.Message).IsRequired(true).HasMaxLength(500);
            builder.HasOne(t => t.Employee).WithMany(i => i.Notification).HasForeignKey(i => i.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(t => t.CumulativeLeaveRequest).WithMany(i => i.Notification).HasForeignKey(i => i.CumulativeLeaveRequestId).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
