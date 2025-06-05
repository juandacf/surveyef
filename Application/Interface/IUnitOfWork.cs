using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUnitOfWork
    {
        ICategoriesCatalogRepository CategoriesCatalogs { get; }
        ICategoryOptionsRepository CategoryOptions { get; }
        IChaptersRepository Chapters { get; }
        IOptionQuestionsRepository OptionQuestions { get; }
        OptionsResponseRepository OptionsResponses { get; }
        IQuestionsRepository Questions { get; }
        ISubQuestionsrepository SubQuestions { get; }
        ISumaryOptionsRepository SumaryOptions { get; }
        ISurveysRepository Surveys { get; }
        Task<int> SaveAsync();
    }
}