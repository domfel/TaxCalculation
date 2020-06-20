using TaxCalculation.Domain.Models;

namespace TaxCalculation.Domain.TaxCalculator
{
    /// <summary>
    ///  Returns calculated value of taxes for specified Polish VAT tax rates
    /// </summary>
    public interface IPolishVATTaxCalculator
    {
        /// <summary>
        /// Calculate VAT tax for 23% rate
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        PriceWithTaxes VATTaxBaseRate(decimal value);

        /// <summary>
        /// Calculate VAT tax for 8% rate
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        PriceWithTaxes VATTax8Rate(decimal value);

        /// <summary>
        /// Calculate VAT tax for 5% rate
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        PriceWithTaxes VATTax5Rate(decimal value);

        /// <summary>
        /// Calculate VAT tax for 0% rate
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        PriceWithTaxes VATTax0Rate(decimal value);
    }
}