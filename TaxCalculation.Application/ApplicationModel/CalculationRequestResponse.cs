namespace TaxCalculation.Application.ApplicationModel
{
    /// <summary>
    /// Represents an entry of tax calculation results
    /// </summary>
    public class CalculationResponse
    {
        /// <summary>
        /// Product or service name
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Product or service base price
        /// </summary>
        public string BasePrice { get; set; }

        /// <summary>
        /// Tax value
        /// </summary>
        public string Tax { get; set; }

        /// <summary>
        /// Product or service price including tax
        /// </summary>
        public string PriceWithTax { get; set; }

        /// <summary>
        /// ErrorMessage
        /// </summary>
        public string Error { get; set; }
    }
}
