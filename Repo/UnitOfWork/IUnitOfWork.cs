using Repo.Repositories.IRepositories;

namespace Repo.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User {  get; }
        IFileRepository StoreFile { get; }
        ITransactionRepository AllTransactions { get; }
        Task<int> SaveChangesAsync();
    }
}
