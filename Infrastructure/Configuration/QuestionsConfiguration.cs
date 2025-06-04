using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class QuestionsConfiguration
    {
        public void Configure(EntityTypeBuilder<Questions> builder)
        {
            builder.ToTable("questions");

            builder.HasKey(q => q.Id);

            builder.Property(q => q.Id)
                .HasColumnName("id");

            builder.Property(q => q.ChapterId)
                .HasColumnName("chapter_id")
                .HasColumnType("int");

            builder.Property(q => q.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()")
                .HasColumnName("created_at")
                .HasColumnType("timestamp");

            builder.Property(q => q.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()")
                .HasColumnName("updated_at")
                .HasColumnType("timestamp");

            builder.Property(q => q.QuestionNumber)
                .HasMaxLength(10)
                .HasColumnName("question_number")
                .HasColumnType("varchar(10)");

            builder.Property(q => q.ResponseType)
                .HasMaxLength(10)
                .HasColumnName("response_type")
                .HasColumnType("varchar(10)");

            builder.Property(q => q.CommentQuestion)
                .HasColumnName("comment_question")
                .HasColumnType("text");

            builder.Property(q => q.Questiontext)
                .IsRequired()
                .HasColumnName("question_text")
                .HasColumnType("text");

            builder.HasOne(q => q.Chapter)
                .WithMany(c => c.Questions)
                .HasForeignKey(q => q.ChapterId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_questions_chapters");
        }
    }
}