using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Domain
{
    [Table("Interviews")]
    public class Interview
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("UserId")]
        public int UserId { get; set; }
        public IEnumerable<Result> Results { get; set; }
    }
}