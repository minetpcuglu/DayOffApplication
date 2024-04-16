using DayOffApplication.Core.Entities.LeaveRequests;
using DayOffApplication.Core.Entities.Notifications;
using DayOffApplication.Core.Entities.User.Employees;
using DayOffApplication.Core.Entities.User.Managers;
using DayOffApplication.Infrastructure.DataAccess.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DayOffApplication.Infrastructure.DataAccess.DatabaseContext
{
	public class DayOffApplicationContext:DbContext
	{

		public DayOffApplicationContext(DbContextOptions<DayOffApplicationContext> options)
	   : base(options)
		{
		}
		public DbSet<CumulativeLeaveRequest> CumulativeLeaveRequest { get; set; }
		public DbSet<LeaveRequest> LeaveRequest { get; set; }
		public DbSet<Notification> Notification { get; set; }
		public DbSet<Employee> Employee { get; set; }
		public DbSet<Manager> Manager { get; set; }



		/// <summary>
		/// DayOffApplicationContext sınıfının bulunduğu derlemedeki
		/// tüm Fluent API, Data Seed vb.. tablo yapılandırma sınıflarını (EntityTypeConfiguration sınıfları) kullanarak
		/// model yapılandırmasını uygular.
		/// </summary>
		/// <param name="modelBuilder"></param>

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

        /// <summary>
        ///  Entity Framework Core tabanlı bir uygulamada veritabanı bağlantısının yapılandırılmasını sağlar. 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			Microsoft.Extensions.Configuration.IConfigurationRoot configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("appsettings.json")
				.Build();
			optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServer"));
		}

	}
}
