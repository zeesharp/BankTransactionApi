using BankTransactionAPI.Contract;
using BankTransactionAPI.Repository;
using BankTransactionAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static BankTransactionAPI.Enum.TransactionEnum;

namespace BankTransactionAPI.Controllers
{
    // [Authorize]
    public class TransactionController : ApiController
    {

        IGenericDetails td = new TransactionRepositoryDetails();
        List<TransactionViewModel> allTransactions = TransactionRepositoryDetails.transactionList;
        
        [HttpGet]
        public HttpResponseMessage GetAllTransaction()
        {
            return Request.CreateResponse(HttpStatusCode.OK, allTransactions.OfType<TransactionViewModel>());
        }

        [HttpGet]
        public HttpResponseMessage GetTransactionDetailByTransactionId(Guid id)
        {
            var transactionObj = allTransactions.Where(t => t.TransactionReferenceNumber == id).FirstOrDefault();
            if (transactionObj != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, transactionObj);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [HttpGet]
        public HttpResponseMessage GetTransactionDetailByAccountNoAndAccountBSB(string accountNumber, string accountBsb)
        {
            var transactionObj = allTransactions.Where(t => t.PayerAccountNumber == accountNumber && t.PayerAccountBSB == accountBsb).FirstOrDefault();
            if (transactionObj != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, transactionObj);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [HttpGet]
        public HttpResponseMessage GetTotalAmountByTransactionDate(DateTime transactionDate)
        {
            var selectedTransactions = allTransactions.Where(t => t.TransactionDate == transactionDate).ToList();
            if (selectedTransactions.Any())
            {
                var summaryApproach1 = selectedTransactions.GroupBy(t => t.TransactionDate)
                           .Select(t => new
                           {
                               TransactionDate = t.Key,
                               TransactionCount = t.Count(),
                               PaymentAmount = t.Sum(ta => ta.PaymentAmount),
                           }).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, summaryApproach1);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [HttpPost]
        public HttpResponseMessage AddNewTransaction(TransactionViewModel model)
        {
            if (model != null)
            {
                model = new TransactionViewModel
                {
                    TransactionReferenceNumber = model.TransactionReferenceNumber,
                    CurrencyCode = model.CurrencyCode,
                    CountryCode = model.CountryCode,
                    PaymentAmount = model.PaymentAmount,
                    TransactionDate = model.TransactionDate,
                    BankReceiptNumber = model.BankReceiptNumber,
                    PayerAccountNumber = model.PayerAccountNumber,
                    PayerAccountBSB = model.PayerAccountBSB
                };
                allTransactions.Add(model);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage DeleteTransaction(Guid id)
        {
            var selectedTransaction = allTransactions.Where(t => t.TransactionReferenceNumber == id).FirstOrDefault();
            if (selectedTransaction != null)
            {
                allTransactions.Remove(selectedTransaction);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}

