﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcellTothNet.Services.Article.Infrastructure.EntityConfigurations
{
    public class ArticleTypeConfiguration : IEntityTypeConfiguration<Domain.ArticleAggregate.Article>
    {
        public void Configure(EntityTypeBuilder<Domain.ArticleAggregate.Article> builder)
        {
            builder.ToTable("Articles");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(240);

            builder.Property(a => a.Content)
                .IsRequired();

            builder.Property(a => a.PublishTime)
                .IsRequired();

            // Store the thumbnail data in the same table using EF Core 2.0's Owned Entities feature.
            builder.OwnsOne(a => a.Thumbnail);


        }
    }
}