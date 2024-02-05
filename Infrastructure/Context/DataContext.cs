
using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public partial class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public virtual DbSet<CustomerEntity> Customers { get; set; }
    public virtual DbSet<AddresEntity> Address { get; set; }
    public virtual DbSet<ProductEntity> Products { get; set; }
    public virtual DbSet<IdentityEntity> Identitys { get; set; }
    public virtual DbSet<CategoryEntity> Categories { get; set; }


}