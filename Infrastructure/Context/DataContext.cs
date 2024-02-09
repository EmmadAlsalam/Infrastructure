using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<CustomerEntity> Customers { get; set; }
        public virtual DbSet<AddresEntity> Address { get; set; }
        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<IdentityEntity> Identitys { get; set; }
        public virtual DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfigurera relationen mellan CustomerEntity och IdentityEntity
            modelBuilder.Entity<CustomerEntity>()
                .HasOne(c => c.Identitys)
                .WithMany()
                .HasForeignKey(c => c.IdentityId);

            // Konfigurera relationen mellan CustomerEntity och AddresEntity
            modelBuilder.Entity<CustomerEntity>()
                .HasOne(c => c.Address)
                .WithMany()
                .HasForeignKey(c => c.AddressId);

            // Andra konfigurationer för dina entiteter

            base.OnModelCreating(modelBuilder);
        }
    }
}
