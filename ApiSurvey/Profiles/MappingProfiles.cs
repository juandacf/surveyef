using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Domain.Entities;
using Application.DTOs;
using Application.DTOs.Survey;
using Application.DTOs.SumaryOptions;
using Application.DTOs.SubQuestions;
using Application.DTOs.Questions;
using Application.DTOs.OptionsResponse;
using Application.DTOs.OptionQuestions;
using Application.DTOs.Chapters;
using Application.DTOs.CategoryOptions;
using Application.DTOs.CategoriesCatalog;
namespace ApiSurvey.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Surveys, SurveyDTO>().ReverseMap();
            CreateMap<SumaryOptions, SumaryOptionsDTO>().ReverseMap();
            CreateMap<SubQuestions, SubQuestionsDTO>().ReverseMap();
            CreateMap<Questions, QuestionsDTO>().ReverseMap();
            CreateMap<OptionsResponse, OptionsResponseDTO>().ReverseMap();
            CreateMap<OptionQuestions, OptionQuestionsDTO>().ReverseMap();
            CreateMap<Chapters, ChaptersDTO>().ReverseMap();
            CreateMap<CategoryOptions, CategoryOptionsDTO>().ReverseMap();
            CreateMap<CategoriesCatalog, CategoriesCatalogDTO>().ReverseMap();
       } 
    }
}