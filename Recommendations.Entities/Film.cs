using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recommendations.Entities
{
    public class Film : Entity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public ICollection<Actor> Actors { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}