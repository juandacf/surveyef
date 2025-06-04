using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Configuration
{
    public class CategoryOptionsConfiguration : IEntityTypeConfiguration<CategoryOptions>
    {
        public void Configure(EntityTypeBuilder<CategoryOptions> builder)
        {
            builder.ToTable("category_options");

            builder.HasKey(co => co.Id);

            builder.Property(co => co.Id)
                .HasColumnName("id");

            builder.Property(co => co.CatalogOptionsId)
                .HasColumnName("catalogoptions_id");

            builder.Property(co => co.CategoriesOptionsId)
                .HasColumnName("categoriesoptions_id");

            builder.HasOne(co => co.CategoriesCatalog)
                .WithMany(co => co.CategoryOptions)
                .HasForeignKey(co => co.CatalogOptionsId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_categoryoptions_categoriescatalog");

            builder.HasOne(co => co.OptionsResponse)
                .WithMany(co => co.CategoryOptions)
                .HasForeignKey(co => co.CategoriesOptionsId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_categoryoptions_optionsresponse");

            builder.Property(co => co.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at")
                .HasColumnType("timestamp");

            builder.Property(co => co.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()")
                .HasColumnName("updated_at")
                .HasColumnType("timestamp");
        }
    }
}