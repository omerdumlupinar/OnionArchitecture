using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.Domain.Models;
using OnionArchitecture.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.EntityConfigurations
{
    public class ProductEntityConfiguration:BaseEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.ToTable("Product", OnionArchitecture_Context.DEFAULT_SHEMA);

            builder.HasOne(x => x.Category)
                .WithMany(X => X.Products)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
