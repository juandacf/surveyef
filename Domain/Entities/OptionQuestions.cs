using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OptionQuestions
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int OptionId { get; set; }
        public OptionsResponse Optionresponse { get; set; }
        public int OptionCatalogId { get; set; }
        public CategoriesCatalog CategoriesCatalog { get; set; }
        public int OptionQuestionId { get; set; }
        public Questions Questions { get; set; }
        public int SubquestionId { get; set; }
        public SubQuestions SubQuestions { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CommentOptionRes { get; set; }
        public string NumberOption { get; set; }
    }
}