using ConsoleApp.Repositories;
using ConsoleApp.Services;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.LocalServices;
using System;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Code\Infrastructure\Infrastructure\Data\databaceorginal.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<CustomerRepository>();
    services.AddScoped<AddressRepository>();
    services.AddScoped<CategoryRepository>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<IdentityRepository>();

    services.AddScoped<AddressService>();
    services.AddScoped<CategoryService>();
    services.AddScoped<IdentityService>();
    services.AddScoped<ProductService>();
    services.AddScoped<CustomerService>();
    services.AddSingleton<MenuService>();

}).Build();

var menuService = builder.Services.GetRequiredService<MenuService>();

//menuService.CreateProduct();
 //menuService.GetProducts();
//menuService.UpdateProduct();
//menuService.DeleteProduct();


//menuService.CreateCustomer();
//menuService.GetCustomers();
//menuService.UpdateCustomer();
//menuService.DeleteCustomer();