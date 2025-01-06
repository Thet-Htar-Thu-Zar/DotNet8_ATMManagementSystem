using AutoMapper;
using BAL.IServices;
using Model.DTOs;
using Model.Entities;
using Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class TransactionServices : ITransactionServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Transactions>> GetAllTransactions()
        {
            try
            {
                var lst = await _unitOfWork.AllTransactions.GetByCondition(x => x.ActiveFlag == true);
                if (lst == null || !lst.Any())
                {
                    throw new Exception("No active transaction list...");
                }
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Deposit(CreateTransactionDTOs inputModel)
        {
            try
            {
                var user = (await _unitOfWork.User.GetByCondition(x => x.UserID == inputModel.UserID)).FirstOrDefault();

                if (user is null)
                {
                    throw new Exception("user don't find");
                }
                user.Amount += Convert.ToDecimal(inputModel.TransactionAmount);
                var Transaction = new Transactions
                {
                    UserID = inputModel.UserID,
                    TransactionType = "Deposit",
                    TransactionAmount = Convert.ToDecimal(inputModel.TransactionAmount),
                };

                await _unitOfWork.AllTransactions.Add(Transaction);
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task Withdraw(CreateTransactionDTOs inputModel)
        {
            try
            {
                var user = (await _unitOfWork.User.GetByCondition(x => x.UserID == inputModel.UserID)).FirstOrDefault();

                if (user is null)
                {
                    throw new Exception("user don't find");
                }
                user.Amount -= Convert.ToDecimal(inputModel.TransactionAmount);
                var Transaction = new Transactions
                {
                    UserID = inputModel.UserID,
                    TransactionType = "Withdraw",
                    TransactionAmount = Convert.ToDecimal(inputModel.TransactionAmount),
                };

                await _unitOfWork.AllTransactions.Add(Transaction);
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Transactions>> GetTransactionsById(Guid UserId)
        {
            try
            {
                var transactionlst = await _unitOfWork.AllTransactions.GetByCondition(x => x.UserID == UserId && x.ActiveFlag == true);

                if (transactionlst is null)
                {
                    throw new Exception("Transaction doesn't exist....");
                }
               
                return transactionlst;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
