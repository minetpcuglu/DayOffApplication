

using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.DependencyResolvers.Autofac;
using DayOffApplication.Application.DependencyResolvers.Autofac;
using DayOffApplication.Web.Configuration;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DayOffApplication.Web.AutoMapper;
using AutoMapper.EquivalencyExpression;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

#region Context
DayOffDbContext.AddMyDbContext(builder.Services, builder.Configuration);
#endregion

#region Autofac

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
	.ConfigureContainer<ContainerBuilder>(b =>
	{

		b.RegisterModule(new AutofacBusinessModule());

	});
Bootstrapper.InitializeContainer(builder.Services);
#endregion

#region AutoMapper
var mapperConfig = new MapperConfiguration(cfg =>
{
	cfg.AddProfile<MappingProfile>();
	cfg.AddCollectionMappers();
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddSession();

#endregion

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.IgnoreNullValues = true;
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Request}/{action=Index}/{id?}");

app.Run();
