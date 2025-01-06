using Model.DTOs;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
    public interface ITransactionServices
    {
        Task<IEnumerable<Transactions>> GetAllTransactions();
        Task Deposit(CreateTransactionDTOs inputModel);
        Task Withdraw(CreateTransactionDTOs inputModel);
        Task<IEnumerable<Transactions>> GetTransactionsById(Guid UserId);
    }
}
