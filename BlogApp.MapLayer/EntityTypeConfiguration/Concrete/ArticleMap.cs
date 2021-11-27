using BlogApp.MapLayer.EntityTypeConfiguration.Abstract;
using BlogApp.Model.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.MapLayer.EntityTypeConfiguration.Concrete
{
    public class ArticleMap : BaseMap<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(x => x.Title).IsRequired(true);
            builder.Property(x => x.Content).IsRequired(true);
            builder.Property(x => x.Image).IsRequired(true);

            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Category)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);


            base.Configure(builder);
        }
    }
}
