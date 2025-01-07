using Model.DTOs;
using Model.Entities;

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
