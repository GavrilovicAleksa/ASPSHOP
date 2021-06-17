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
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Slogan).HasMaxLength(150);
            builder.Property(x => x.Description).HasMaxLength(150);

            builder.HasMany(b => b.Products).WithOne(p => p.Brand).HasForeignKey(p => p.Brand_id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
