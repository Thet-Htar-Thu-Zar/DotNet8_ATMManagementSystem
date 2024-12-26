using BAL.IServices;
using Microsoft.AspNetCore.Mvc;
using Model.ApplicationConfig;
using Model.DTOs;
using Repo.UnitOfWork;
using System.Net.NetworkInformation;
using static Model.ApplicationConfig.ResponseModel;

namespace ATMManagementSystem.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserServices _userServices;

        public UserController(IUnitOfWork unitOfWork, IUserServices userServices)
        {
            _unitOfWork = unitOfWork;
            _userServices = userServices;
        }

        [HttpPost("CreateUser")]
        public async Task <IActionResult> CreateUser(CreateUserDTOs inputModel)
        {
            try
            {
                await _userServices.CreateUser(inputModel);
                return Ok(new ResponseModel { Message = "Add Sucessfully", status = APIStatus.Successful });
            }
            
            catch (Exception ex)
            {
               return Ok(new ResponseModel { Message = ex.Message, status = APIStatus.Error }); 
            }
        }
    }
}
