using Model;
using Model.Entities;
using Repo.Repositories.IRepositories;

namespace Repo.Repositories.Repositories
{
    internal class TransactionRepository : GenericRepository<Transactions>, ITransactionRepository
    {
        public TransactionRepository(DataContext context) : base(context) { }
    }
}
