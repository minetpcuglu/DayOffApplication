using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOffApplication.Core.Entities.User.Employees;

namespace DayOffApplication.Infrastructure.DataAccess.EntityTypeConfiguration.Seeding
{
    /// <summary>
    /// Data Seeding : veritabanını oluşturmak ve yapılandırmak için geçiş dosyalarımızı çalıştırır çalıştırmaz,
	/// otomatik olarak bazı başlangıç verileriyle doldururuz. Bu eyleme “Data Seeding” yani Veri Tohumlama denir.
    /// </summary>
    public class EmployeeSeed : IEntityTypeConfiguration<Employee>
	{
		public void Configure(EntityTypeBuilder<Employee> builder)
		{

			builder.HasData(
				new Employee() 
				{   Id= Guid.NewGuid(),
					FirstName = "Mine",
					LastName = "Topcuoglu",
					Email="minetopcuoglu6@gmail.com",
					ManagerId= Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3301"),
					Active=true,
					CreatedByEmail="system@gmail.com",
					CreationTime = DateTime.Parse("2024-03-14 14:28:58.9209478"),
					DeletedByEmail=null,
					DeletionTime =null,
					ModificationByEmail=null,
					UserType=Core.Enums.User.UserType.Manager,
					ModificationTime=null },
				
			    new Employee() 
				{ Id = Guid.NewGuid(), FirstName = "Emre", LastName = "Topcuoglu",Email="emretopcuoglu@gmail.com",ManagerId=null,Active=true,CreatedByEmail="system@gmail.com", CreationTime = DateTime.Parse("2024-03-14 14:28:58.9209478"),DeletedByEmail=null,DeletionTime =null,ModificationByEmail=null,UserType=Core.Enums.User.UserType.BlueCollarEmployee,ModificationTime=null },
				
			    new Employee() 
				{ Id= Guid.NewGuid(), FirstName = "Elif", LastName = "Topcuoglu",Email="eliftopcuoglu@gmail.com",ManagerId=null,Active=true,CreatedByEmail="system@gmail.com", CreationTime = DateTime.Parse("2024-03-14 14:28:58.9209478"),DeletedByEmail=null,DeletionTime =null,ModificationByEmail=null,UserType=Core.Enums.User.UserType.WhiteCollarEmployee,ModificationTime=null }
				);
		}
	}
}
