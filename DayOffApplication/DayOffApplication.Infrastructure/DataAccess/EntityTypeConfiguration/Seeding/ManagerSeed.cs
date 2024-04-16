using DayOffApplication.Core.Entities.User.Employees;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOffApplication.Core.Entities.User.Managers;

namespace DayOffApplication.Infrastructure.DataAccess.EntityTypeConfiguration.Seeding
{
    /// <summary>
    /// Data Seeding : veritabanını oluşturmak ve yapılandırmak için geçiş dosyalarımızı çalıştırır çalıştırmaz,
    /// otomatik olarak bazı başlangıç verileriyle doldururuz. Bu eyleme “Data Seeding” yani Veri Tohumlama denir.
    /// </summary>
    public class ManagerSeed : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {

            builder.HasData(
                new Manager()
                { Id = Guid.NewGuid(), Name = "IT", Description = "IT", Active = true, CreatedByEmail = "system@gmail.com", CreationTime = DateTime.Parse("2024-03-14 14:28:58.9209478"), DeletedByEmail = null, DeletionTime = null, ModificationByEmail = null, ModificationTime = null });         
        }
    }
}
