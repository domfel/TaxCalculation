using System;
using System.Collections.Generic;
using System.Linq;
using TaxCalculation.Application.ApplicationModel;
using TaxCalculationUtilities.Handlers;

namespace TaxCalculation.Application
{

    public class GetTaxRatesQueryHandler : IQueryHandler<TaxRateRequest, IEnumerable<TaxRateResponse>>
    {
       
        public IEnumerable<TaxRateResponse> Execute(TaxRateRequest request)
        {
            return Enum.GetValues(typeof(TaxRate))
                .Cast<TaxRate>()
                .Select(x => new TaxRateResponse() { Name = x.ToString(), Id = (int)x });
        }
    }
}
