using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.EntityConfigurations
{
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.CreateDate).ValueGeneratedOnAdd();

            // UpdateDate için ValueGeneratedOnAddOrUpdate kullanabilirsiniz
            builder.Property(i => i.UpdateDate).ValueGeneratedOnAddOrUpdate();

            // Eğer EF sürümü 5 ve sonrasıysa şu şekilde özel bir değer ataması yapabilirsiniz
            // builder.Property(i => i.UpdateDate).HasComputedColumnSql("GETUTCDATE()").ValueGeneratedOnUpdate();
        }
    }

}
