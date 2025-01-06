using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Repo.Repositories.IRepositories
{
    public interface ITransactionRepository : IGenericRepository<Transactions>
    {
    }
}
