using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recommendations.Entities
{
    public abstract class Entity
    {
        [Key]
        //[Column(TypeName = "NUMBER(8)")]
        public int Id { get; set; }

        [Required]
        public DateTimeOffset CreationDate { get; set; }

        public DateTimeOffset? ModificationDate { get; set; }

        protected Entity()
        {
            CreationDate = DateTimeOffset.Now;
        }
    }
}