using AccessControl.Application.Dto;
using AccessControl.Domain.Entites;
using ControleDeAcesso.Domain.Entites;

namespace AccessControl.Application.MappingsConfig
{
    public static class AutoMapperEventDomain
    {
        public static EventDomain Map(this EventDomainDto eventDomain) => new()
        {
            Name = eventDomain.Name,
            Description = eventDomain.Description,
            EventDate = eventDomain.EventDate,
            QuantParticipants = eventDomain.QuantParticipants,
            Image = eventDomain.Image,
            Adress = eventDomain.Adress,
            City = eventDomain.City,
            State = eventDomain.State,
            PostalCode = eventDomain.PostalCode
        };

    }
}
