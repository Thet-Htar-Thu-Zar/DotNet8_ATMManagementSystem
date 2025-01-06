using Asp.Versioning;
using BAL.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.ApplicationConfig;
using static Model.ApplicationConfig.ResponseModel;

namespace ATMManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class FileController : ControllerBase
    {
        private readonly IFileServices _fileServices;
        public FileController(IFileServices fileServices)
        {
            _fileServices = fileServices;
        }

        [HttpPost("UploadFile")]

        public async Task<IActionResult> UploadFile(IFormFile File)
        {
            try
            {
                var data = await _fileServices.FileUpload(File);
                if(data != null)
                {
                return Ok(new ResponseModel { Message = "File Upload Sucessfully", status = APIStatus.Successful, Data = data });
                }
                return Ok(new ResponseModel { Message = Messages.InvalidPostedData, status = APIStatus.Error });

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, status = APIStatus.Error });
            }
        }

        [HttpGet("GetAllFiles")]

        public async Task<IActionResult> GetAllFiles()
        {
            try
            {
                var data = await _fileServices.GetAllFiles();
                if (data != null)
                {
                    return Ok(new ResponseModel { Message = "Sucessfully", status = APIStatus.Successful, Data = data });
                }
                return Ok(new ResponseModel { Message = Messages.InvalidPostedData, status = APIStatus.Error });

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, status = APIStatus.Error });
            }
        }

        [HttpDelete("DeleteFile")]
        public async Task<IActionResult> DeleteFile(string fileName)
        {
            try
            {
                await _fileServices.DeleteFile(fileName);
                return Ok(new ResponseModel { Message = "Sucessfully", status = APIStatus.Successful });

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, status = APIStatus.Error });
            }
        }

        [HttpGet("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            try
            {
                var result = await _fileServices.DownloadFile(fileName);

                if(result is not null)
                {
                    return File(result.Content, result.Content_Type, result.FileName);
                }
                return Ok(new ResponseModel { Message = Messages.ErrorWhileFetchingData , status = APIStatus.Error });

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, status = APIStatus.Error });

            }
        }
    }
}
