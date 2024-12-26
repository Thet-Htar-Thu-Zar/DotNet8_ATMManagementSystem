using BAL.IServices;
using Model.DTOs;
using Model.Entities;
using Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateUser(CreateUserDTOs inputModel)
        {
            try
            {
                var createUser = new Users()
                {
                    UserName = inputModel.UserName,
                    Password = inputModel.Password,
                    Amount = inputModel.Amount,
                    CreatedBy = inputModel.CreatedBy,
                };
                await _unitOfWork.User.Add(createUser);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
