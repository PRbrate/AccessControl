using AccessControl.Application.Dto;
using AccessControl.Application.Services.Interfaces;
using AccessControl.Core;
using AccessControl.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccessControl.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class EventDomainController : ApiControllerBase
    {
        private readonly IEventDomainService _eventDomainService;

        public EventDomainController(INotifier notifier, IUser appUser, IEventDomainService eventDomain) : base(notifier, appUser)
        {
            _eventDomainService = eventDomain;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var events = await _eventDomainService.GetAllEventDomainAsync();
            return Ok(events);
        }

        [HttpPost]
        public async Task<IActionResult> PostEvent(EventDomainDto eventDomainDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);


            var sucess = await _eventDomainService.CreateEventDomain(eventDomainDto);

            if (!sucess)
            {
                NotifyError("Erro ao criar evento.");
                return CustomResponse();
            }

            return CustomResponse(eventDomainDto);

        }
    }
}
