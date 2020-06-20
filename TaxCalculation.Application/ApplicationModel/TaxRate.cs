namespace TaxCalculation.Application.ApplicationModel
{
    /// <summary>
    /// Enum containing possible tax rates
    /// </summary>
    public enum TaxRate
    {
        /// <summary>
        /// tax rate 0%
        /// </summary>
        Exempt = 1,
        
        /// <summary>
        ///  Reduced tax rate 5%
        /// </summary>
        Reduced5 =2,

        /// <summary>
        /// Reduced Tax rate 8%
        /// </summary>
        Reduced8 = 3,

        /// <summary>
        /// Base tax rate 23%
        /// </summary>
        Standard = 4,
    }
}