using BlogApp.MapLayer.EntityTypeConfiguration.Abstract;
using BlogApp.Model.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.MapLayer.EntityTypeConfiguration.Concrete
{
    public class AppUserMap : BaseMap<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(30).IsRequired(true);
            builder.Property(x => x.LastName).HasMaxLength(30).IsRequired(true);
            builder.Property(x => x.UserName).HasMaxLength(30).IsRequired(true);
            builder.Property(x => x.Password).HasMaxLength(30).IsRequired(true);
            builder.Property(x => x.Role).IsRequired(true);
            builder.Property(x => x.Image).HasMaxLength(100).IsRequired(true);

            base.Configure(builder);
        }
    }
}
