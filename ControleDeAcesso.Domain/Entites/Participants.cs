using AccessControl.Core.Entities;

namespace ControleDeAcesso.Domain.Entites
{
    public class Participants : Entity
    {
        public string Name { get; set; }

        public Guid UserId { get; set; }
    }
}
