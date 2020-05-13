using ProjectManager.Models;
using System.Collections.Generic;

namespace ProjectManager.Api.Test.TestData
{
    public static class Indications
    {
        public static List<Indication> IndicationsList = new List<Indication>
        {
           new Indication { ID = 1, Value = "Acute Lymphoblastic Leukemia(ALL)" },
           new Indication { ID = 2, Value = "Adrenocortical Carcinoma" }
        };
    }
}