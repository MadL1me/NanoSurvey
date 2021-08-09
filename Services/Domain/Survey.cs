using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Domain
{
    [Table("Surveys")]
    public class Survey
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("SurveyName")]
        public string SurveyName { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}