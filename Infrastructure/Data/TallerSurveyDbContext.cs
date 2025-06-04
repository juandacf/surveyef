using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;  //Se debenimportar las entidades para incluirlas.
using System.Reflection; 

namespace Infrastructure.data
{
    public class TallerSurveyDbContext: DbContext
    {

        public TallerSurveyDbContext (DbContextOptions<TallerSurveyDbContext> options) : base(options)
        {

        }
        public DbSet<CategoriesCatalog> CategoriesCatalogs { get; set; }
        public DbSet<CategoryOptions> CategoryOptions { get; set; }
        public DbSet<Chapters> Chapters { get; set; }
        public DbSet<OptionsResponse> OptionsResponses { get; set; }
        public DbSet<Surveys> Surveys { get; set; }
        public DbSet<OptionQuestions> OptionQuestions { get; set; }
        public DbSet<SubQuestions> SubQuestions { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<SumaryOptions> SumaryOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Para usar  Assembly.GetExecutingAssembly() se necesita using System.Reflection;
        }
    }
}