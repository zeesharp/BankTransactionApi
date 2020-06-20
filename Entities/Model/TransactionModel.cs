using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Enum.TransactionEnum;

namespace Entities.Model
{
    public class TransactionModel
    {
        public Guid TransactionReferenceNumber { get; set; }
        public CurrencyCodeEnum CurrencyCode {get;set;}
        public CountryCodeEnum CountryCode { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string BankReceiptNumber { get; set; }
        public string PayerAccountNumber { get; set; }
        public string PayerAccountBSB { get; set; }
    
    }
}
