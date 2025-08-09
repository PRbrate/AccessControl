using AccessControl.Application.Dto;
using AccessControl.Application.MappingsConfig;
using AccessControl.Application.Services.Interfaces;
using AccessControl.Core;
using AccessControl.Data.Repositories.Interfaces;
using AccessControl.Domain.Validations;

namespace AccessControl.Application.Services
{
    public class EventDomainService : ServiceBase, IEventDomainService
    {
        private readonly IEventDomainRepository _eventDomainRepository;
        private readonly INotifier _notifier;
        private readonly IUser _appUser;

        public EventDomainService(INotifier notifier, IUser appUser, IEventDomainRepository eventDomainRepository) 
            : base(notifier)
        {
            _eventDomainRepository = eventDomainRepository;
            _notifier = notifier;
            _appUser = appUser;
        }


        public async Task<bool> CreateEventDomain(EventDomainDto eventDomainDto)
        {
            var eventDomain = eventDomainDto.Map();
            eventDomain.UserId = _appUser.GetUserId();
            eventDomain.ContaId = _appUser.GetAccountId();

            if(!ExecutarValidacao(new EventDomainValidation(), eventDomain))
            {
                return await Task.FromResult(false);
            }

            return await _eventDomainRepository.Create(eventDomain);
        }

        public async Task<bool> DeleteService(Guid eventDomain)
        {
            var eventDomainEntity = _eventDomainRepository.GetById(eventDomain);

            if (eventDomainEntity == null)
            {
                Notificar("Evento não encontrado.");
                return await Task.FromResult(false);
            }

            await _eventDomainRepository.Delete(eventDomain);

           return await Task.FromResult(true);

        }

        public async Task<List<EventDomainDto>> GetAllEventDomainAsync()
        {
            var getEventDomain = await _eventDomainRepository.GetListAsync();
            return getEventDomain.Map();
        }

        public async Task<EventDomainDto> GetEventDomain(Guid id)
        {
            var eventDomain = await _eventDomainRepository.GetById(id);

            return eventDomain.Map();
        }

        public Task<bool> UpdateEvent(EventDomainDto eventDomainDto)
        {
            throw new NotImplementedException();
        }
    }
}
