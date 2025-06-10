using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Chapters
{
    public class ChaptersDTO
    {
        public int Id { get; set; }
        public string ComponentHTML { get; set; }
        public string ComponentReact { get; set; }
        public string ChapterNumber { get; set; }
        public string ChapterTitle { get; set; }
    }
}