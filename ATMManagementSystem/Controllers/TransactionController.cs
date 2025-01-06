using Asp.Versioning;
using BAL.IServices;
using BAL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.ApplicationConfig;
using Model.DTOs;
using Repo.UnitOfWork;
using static Model.ApplicationConfig.ResponseModel;

namespace ATMManagementSystem.Controllers
{
    
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class TransactionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionServices _transactionServices;

        public TransactionController(IUnitOfWork unitOfWork, ITransactionServices transactionServices)
        {
            _unitOfWork = unitOfWork;
            _transactionServices = transactionServices;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllTransactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            try
            {
                var lst = await _transactionServices.GetAllTransactions();

                return Ok(new ResponseModel { Message = "Sucessfully", status = APIStatus.Successful, Data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, status = APIStatus.Error });

            }
        }

        [HttpGet("GetTransactionsByUserId")]
        public async Task<IActionResult> GetTransactionsById(Guid UserId)
        {
            try
            {
                var lst = await _transactionServices.GetTransactionsById(UserId);

                return Ok(new ResponseModel { Message = "Sucessfully", status = APIStatus.Successful, Data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, status = APIStatus.Error });

            }
        }
        [Authorize(Roles = "User")]
        [HttpPost("Deposit")]

        public async Task<IActionResult> Deposit(CreateTransactionDTOs inputModel)
        {
            try
            {
                await _transactionServices.Deposit(inputModel);
                return Ok(new ResponseModel { Message = "Deposit Sucessfully", status = APIStatus.Successful });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, status = APIStatus.Error });

            }
        }

        [Authorize(Roles = "User")]
        [HttpPost("Withdraw")]
        public async Task<IActionResult> Withdraw(CreateTransactionDTOs inputModel)
        {
            try
            {
                await _transactionServices.Withdraw(inputModel);
                return Ok(new ResponseModel { Message = "Withdraw Sucessfully", status = APIStatus.Successful });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, status = APIStatus.Error });

            }
        }
    }
}
