using AccessControl.Core;
using AccessControl.Domain.Entites.Enums;
using ControleDeAcesso.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessControl.Domain.Entites
{
    public class User : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ContaId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Photo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public UserType UserType { get; set; }
        public Status Status { get; set; } = Status.Active;
       public IEnumerable<EventDomain> Events { get; set; } = new List<EventDomain>();
    }
}
