using AccessControl.Core.Entities;

namespace AccessControl.Application.Services.Interfaces
{
    public interface ICloudflareService
    {
        Task<Response<string>> GetCloudflareTokenAsync();
        Task<Response<string>> UploadFile();
        Task<Response<string>> UploadFileEvent(string eventName);
    }
}