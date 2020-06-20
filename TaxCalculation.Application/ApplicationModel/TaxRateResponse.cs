namespace TaxCalculation.Application.ApplicationModel
{
    /// <summary>
    /// Response entry for tax rates dictionary
    /// </summary>
    public class TaxRateResponse
    {
        /// <summary>
        /// Tax rate name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Tax rate id
        /// </summary>
        public int Id { get; set; }
    }
}
