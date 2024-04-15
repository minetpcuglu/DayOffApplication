using Autofac;
using Autofac.Extensions.DependencyInjection;
using DayOffApplication.Application.DependencyResolvers.Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers.Autofac
{
    /// <summary>
    /// Autofac konteynırını başlatmakla sorumludur. Autofac, bağımlılık enjeksiyonu (DI) konteynırının bir uygulamasıdır.
    /// Başlatma Metodu: InitializeContainer metodunun çağrılmasıyla konteynır kurulur.
    ///  Container özelliği, dışarıdan Bootstrapper sınıfına erişim sağlar.
    /// </summary>
    public static class Bootstrapper
    {
        public static IContainer Container { get; private set; }
        public static AutofacServiceProvider InitializeContainer(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacBusinessModule());

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }
    }
}
