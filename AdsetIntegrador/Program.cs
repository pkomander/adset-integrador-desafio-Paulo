using AdsetIntegrador.Repository.Data;
using AdsetIntegrador.Repository.Services.Interface;
using AdsetIntegrador.Repository.Services.Repository;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using SharpDX.DXGI;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("AdsetIntegradorConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IGenericService, GenericRepository>();
builder.Services.AddScoped<ICarroService, CarroRepository>();
builder.Services.AddScoped<IFotoService, FotoRepository>();
builder.Services.AddScoped<ICarroFotoService, CarroFotoRepository>();

builder.Services.AddControllersWithViews()
        .AddDataAnnotationsLocalization(options => {
            options.DataAnnotationLocalizerProvider = (type, factory) =>
                factory.Create(typeof(SharedResource));
        });

builder.Services.Configure<RequestLocalizationOptions>(options => {
    var supportedCultures = new[] { new CultureInfo("pt-BR") };
    options.DefaultRequestCulture = new RequestCulture("pt-BR");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRequestLocalization();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Carro}/{action=Index}/{id?}");

app.Run();
