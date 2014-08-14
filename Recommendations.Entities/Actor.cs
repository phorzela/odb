using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recommendations.Entities
{
    public class Actor : Entity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public ICollection<Film> Films { get; set; }
    }
}