using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SumaryOptions
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public Surveys Survey { get; set; }
        public string CodeNumber { get; set; }
        public int QuestionId { get; set; }
        public string Valuerta { get; set; }
    }
}