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
            try
            {
                var events = await _eventDomainService.GetAllEventDomainAsync();
                return Ok(events);
            }
            catch (Exception ex)
            {
                NotifyError("Erro ao buscar os eventos: " + ex.Message);
                return CustomResponse();
            }
        }

        [HttpGet("NextEvent")]
        public async Task<IActionResult> GetNextEvent()
        {
            try
            {
                var events = await _eventDomainService.GetNextEvent();
                return Ok(events);
            }
            catch (Exception ex)
            {
                NotifyError("Erro ao buscar os eventos: " + ex.Message);
                return CustomResponse();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostEvent(EventDomainDto eventDomainDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {

                var sucess = await _eventDomainService.CreateEventDomain(eventDomainDto);

                if (sucess.Errors != null)
                {
                    NotifyError(sucess.Errors);
                    return CustomResponse();
                }

                return CustomResponse(sucess);
            }
            catch (Exception ex)
            {
                NotifyError("Erro ao criar evento: " + ex.Message);
                return CustomResponse();
            }
        }

        [HttpPatch("{id}/uploadphoto")]
        public async Task<IActionResult> UploadPhoto(Guid id, string photoName)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {

                var sucess = await _eventDomainService.UpdatePhotoEvent(id, photoName);

                if (!sucess)
                {
                    NotifyError("não foi possivel atualizar a foto");
                    return CustomResponse();
                }

                return CustomResponse(sucess);
            }
            catch (Exception ex)
            {
                NotifyError("Erro ao atualizar foto: " + ex.Message);
                return CustomResponse();
            }
        }
    }

}
