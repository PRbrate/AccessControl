using AccessControl.Core.Entities;

namespace AccessControl.Application.Services.Interfaces
{
    public interface ICloudflareService
    {
        Task<Response<string>> getProfileImage();
        Task<Response<string>> UploadFile();
        Task<Response<List<string>>> UploadFileEvent(string id);
        Task<List<string>> getListImageEvent();
        Task<string> GetFileEvent(string eventId);
    }
}