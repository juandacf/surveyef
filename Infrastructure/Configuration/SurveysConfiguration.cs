using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class SurveysConfiguration : IEntityTypeConfiguration<Surveys>
    {
        public void Configure(EntityTypeBuilder<Surveys> builder)
        {
            builder.ToTable("surveys");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()")
            .HasColumnName("created_at")
            .HasColumnType("timestamp");

            builder.Property(s => s.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()")
                .HasColumnName("updated_at")
                .HasColumnType("timestamp");

            builder.Property(s => s.ComponentHTML)
            .HasColumnName("componenthtml")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150);

            builder.Property(s => s.Description)
            .IsRequired()
            .HasColumnName("description")
            .HasColumnType("text");


            builder.Property(s => s.Instruction)
            .HasColumnName("instruction")
            .HasColumnType("text");
            
            builder.Property(s => s.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasColumnType("text");
        }
    }
}