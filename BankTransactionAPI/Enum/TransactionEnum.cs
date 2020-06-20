using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BankTransactionAPI.Enum
{
    public static class TransactionEnum
    {
        public enum CurrencyCodeEnum
        {
            [EnumMember(Value = "AUD")]
            AUD,
            [EnumMember(Value = "NZD")]
            NZD
        }
        public enum CountryCodeEnum
        {
            [EnumMember(Value = "AU")]
            AU,
            [EnumMember(Value = "NZ")]
            NZ
        }
    }
}