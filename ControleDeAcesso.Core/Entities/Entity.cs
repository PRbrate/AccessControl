using System.ComponentModel.DataAnnotations;

namespace AccessControl.Core.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public Status Status { get; set; } = Status.Active;
        public long ContaId { get; set; }


    }
}
