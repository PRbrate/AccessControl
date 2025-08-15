using AccessControl.Application.Dto;
using AccessControl.Core.Entities;

namespace AccessControl.Application.Services.Interfaces
{
    public interface IEventDomainService
    {
        Task<Response<EventDomainDto>> CreateEventDomain(EventDomainDto eventDomainDto);
        Task<bool> DeleteService(Guid eventDomain);
        Task<List<EventDomainDto>> GetAllEventDomainAsync();
        Task<EventDomainDto> GetEventDomain(Guid id);
        Task<bool> UpdateEvent(EventDomainDto eventDomainDto);
        Task<bool> UpdatePhotoEvent(Guid eventId, string photoName);
    }
}
