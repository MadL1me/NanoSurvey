using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Domain
{
    [Table("Questions")]
    public class Question
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("QuestionText")]
        public string QuestionText { get; set; }
        
        public IEnumerable<Answer> Answers { get; set; }
        public IEnumerable<Survey> Surveys { get; set; }
    }
}