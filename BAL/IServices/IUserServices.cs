﻿using Model.DTOs;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
    public interface IUserServices
    {
        Task CreateUser(CreateUserDTOs inputModel);
        Task<string> LoginUser(LoginUserDTOs inputModel);
        Task<IEnumerable<Users>> GetAllUsers();
        Task<Users> GetUserById(Guid id);
        Task UpdateUser(UpdateUserDTOs inputModel);
        Task DeleteUser(Guid id);

    }
}
