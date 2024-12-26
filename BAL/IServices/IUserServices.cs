using Model.DTOs;
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
    }
}
