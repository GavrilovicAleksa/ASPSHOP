using DataAccess.Configurations;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class Context : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-PV39CK2;Initial Catalog=ShopTest;Integrated Security=True;Pooling=False");
            base.OnConfiguring(optionsBuilder);
        }
        
        
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UseCaseLog> UseCaseLogs { get; set; }

        public DbSet<UserUseCase> UserUseCases { get; set; }
    }
}
