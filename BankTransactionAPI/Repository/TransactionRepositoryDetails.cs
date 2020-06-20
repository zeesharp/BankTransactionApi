using BankTransactionAPI.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankTransactionAPI.ViewModel;
using System.Collections;

namespace BankTransactionAPI.Repository
{
    public class TransactionRepositoryDetails : IGenericDetails
    {
        public static List<TransactionViewModel> transactionList= new List<TransactionViewModel>();
        
        public TransactionRepositoryDetails()
        {
            if (transactionList.Count() == 0)
            {
                transactionList = TransactionRepository.GenerateTransactions();
            }
        }
        bool IGenericDetails.Delete(TransactionViewModel dt, int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable IGenericDetails.GetAll()
        {
            return transactionList;
        }

        IEnumerable IGenericDetails.GetByTransactionReferenceNumber(Guid transRefNo)
        {
            var result = transactionList.Where(i => i.TransactionReferenceNumber == transRefNo).ToList();

            return result;
        }

        bool IGenericDetails.Insert(TransactionViewModel dt)
        {
            throw new NotImplementedException();
        }

        bool IGenericDetails.Update(TransactionViewModel dt, int id)
        {
            throw new NotImplementedException();
        }
    }
}