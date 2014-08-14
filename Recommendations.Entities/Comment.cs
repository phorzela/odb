using System.ComponentModel.DataAnnotations;

namespace Recommendations.Entities
{
    public class Comment : Entity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Details { get; set; }

        public Film Film { get; set; }
    }
}