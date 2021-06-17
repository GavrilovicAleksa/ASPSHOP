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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasAlternateKey(x => x.Email);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.Property(x => x.UserName).HasMaxLength(50);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(150);

            builder.HasMany(u => u.Addresses).WithOne(a => a.User).HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserUserCases).WithOne(u => u.User).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Photo).WithOne(ph => ph.User).HasForeignKey(ph => ph.UserId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
