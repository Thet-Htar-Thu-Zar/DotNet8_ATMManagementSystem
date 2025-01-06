using Model;
using Model.Entities;
using Repo.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repositories.Repositories
{
    internal class TransactionRepository : GenericRepository<Transactions>, ITransactionRepository
    {
        public TransactionRepository(DataContext context) : base(context) { }
    }
}
