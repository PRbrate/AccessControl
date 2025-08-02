using AccessControl.Application.Dto;
using AccessControl.Application.MappingsConfig;
using AccessControl.Core;
using AccessControl.Data.Repositories.Interfaces;
using ControleDeAcesso.Domain.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccessControl.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class EventDomainController : ApiControllerBase
    {
        private readonly IEventDomainRepository _eventDomainRepository;

        public EventDomainController(INotifier notifier, IUser appUser, IEventDomainRepository eventDomain) : base(notifier, appUser)
        {
            _eventDomainRepository = eventDomain;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var events = await _eventDomainRepository.GetListAsync();
            return Ok(events);
        }

        [HttpPost]
        public async Task<IActionResult> PostEvent(EventDomainDto eventDomainDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            eventDomainDto.Map();

            var eventDomain = eventDomainDto.Map();


            eventDomain.ContaId = ContaId;
            eventDomain.UserId = _appUser.GetUserId();

            var sucess = await _eventDomainRepository.Create(eventDomain);

            if (!sucess)
            {
                NotifyError("Erro ao criar evento.");
                return CustomResponse();
            }   

            return CustomResponse(eventDomainDto);

        }
    }
}
