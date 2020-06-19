using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculation.Domain.Models
{
    /// <summary>
    /// Reresents monetary values like prices
    /// </summary>
    public class MonateryValue
    {
        private decimal _amout;
        private Currnecy _currnecy;

        public MonateryValue(decimal amout, Currnecy currnecy)
        {
            _currnecy = currnecy;
            _amout = amout;
        }


        public string DisplayValue() => $"{_amout} {_currnecy}";

        public decimal GetAmount() => _amout;




    }
}
