namespace TaxCalculation.Domain.Models
{
    /// <summary>
    /// Represents monetary values like prices
    /// </summary>
    public class MonetaryValue
    {
        private readonly decimal _amount;
        private readonly Currency _currency;

        public MonetaryValue(decimal amount, Currency currency)
        {
            _currency = currency;
            _amount = amount;
        }


        public string DisplayValue() => $"{_amount} {_currency}";
    }
}
