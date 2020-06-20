using System;
using System.Collections.Generic;
using TaxCalculation.Application.ApplicationModel;
using TaxCalculation.Domain;
using TaxCalculation.Domain.Models;
using TaxCalculationUtilities.Handlers;

namespace TaxCalculation.Application
{
    public class TaxCalculationQueryHandler : IQueryHandler<CalculationRequest, IEnumerable<CalculationResponse>>
    {
        private readonly IPolishVATTaxCalculator _taxCalculator;

        public TaxCalculationQueryHandler(IPolishVATTaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        public IEnumerable<CalculationResponse> Execute(CalculationRequest query)
        {
            foreach (var item in query.Data)
            {
                switch ((TaxRate)item.TaxRateId)
                {
                    case TaxRate.Exempt:
                        yield return MapToResponse(_taxCalculator.VATTax0Rate, item);
                        break;
                    case TaxRate.Reduced5:
                        yield return MapToResponse(_taxCalculator.VATTax5Rate, item);
                        break;
                    case TaxRate.Reduced8:
                        yield return MapToResponse(_taxCalculator.VATTax8Rate, item);
                        break;
                    case TaxRate.Standard:
                        yield return MapToResponse(_taxCalculator.VATTaxBaseRate, item);
                        break;
                }
            }
        }

        private CalculationResponse MapToResponse(Func<decimal, PriceWithTaxes> calculationMethod, CalculationRequestEntry calculationEntry)
        {
            try
            {
                var calulationResult = calculationMethod.Invoke(calculationEntry.BasePrice.Value);
                return new CalculationResponse()
                {
                    ItemName = calculationEntry.ItemName,
                    PriceWithTax = calulationResult.PriceWithTax.DisplayValue(),
                    Tax = calulationResult.Tax.DisplayValue(),
                    BasePrice = calulationResult.BasePrice.DisplayValue()
                };
            }
            catch (ArgumentOutOfRangeException e)
            {
                return new CalculationResponse()
                {
                    ItemName = calculationEntry.ItemName,
                    Error = "Cannot calculate taxes for this set of values"
                }; 
            }
        }
    }
}
