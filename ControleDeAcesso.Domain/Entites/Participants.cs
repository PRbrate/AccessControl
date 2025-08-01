using AccessControl.Core.Entities;

namespace ControleDeAcesso.Domain.Entites
{
    public class Participants : Entity
    {
        public Participants()
        {

        }

        public Participants(Guid id, long contaId, string name)
        {
            Id = id;
            ContaId = contaId;
            Name = name;
        }
        public string Name { get; set; }

        public Guid UserId { get; set; }
        
        public UserEvent UserEvent { get; set; }
    }
}
