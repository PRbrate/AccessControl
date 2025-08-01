using AccessControl.Core.Entities;
using AccessControl.Domain.Entites.Enums;
using ControleDeAcesso.Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace AccessControl.Domain.Entites
{
    public class User : IdentityUser
    {
        public long ContaId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public UserType UserType { get; set; }
        public Status Status { get; set; } = Status.Active;
       public IEnumerable<EventDomain> Events { get; set; } = new List<EventDomain>();
    }
}
