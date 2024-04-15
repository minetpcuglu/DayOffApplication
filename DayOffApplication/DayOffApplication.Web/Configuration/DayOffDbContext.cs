

using DayOffApplication.Infrastructure.DataAccess.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DayOffApplication.Web.Configuration
{
	public static class DayOffDbContext
	{
        /// <summary>
		/// Veritabanı bağlantı dizesi, yapılandırma nesnesi (IConfiguration) aracılığıyla alınır. Bu, GetConnectionString yöntemi kullanılarak "SqlServer" adındaki bağlantı dizesi alınır
		/// services.AddDbContext<DayOffApplicationContext> kullanılarak, DayOffApplicationContext sınıfı için bağımlılık enjeksiyonu yapılandırması eklenir. 
        /// Transient servis ömrü, her talep edildiğinde yeni bir örnek oluşturur
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddMyDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			string connectionString = configuration.GetConnectionString("SqlServer");
			services.AddDbContext<DayOffApplicationContext>(options => options.UseSqlServer(connectionString, builder =>
			{
				
				builder.CommandTimeout(180);  
			}), ServiceLifetime.Transient);

		}
	}
}
