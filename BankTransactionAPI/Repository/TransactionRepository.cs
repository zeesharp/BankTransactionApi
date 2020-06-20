using BankTransactionAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bogus;
using static BankTransactionAPI.Enum.TransactionEnum;

namespace BankTransactionAPI.Repository
{
    public static class TransactionRepository
    {
        //Used Bogus as a data generator tool
        public static Faker<TransactionViewModel> transactionList = new Faker<TransactionViewModel>();
        public static List<TransactionViewModel> GenerateTransactions()
        {

                transactionList
                .RuleFor(o => o.TransactionReferenceNumber, Guid.NewGuid)
                .RuleFor(o => o.CurrencyCode, f => f.PickRandom<CurrencyCodeEnum>())
                .RuleFor(o => o.CountryCode, f => f.PickRandom<CountryCodeEnum>())
                .RuleFor(o => o.PaymentAmount, f => f.Finance.Amount(0, 10000))
                .RuleFor(o => o.TransactionDate, f => f.Date.Past(1).Date)
                .RuleFor(c => c.BankReceiptNumber, Guid.NewGuid().ToString("n").Substring(0, 5))
                .RuleFor(c => c.PayerAccountNumber, Guid.NewGuid().ToString("n").Substring(0, 6))
                .RuleFor(c => c.PayerAccountBSB, Guid.NewGuid().ToString("n").Substring(0, 7));

            return transactionList.Generate(1000);
        }
    }
    public static class EnumExtensions
    {
        public static System.Enum GetRandomEnumValue(this Type t)
        {
            return System.Enum.GetValues(t)          // get values from Type provided
                .OfType<System.Enum>()               // casts to Enum
                .OrderBy(e => Guid.NewGuid()) // mess with order of results
                .FirstOrDefault();            // take first item in result
        }
    }

}