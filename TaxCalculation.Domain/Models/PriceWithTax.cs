namespace TaxCalculation.Domain.Models
{
    /// <summary>
    /// Represents the result of tax calculation
    /// </summary>
    public class PriceWithTaxes
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="basePrice"></param>
        /// <param name="tax"></param>
        /// <param name="priceWithTax"></param>
        public PriceWithTaxes(decimal basePrice, decimal tax, decimal priceWithTax)
        {
            BasePrice = new MonetaryValue(basePrice, Currency.PLN);
            Tax = new MonetaryValue(tax, Currency.PLN);
            PriceWithTax = new MonetaryValue(priceWithTax, Currency.PLN);
        }

        /// <summary>
        /// Price without tax
        /// </summary>
        public MonetaryValue BasePrice { get; set; }

        /// <summary>
        /// Tax value
        /// </summary>
        public MonetaryValue Tax { get; set; }

        /// <summary>
        /// Price with tax
        /// </summary>
        public MonetaryValue PriceWithTax { get; set; }
    }
}
