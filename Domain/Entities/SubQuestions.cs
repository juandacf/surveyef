using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SubQuestions
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int SubQuestionId { get; set; }
        public Questions Question { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string SubquestionNumber { get; set; }
        public string CommentSubquestion { get; set; }
        public string SubQuestionText { get; set; }
        public ICollection<OptionQuestions> OptionQuestions { get; set; }
    }
}