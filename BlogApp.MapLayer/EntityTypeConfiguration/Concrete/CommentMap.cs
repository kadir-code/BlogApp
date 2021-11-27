using BlogApp.MapLayer.EntityTypeConfiguration.Abstract;
using BlogApp.Model.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.MapLayer.EntityTypeConfiguration.Concrete
{
    public class CommentMap : BaseMap<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Text).IsRequired(true);
            builder.HasKey(x => new { x.AppUserId, x.ArticleId });

            base.Configure(builder);
        }
    }
}
