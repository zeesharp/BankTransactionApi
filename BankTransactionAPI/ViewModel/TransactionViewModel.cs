using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static BankTransactionAPI.Enum.TransactionEnum;

namespace BankTransactionAPI.ViewModel
{
    public class TransactionViewModel
    {
        public Guid TransactionReferenceNumber { get; set; }
        public CurrencyCodeEnum CurrencyCode { get; set; }
        public CountryCodeEnum CountryCode { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string BankReceiptNumber { get; set; }
        public string PayerAccountNumber { get; set; }
        public string PayerAccountBSB { get; set; }
    }
}