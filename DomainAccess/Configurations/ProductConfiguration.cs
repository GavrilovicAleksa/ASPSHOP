using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(p => p.Photo).WithOne(ph => ph.Product).HasForeignKey(ph => ph.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
