using Azure.Storage;
using Azure.Storage.Blobs;
using BAL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Model.Entities;
using Repo.UnitOfWork;

namespace BAL.Services
{
    public class FileServices : IFileServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BlobContainerClient _fileContainer;
        public FileServices(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            var credential = new StorageSharedKeyCredential(configuration["AppSettings:AzureStorageAccountName"], configuration["AppSettings:AzureAccessKey"]);
            var blobUri = $"https://{configuration["AppSettings:AzureStorageAccountName"]}.blob.core.windows.net";
            var blobServiceClient = new BlobServiceClient(new Uri(blobUri), credential);
            _fileContainer = blobServiceClient.GetBlobContainerClient(configuration["AppSettings:AzureContainer"]);
        }
        public async Task<Uri> FileUpload(IFormFile File)
        {
            try
            {
                var newfileName = Path.GetFileNameWithoutExtension(File.FileName) + "_" + System.Guid.NewGuid().ToString() + Path.GetExtension(File.FileName);
                var blobClient = _fileContainer.GetBlobClient(newfileName);
                using (var stream = File.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream);
                }

                var file = new Files()
                {
                    FileName = newfileName,
                    Uri = blobClient.Uri.AbsoluteUri,
                    Content_Type = File.ContentType,
                };

                await _unitOfWork.StoreFile.Create(file);
                await _unitOfWork.SaveChangesAsync();

                return blobClient.Uri;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Files>> GetAllFiles()
        {
            try
            {
                var files = await _unitOfWork.StoreFile.GetByCondition(x => x.ActiveFlag == true);
                return files;
            }
            catch
            {
                throw;
            }
        }

        
    }
}
