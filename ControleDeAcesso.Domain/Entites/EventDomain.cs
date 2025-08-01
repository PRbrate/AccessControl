using AccessControl.Core.Entities;
using AccessControl.Domain.Entites;

namespace ControleDeAcesso.Domain.Entites
{
    public class EventDomain : Entity
    {
        public EventDomain()
        {
         
        }

        public EventDomain(Guid id, long contaId, string name)
        {
            Id = id;
            ContaId = contaId;
            Name = name;
        }

        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public int QuantParticipants { get; set; }
        public string Image { get; set; }
        public string Description { get; set; } 
        public string Adress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }


    }
}
