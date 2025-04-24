using AccessControl.Core.Base;

namespace ControleDeAcesso.Domain.Entites
{
    public class Participants : Entity
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
