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

        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            var lst = await _unitOfWork.User.GetByCondition(x => x.ActiveFlag == true);

            if(lst == null || !lst.Any())
            {
                throw new Exception("No active user list...");
            }
            return lst;
        }

        public async Task<Users> GetUserById(Guid id)
        {
            try
            {
                var userlst = (await _unitOfWork.User.GetByCondition(x => x.UserID == id)).FirstOrDefault();

                if (userlst is null)
                {
                    throw new Exception("Sale report doesn't exist....");
                }
                if (userlst.ActiveFlag != true)
                {
                    throw new Exception("Sale report doesn't exist....");

                }

                return userlst;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
