using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Infrastructure.data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly TallerSurveyDbContext _context;
        private ICategoriesCatalogRepository _categoriesCatalog;
        private ICategoryOptionsRepository _categoryOption;
        private IChaptersRepository _chapters;
        private IOptionQuestionsRepository _optionQuestion;
        private IOptionsResponseRepository _optionsResponse;
        private IQuestionsRepository _question;
        private ISubQuestionsrepository _subQuestion;
        private ISumaryOptionsRepository _sumaryOption;
        private ISurveysRepository _survey;
        
        private IMemberRepository _member;  
        private IRolRepository _rol;
        private IMemberRolsRepository _memberRols;
        public UnitOfWork(TallerSurveyDbContext context)
        {
            _context = context;
        }
        public ICategoriesCatalogRepository CategoriesCatalogs
        {
            get
            {
                if (_categoriesCatalog == null)
                {
                    _categoriesCatalog = new CategoriesCatalogRepository(_context!);
                }
                return _categoriesCatalog;
            }
        }

        public ICategoryOptionsRepository CategoryOptions
                {
            get
            {
                if (_categoryOption == null)
                {
                    _categoryOption = new CategoryOptionsRepository(_context!);
                }
                return _categoryOption;
            }
        }

        public IChaptersRepository Chapters
        
                {
            get
            {
                if (_chapters == null)
                {
                    _chapters = new ChaptersRepository(_context!);
                }
                return _chapters;
            }
        }

        public IOptionQuestionsRepository OptionQuestions
                {
            get
            {
                if (_optionQuestion == null)
                {
                    _optionQuestion = new OptionQuestionsRepository(_context!);
                }
                return _optionQuestion;
            }
        }

        public IOptionsResponseRepository OptionsResponses
                {
            get
            {
                if (_optionsResponse == null)
                {
                    _optionsResponse = new OptionsResponseRepository(_context!);
                }
                return _optionsResponse;
            }
        }

        public IQuestionsRepository Questions
                {
            get
            {
                if (_question == null)
                {
                    _question = new QuestionsRepository(_context!);
                }
                return _question;
            }
        }

        public ISubQuestionsrepository SubQuestions
                {
            get
            {
                if (_subQuestion == null)
                {
                    _subQuestion = new SubQuestionsRepository(_context!);
                }
                return _subQuestion;
            }
        }

        public ISumaryOptionsRepository SumaryOptions
        
                {
            get
            {
                if (_sumaryOption == null)
                {
                    _sumaryOption = new SumaryOptionsRepository(_context!);
                }
                return _sumaryOption;
            }
        }

        public ISurveysRepository Surveys
        {
            get
            {
                if (_survey == null)
                {
                    _survey = new SurveysRepository(_context!);
                }
                return _survey;
            }
        }

        public IMemberRepository Members
        {
            get
            {
                if (_member == null)
                {
                    _member = new MemberRepository(_context!);
                }
                return _member;
            }
        }
        public IRolRepository Roles
        {
            get
            {
                if (_rol == null)
                {
                    _rol = new RolRepository(_context!);
                }
                return _rol;
            }
        }
        public IMemberRolsRepository memberRols
        {
            get
            {
                if (_memberRols == null)
                {
                    _memberRols = new MemberRolRepository(_context!);
                }
                return _memberRols;
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}