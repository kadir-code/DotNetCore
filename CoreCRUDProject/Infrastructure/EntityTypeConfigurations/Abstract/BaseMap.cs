using CoreCRUDProject.Models.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCRUDProject.Infrastructure.EntityTypeConfigurations.Abstract
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T: BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Id);

            builder.Property(x => x.CreateDate)
                .HasColumnName("CreateDate")
                .HasColumnType("datetime2")
                .IsRequired(true);

            builder.Property(x => x.UpdateDate)
                .HasColumnName("UpdateDate")
                .HasColumnType("datetime2")
                .IsRequired(false);

            builder.Property(x => x.DeleteDate)
                .HasColumnName("DeleteDate")
                .HasColumnType("datetime2")
                .IsRequired(false);

            builder.Property(x => x.Status)
                .HasColumnName("Status")
                .IsRequired(true);
        }
    }
}
