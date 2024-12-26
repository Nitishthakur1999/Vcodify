using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using VCodify.DatabaseEntities;
using VCodify.Mappers;
using VCodify.Models;
using VCodify.Services.Configuration;
using VCodify.Services.Repositories;
using VCodify.Services.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VcodifyContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"), // First argument: connection string
        new MySqlServerVersion(new Version(5, 7, 26)) // Second argument: MySQL version
    ));




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.TryAddTransient<IRepository, Repository>();
builder.Services.TryAddTransient<IServices, Services>();
builder.Services.TryAddSingleton<ICryptoServices, CryptoService>();
builder.Services.Configure<BaseUrl>(options => builder.Configuration.GetSection("BaseUrl").Bind(options));
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.Configure<TokenVM>(options => builder.Configuration.GetSection("Token").Bind(options));

builder.Services.TryAddSingleton<IMapper>(new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<Mapping>())));
builder.Services.AddAuthentication
              (CookieAuthenticationDefaults.AuthenticationScheme)
          .AddCookie();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.UseCors();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
