using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Questions
    {
        public int Id { get; set; }
        public int ChapterId { get; set; }
        public Chapters Chapter { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string QuestionNumber { get; set; }
        public string ResponseType { get; set; }
        public string CommentQuestion { get; set; }
        public string Questiontext { get; set; }
        public ICollection<OptionQuestions> OptionQuestions { get; set; }
        public ICollection <SubQuestions> SubQuestions { get; set; }
    }
}