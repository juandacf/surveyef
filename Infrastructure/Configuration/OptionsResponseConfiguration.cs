using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class OptionsResponseConfiguration : IEntityTypeConfiguration<OptionsResponse>
    {
        public void Configure(EntityTypeBuilder<OptionsResponse> builder)
        {
            builder.ToTable("options_response");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()")
                .HasColumnName("created_at")
                .HasColumnType("timestamp");

            builder.Property(o => o.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()")
                .HasColumnName("updated_at")
                .HasColumnType("timestamp");

            builder.Property(o => o.OptionText)
                .IsRequired()
                .HasColumnName("optiontext")
                .HasColumnType("text");
        }
    }
}