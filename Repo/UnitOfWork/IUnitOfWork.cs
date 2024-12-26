using Repo.Repositories.IRepositories;

namespace Repo.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User {  get; }
        Task<int> SaveChangesAsync();
    }
}
