using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Questions
{
    public class QuestionsDTO
    {
        public int Id { get; set; }
        public string QuestionNumber { get; set; }
        public string ResponseType { get; set; }
        public string CommentQuestion { get; set; }
        public string Questiontext { get; set; }

    }
}