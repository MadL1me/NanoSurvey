using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Domain
{
    [Table("Results")]
    public class Result
    {
        [Column("Id")]
        public int? Id { get; set; }
        [Column("InterviewId")]
        public int InterviewId { get; set; }
        [Column("AnswerId")]
        public int AnswerId { get; set; }
        [Column("QuestionId")]
        public int QuestionId { get; set; }
        
        public Interview Interview { get; set; }
    }
}