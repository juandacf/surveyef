using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class SumaryOptionsConfiguration : IEntityTypeConfiguration<SumaryOptions>
    {
        public void Configure(EntityTypeBuilder<SumaryOptions> builder)
        {
            builder.ToTable("sumary_options");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnName("id");

            builder.Property(s => s.SurveyId)
                .HasColumnName("id_survey")
                .HasColumnType("int");

            builder.Property(s => s.CodeNumber)
                .HasColumnName("codenumber")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder.Property(s => s.QuestionId)
                .HasColumnName("idquestion")
                .HasColumnType("int");

            builder.Property(s => s.Valuerta)
                .HasColumnName("valuerta")
                .HasColumnType("text");
        }
    }
}