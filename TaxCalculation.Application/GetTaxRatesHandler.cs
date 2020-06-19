using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxCalculation.Application.ApplicationModel;
using TaxCalculation.Domain.Models;

namespace TaxCalculation.Application
{

    public class GetTaxRatesHandler
    {
       
        public IEnumerable<TaxRateResponse> Execute(TaxRateRequest request)
        {
            return Enum.GetValues(typeof(TaxRate))
                .Cast<TaxRate>()
                .Select(x => new TaxRateResponse() { Name = x.ToString(), Id = (int)x });
        }
    }
}
