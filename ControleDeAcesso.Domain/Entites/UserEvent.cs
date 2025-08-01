using AccessControl.Core.Entities;

namespace ControleDeAcesso.Domain.Entites
{
    public class UserEvent : Entity
    {
        public UserEvent()
        {

        }

        public UserEvent(Guid id, long contaId, string name)
        {
            Id = id;
            ContaId = contaId;
            Name = name;
        }

        public UserEvent(Guid id, long contaId, string name, string email, string password)
        {
            Id = id;
            ContaId = contaId;
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<Participants> Participants { get; set; }


    }
}
