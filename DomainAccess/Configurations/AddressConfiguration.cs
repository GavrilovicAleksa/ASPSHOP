using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{   //WTF WTF WTF WTF WTF WTF
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.Street).IsRequired().HasMaxLength(150);
            builder.Property(x => x.ZipCode).IsRequired().HasMaxLength(50);
        }
    }
}
