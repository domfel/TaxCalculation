using System;
using System.Collections.Generic;
using System.Text;

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
            BasePrice = new MonateryValue(basePrice, Currnecy.PLN);
            Tax = new MonateryValue(tax, Currnecy.PLN);
            PriceWithTax = new MonateryValue(priceWithTax, Currnecy.PLN);
        }

        /// <summary>
        /// Parameter less constructor
        /// </summary>
        public PriceWithTaxes()
        {
            BasePrice = new MonateryValue(0,Currnecy.PLN);
            Tax = new MonateryValue(0, Currnecy.PLN); ;
            PriceWithTax = new MonateryValue(0, Currnecy.PLN);
        }

        /// <summary>
        /// Price without tax
        /// </summary>
        public MonateryValue BasePrice { get; set; }

        /// <summary>
        /// Tax value
        /// </summary>
        public MonateryValue Tax { get; set; }

        /// <summary>
        /// Price with tax
        /// </summary>
        public MonateryValue PriceWithTax { get; set; }
    }
}
