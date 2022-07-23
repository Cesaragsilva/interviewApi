using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interview.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity() { }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public void Created() => CreatedAt = DateTime.Now;
        public void Updated() => UpdatedAt = DateTime.Now;
    }
}
