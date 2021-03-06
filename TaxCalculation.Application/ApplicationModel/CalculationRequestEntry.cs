﻿namespace TaxCalculation.Application.ApplicationModel
{
    /// <summary>
    /// Single product or service for which the tax should be calculated
    /// </summary>
    public class CalculationRequestEntry
    {
        /// <summary>
        /// Product or service name
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Base price
        /// </summary>
        public decimal? BasePrice { get; set; }
        /// <summary>
        /// Tax rate specific for related product or service
        /// </summary>
        public TaxRate? TaxRate { get; set; }
    }
}
