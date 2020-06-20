using BankTransactionAPI.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankTransactionAPI.Contract
{
    public interface IGenericDetails
    {
        IEnumerable GetAll();

        IEnumerable GetByTransactionReferenceNumber(Guid transRefNo);

        bool Insert(TransactionViewModel dt);

        bool Update(TransactionViewModel dt, int id);

        bool Delete(TransactionViewModel dt, int id);
    }
}