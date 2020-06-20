using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Model;
using Bogus;
using static Entities.Enum.TransactionEnum;

namespace Repository
{
    public class TransactionRepository : IRepositoryBase
    {
        public static List<TransactionModel> transactionList = new List<TransactionModel>();
        public static List<TransactionModel> GenerateTransactions()
        {
            var transactionList = new Faker<TransactionModel>()
                .RuleFor(o => o.TransactionReferenceNumber, Guid.NewGuid)
                .RuleFor(o => o.CurrencyCode, f => f.PickRandom<CurrencyCodeEnum>())
                .RuleFor(o => o.CountryCode, f => f.PickRandom<CountryCodeEnum>())
                .RuleFor(o => o.PaymentAmount, f => f.Finance.Amount(0, 10000))
                .RuleFor(o => o.TransactionDate, f => f.Date.Past(3))
                .RuleFor(c => c.BankReceiptNumber, Guid.NewGuid().ToString("n").Substring(0, 5))
                .RuleFor(c => c.PayerAccountNumber, Guid.NewGuid().ToString("n").Substring(0, 6))
                .RuleFor(c => c.PayerAccountBSB, Guid.NewGuid().ToString("n").Substring(0, 7));

            return transactionList.Generate(1000);
        }
    }
}
