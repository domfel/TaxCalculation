using System;
using System.Collections.Generic;
using System.Linq;
using TaxCalculation.Application.ApplicationModel;
using TaxCalculation.Domain.Models;

namespace TaxCalculation.Application
{
    public class GetCurrenciesHandler
    {
        public GetCurrenciesHandler()
        {
            
        }

        public IEnumerable<CurreciesResponse> Execute(CurrenciesRequest request)
        {
            return Enum.GetValues(typeof(Currnecy))
                .Cast<Currnecy>()
                .Select(x => new CurreciesResponse() {Code = x.ToString(), Id = (int) x});
        }

    }
}
