using Model.DTOs;
using Model.Entities;

namespace BAL.IServices
{
    public interface IUserServices
    {
        Task CreateUser(CreateUserDTOs inputModel);
        Task<string> LoginUser(LoginUserDTOs inputModel);
        Task<IEnumerable<CreateUserDTOs>> GetAllUsers();
        Task<Users> GetUserById(Guid id);
        Task UpdateUser(UpdateUserDTOs inputModel);
        Task DeleteUser(Guid id);

    }
}
