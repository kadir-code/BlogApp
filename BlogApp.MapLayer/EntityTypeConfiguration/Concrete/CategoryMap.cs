using BlogApp.MapLayer.EntityTypeConfiguration.Abstract;
using BlogApp.Model.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.MapLayer.EntityTypeConfiguration.Concrete
{
    public class CategoryMap : BaseMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Description).IsRequired(true);


            base.Configure(builder);
        }
    }
}
