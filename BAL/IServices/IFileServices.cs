using Microsoft.AspNetCore.Http;
using Model.DTOs;
using Model.Entities;

namespace BAL.IServices
{
    public interface IFileServices
    {
        Task<IEnumerable<Files>> GetAllFiles();
        Task<Uri> FileUpload(IFormFile File);
        Task DeleteFile(string fileName);
        Task<FileResponseDTOs> DownloadFile(string fileName);
    }
}
