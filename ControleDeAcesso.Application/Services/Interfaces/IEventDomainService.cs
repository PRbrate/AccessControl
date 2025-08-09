using AccessControl.Application.Dto;

namespace AccessControl.Application.Services.Interfaces
{
    public interface IEventDomainService
    {
        Task<bool> CreateEventDomain(EventDomainDto eventDomainDto);
        Task<bool> DeleteService(Guid eventDomain);
        Task<List<EventDomainDto>> GetAllEventDomainAsync();
        Task<EventDomainDto> GetEventDomain(Guid id);
        Task<bool> UpdateEvent(EventDomainDto eventDomainDto);
    }
}
