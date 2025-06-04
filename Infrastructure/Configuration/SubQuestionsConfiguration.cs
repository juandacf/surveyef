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
    public class SubQuestionsConfiguration : IEntityTypeConfiguration<SubQuestions>
    {
        public void Configure(EntityTypeBuilder<SubQuestions> builder)
        {
            builder.ToTable("sub_questions");

            builder.HasKey(sq => sq.Id);

            builder.Property(sq => sq.Id)
                .HasColumnName("id");

            builder.Property(sq => sq.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()")
                .HasColumnName("created_at")
                .HasColumnType("timestamp");

            builder.Property(sq => sq.SubQuestionId)
                .HasColumnName("subquestion_id");

            builder.Property(sq => sq.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()")
                .HasColumnName("updated_at")
                .HasColumnType("timestamp");

            builder.Property(sq => sq.SubquestionNumber)
                .HasMaxLength(10)
                .HasColumnName("subquestion_number")
                .HasColumnType("varchar(10)");

            builder.Property(sq => sq.CommentSubquestion)
                .HasColumnName("comment_subquestion")
                .HasColumnType("text");

            builder.Property(sq => sq.SubQuestionText)
                .IsRequired()
                .HasColumnType("text")
                .HasColumnName("subquestiontext");

            builder.HasMany(sq => sq.OptionQuestions)
                .WithOne(oq => oq.SubQuestions)
                .HasForeignKey(oq => oq.SubquestionId);
        }
    }
}