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
            MaxPeaples = eventDomain.QuantParticipants,
            Available = eventDomain.Available,
            Image = eventDomain.Image,
            Adress = eventDomain.Adress,
            City = eventDomain.City,
            State = eventDomain.State,
            PostalCode = eventDomain.PostalCode
        };

        public static EventDomainDto Map(this EventDomain eventDomain) => new()
        {
            Name = eventDomain.Name,
            Description = eventDomain.Description,
            EventDate = eventDomain.EventDate,
            QuantParticipants = eventDomain.QuantParticipants,
            Available = eventDomain.Available,
            Image = eventDomain.Image,
            Adress = eventDomain.Adress,
            City = eventDomain.City,
            State = eventDomain.State,
            PostalCode = eventDomain.PostalCode
        };

        public static List<EventDomainDto> Map(this IQueryable<EventDomain> eventDomains) => eventDomains.Select(eventDomain => eventDomain.Map()).ToList();
    }
}
