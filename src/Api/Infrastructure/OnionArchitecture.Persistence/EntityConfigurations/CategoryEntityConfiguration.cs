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
    public class CategoryEntityConfiguration:BaseEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder) 
        {
            base.Configure(builder);
            builder.ToTable("Category",OnionArchitecture_Context.DEFAULT_SHEMA);
        }
    }
}
