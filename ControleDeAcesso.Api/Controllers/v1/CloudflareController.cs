using AccessControl.Application.Services.Interfaces;
using AccessControl.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccessControl.Api.Controllers.v1
{

    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CloudflareController : ApiControllerBase
    {
        private readonly ICloudflareService _cloudflareService;

        public CloudflareController(
            ICloudflareService cloudflare,
            INotifier notifier,
            IUser user
            ) : base(notifier, user)
        {
            _cloudflareService = cloudflare;
        }

        [HttpGet("urlget")]
        public async Task<ActionResult> get()
        {

            var url = await _cloudflareService.GetCloudflareTokenAsync();

            return CustomResponse(url);
        }


        [HttpPut("urlUpload")]
        public async Task<ActionResult> Upload()
        {
            try
            {

                var url = await _cloudflareService.UploadFile();

                return CustomResponse(url);
            }
            catch (Exception err)
            {
                NotifyError(err.Message);
                return CustomResponse();
            }
        }
        [HttpPut("urlUploadEvent")]
        public async Task<ActionResult> UploadEvent(string idEvent)
        {
            try
            {

                var url = await _cloudflareService.UploadFileEvent(idEvent);

                return CustomResponse(url);
            }
            catch (Exception err)
            {
                NotifyError(err.Message);
                return CustomResponse();
            }

        }
    }
}