using Microsoft.AspNetCore.Http;

namespace BAL.IServices
{
    public interface IFileServices
    {
        Task<string> FileUpload(IFormFile File);
    }
}
