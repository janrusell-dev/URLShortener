using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace URLShortener.Model
{
    public class Url
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string url  { get; set; }
        [Column(TypeName = "text")]
        public string? shortenUrl { get; set; }
        public DateTime createdAt { get; set; } = DateTime.UtcNow;
        public DateTime updatedAt { get; set; } = DateTime.UtcNow;
        public int accessCount { get; set; } = 0;
    }
}
