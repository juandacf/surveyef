using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ChaptersConfiguration : IEntityTypeConfiguration<Chapters>
    {
        public void Configure(EntityTypeBuilder<Chapters> builder)
        {
            builder.ToTable("chapters");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()")
                .HasColumnName("created_at")
                .HasColumnType("timestamp");

            builder.Property(c => c.SurveyId)
                .HasColumnName("survey_id")
                .HasColumnType("int");

            builder.Property(c => c.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()")
                .HasColumnName("updated_at")
                .HasColumnType("timestamp");

            builder.Property(c => c.ComponentHTML)
                .HasColumnName("componenthtml")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder.Property(c => c.ComponentReact)
                .HasColumnName("componentreact")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder.Property(c => c.ChapterNumber)
                .IsRequired()
                .HasColumnName("chapter_number")
                .HasColumnType("varchar(50)");

            builder.Property(c => c.ChapterTitle)
                .IsRequired()
                .HasColumnName("chapter_title")
                .HasColumnType("text");

            builder.HasOne(c => c.Survey)
                .WithMany(s => s.Chapters)
                .HasForeignKey(c => c.SurveyId)
                .HasConstraintName("fk_chapters_survey")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}