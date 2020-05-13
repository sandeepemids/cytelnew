using ProjectManager.Models;
using System.Collections.Generic;

namespace ProjectManager.Api.Test.TestData
{
    public static class Currencies
    {
        public static List<Currency> CurrencyList = new List<Currency>
        {
            new Currency { ID = 1, Value = "USD" },
            new Currency { ID = 2, Value = "AUD" }
        };
    }
}