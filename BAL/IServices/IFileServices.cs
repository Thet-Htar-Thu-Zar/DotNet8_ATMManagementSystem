using Microsoft.AspNetCore.Http;
using Model.Entities;

namespace BAL.IServices
{
    public interface IFileServices
    {
        Task<IEnumerable<Files>> GetAllFiles();
        Task<Uri> FileUpload(IFormFile File);
        //Task<bool> DeleteFile(string fileName);

    }
}
