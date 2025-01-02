using BAL.IServices;
using Microsoft.AspNetCore.Mvc;
using Model.ApplicationConfig;
using Model.DTOs;
using Model.Entities;
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

        [HttpGet("GetAllUsers")]
        public async Task <IActionResult> GetAllUsers()
        {
            try
            {
                var userList = await _userServices.GetAllUsers();
                var activeUsers = userList.Where(p => p.ActiveFlag == true).ToList();

                return Ok(new ResponseModel { Message = "Display Sucessfully", status = APIStatus.Successful, Data = activeUsers });

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, status = APIStatus.Error });

            }
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var users = await _userServices.GetUserById(id);

                return Ok(new ResponseModel { Message = "User Record display successfully", status = APIStatus.Successful, Data = users });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, status = APIStatus.Error });
            }
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserDTOs inputModel)
        {
            try
            {
                await _userServices.UpdateUser(inputModel);
                return Ok(new ResponseModel { Message = "Update Sucessfully", status = APIStatus.Successful });

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, status = APIStatus.Error });

            }
        }

        [HttpDelete("DeleteUser")]

        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _userServices.DeleteUser(id);
                return Ok(new ResponseModel { Message = "Delete Sucessfully", status = APIStatus.Successful });

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, status = APIStatus.Error });

            }
        }
    }
}
