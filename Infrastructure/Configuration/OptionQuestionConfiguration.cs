using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class OptionQuestionConfiguration : IEntityTypeConfiguration<OptionQuestions>
    {
        public void Configure(EntityTypeBuilder<OptionQuestions> builder)
        {
            builder.ToTable("OptionQuestions");

            builder.HasKey(oq => oq.Id);

            builder.Property(oq => oq.Id)
                .HasColumnName("id");

            builder.Property(oq => oq.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()")
                .HasColumnType("timestamp");

            builder.Property(oq => oq.OptionId)
                .HasColumnName("option_id");

            builder.Property(oq => oq.OptionCatalogId)
                .HasColumnName("optioncatalog_id");

            builder.Property(oq => oq.OptionQuestionId)
                .HasColumnName("optionquestion_id");

            builder.Property(oq => oq.SubquestionId)
                .HasColumnName("subquestion_id");

            builder.HasOne(oq => oq.Optionresponse)
                .WithMany(oq => oq.OptionQuestions)
                .HasForeignKey(oq => oq.OptionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_OptionQuestions_OptionsResponse");

            builder.HasOne(oq => oq.CategoriesCatalog)
                .WithMany(oq => oq.OptionQuestions)
                .HasForeignKey(oq => oq.OptionCatalogId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_OptionQuestions_CategoriesCatalog");

            builder.HasOne(oq => oq.Questions)
                .WithMany(oq => oq.OptionQuestions)
                .HasForeignKey(oq => oq.OptionQuestionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_OptionQuestions_Questions");

            builder.HasOne(oq => oq.SubQuestions)
                .WithMany(oq => oq.OptionQuestions)
                .HasForeignKey(oq => oq.SubquestionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_OptionQuestions_SubQuestions");

            builder.Property(oq => oq.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()")
                .HasColumnType("timestamp");

            builder.Property(oq => oq.CommentOptionRes)
                .HasColumnName("comment_optionres")
                .HasColumnType("text");

            builder.Property(oq => oq.NumberOption)
                .HasColumnName("numberoption")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);
        }
    }
}