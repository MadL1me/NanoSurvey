using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Domain
{
    [Table("Answers")]
    public class Answer
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("AnswerText")]
        public string AnswerText { get; set; }
        
        public IEnumerable<Question> Questions { get; set; }
    }
}