using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.SubQuestions
{
    public class SubQuestionsDTO
    {
        public int Id { get; set; }
        public string SubquestionNumber { get; set; }
        public string CommentSubquestion { get; set; }
        public string SubQuestionText { get; set; }
    }
}