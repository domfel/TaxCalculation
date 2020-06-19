using System;
using System.Collections.Generic;
using TaxCalculation.Application.ApplicationModel;
using TaxCalculation.Domain;
using TaxCalculation.Domain.Models;

namespace TaxCalculation.Application
{
    public class TaxCalculationHandler
    {
        private readonly IPolishVATTaxCalculator _taxCalculator;

        public TaxCalculationHandler(IPolishVATTaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        public IEnumerable<CalculationRequestResponse> Execute(IEnumerable<CalculationRequestEntry> entries)
        {
            foreach (var item in entries)
            {
                switch (item.TaxRate)
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

        private CalculationRequestResponse MapToResponse(Func<decimal, PriceWithTaxes> calculationMethod, CalculationRequestEntry calculationEntry)
        {
            try
            {
                var calulationResult = calculationMethod.Invoke(calculationEntry.BasePrice.Value);
                return new CalculationRequestResponse()
                {
                    ItemName = calculationEntry.ItemName,
                    PriceWithTax = calulationResult.PriceWithTax.DisplayValue(),
                    Tax = calulationResult.Tax.DisplayValue(),
                    BasePrice = calulationResult.BasePrice.DisplayValue()
                };
            }
            catch (ArgumentOutOfRangeException e)
            {
                return new CalculationRequestResponse()
                {
                    ItemName = calculationEntry.ItemName,
                    Error = "Cannot calculate taxes for this set of values"
                }; 
            }
        }
    }
}
