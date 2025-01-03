using BAL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.ApplicationConfig;
using static Model.ApplicationConfig.ResponseModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ATMManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
