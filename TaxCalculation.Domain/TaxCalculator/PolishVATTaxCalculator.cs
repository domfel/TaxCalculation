using System;
using TaxCalculation.Domain.Models;

namespace TaxCalculation.Domain.TaxCalculator
{
    /// <summary>
    /// Default implementation of Polish VAT Tax calculator
    /// </summary>
    public class PolishVATTaxCalculator : IPolishVATTaxCalculator
    {
        public PriceWithTaxes VATTaxBaseRate(decimal value)
        {
            return CalculateTaxes(value, 0.23M);
        }

        public PriceWithTaxes VATTax8Rate(decimal value)
        {
            return CalculateTaxes(value, 0.08M);
        }

        public PriceWithTaxes VATTax5Rate(decimal value)
        {
            return CalculateTaxes(value, 0.05M);
        }
        public PriceWithTaxes VATTax0Rate(decimal value)
        {
            return CalculateTaxes(value, 0M);
        }


        private PriceWithTaxes CalculateTaxes(decimal baseValue, decimal taxRate)
        {
            if (baseValue < 0)
                throw new ArgumentOutOfRangeException(nameof(baseValue), "Provided value should be grater or equal zero");
            if (taxRate < 0)
                throw new ArgumentOutOfRangeException(nameof(taxRate), "Provided value should be grater or equal zero");

            return new PriceWithTaxes(baseValue, Math.Round(baseValue * taxRate, 2),
                baseValue + Math.Round(baseValue * taxRate, 2));
        }
    }
}
