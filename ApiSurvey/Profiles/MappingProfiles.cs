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
namespace ApiSurvey.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Surveys, SurveyDTO>().ReverseMap();
       } 
    }
}