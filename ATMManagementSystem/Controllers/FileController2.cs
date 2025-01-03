using Asp.Versioning;
using BAL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.ApplicationConfig;
using static Model.ApplicationConfig.ResponseModel;

namespace ATMManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("2")]
    public class FileController2 : ControllerBase
    {
        private readonly IFileServices _fileServices;
        public FileController2(IFileServices fileServices)
        {
            _fileServices = fileServices;
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
    }
}
