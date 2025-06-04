using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Chapters
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int SurveyId { get; set; }
        public Surveys Survey { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ComponentHTML { get; set; }
        public string ComponentReact { get; set; }
        public string ChapterNumber { get; set; }
        public string ChapterTitle { get; set; }
        public ICollection<Questions> Questions { get; set; }
    }
}