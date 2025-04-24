using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControleDeAcesso.Domain.Entites
{
    public class EventDomain
    {
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public int QuantParticipants { get; set; }
        public IEnumerable<Participants> participants { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
