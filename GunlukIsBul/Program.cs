using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Context;
using DTOLayer.DTOs;
using FluentValidation;
using GunlukIsBul.AutoMapper;
using GunlukIsBul.Middlewares;
using GunlukIsBul.Validations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddValidatorsFromAssemblyContaining<IlanEkleValidation>();

builder.Services.AddScoped<IValidator<IlanEkleDTO>, IlanEkleValidation>();
builder.Services.AddScoped<IValidator<IlanGuncelleDTO>, IlanGuncelleValidation>();

builder.Services.AddDbContext<GunlukIsBulContext>();
//builder.Services.AddDbContext<GunlukIsBulContext>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("SqLite")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IIlanService, IlanService>();
builder.Services.AddScoped<IKategoriService, KategoriService>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<GunlukIsBulContext>()
  .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/admin/login";
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<CustomExcpetionMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
