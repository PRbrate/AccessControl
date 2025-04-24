using System.ComponentModel.DataAnnotations;

namespace AccessControl.Core.Base
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id;
    }
}
