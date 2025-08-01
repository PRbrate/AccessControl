using AccessControl.Core.Entities;

namespace ControleDeAcesso.Domain.Entites
{
    public class EventDomain : Entity
    {
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


    }
}
