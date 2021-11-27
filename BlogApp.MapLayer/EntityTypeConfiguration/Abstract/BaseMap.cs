using BlogApp.Model.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.MapLayer.EntityTypeConfiguration.Abstract
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.CreateDate).IsRequired(true);
            builder.Property(x => x.ModifiedDate).IsRequired(false);
            builder.Property(x => x.RemovedDate).IsRequired(false);
            builder.Property(x => x.Status).IsRequired(true);

        }
    }
}
