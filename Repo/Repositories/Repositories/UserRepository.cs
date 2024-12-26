using Model;
using Model.Entities;
using Repo.Repositories.IRepositories;

namespace Repo.Repositories.Repositories
{
    internal class UserRepository : GenericRepository<Users>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext) { }
    }
}
