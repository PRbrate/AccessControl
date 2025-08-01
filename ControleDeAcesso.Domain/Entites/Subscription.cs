using AccessControl.Core.Entities;

namespace AccessControl.Domain.Entites
{
    public class Subscription : Entity
    {
        public bool Status { get; set; }
        public string PriceId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
