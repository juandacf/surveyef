using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Survey
{
    public class SurveyDTO
    {
        public int Id { get; set; }
        public string ComponentHTML { get; set; }
        public string ComponentReact { get; set; }
         public string Name { get; set; }
    }
}