using Ardalis.Specification;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using DayOffApplication.Infrastructure.DataAccess.DatabaseContext;
using DayOffApplication.Infrastructure.DataAccess.EntityFrameworkRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOffApplication.Application.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
        /// <summary>
        /// AutofacBusinessModule sınıfının Load metodunda yer alır ve belirli bir derleme içerisindeki türlerin kaydedilmesini ve
		/// Autofac tarafından yönetilen tüm arabirimlerin otomatik olarak tespit edilmesini sağlar
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<DbContextOptions<DayOffApplicationContext>>().AsSelf().InstancePerDependency();
			builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepositoryBase<>)).InstancePerDependency();


		
			var assembly = System.Reflection.Assembly.GetExecutingAssembly();
			builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(
				new ProxyGenerationOptions()
				{
				}).InstancePerDependency();
		}
	}
}
