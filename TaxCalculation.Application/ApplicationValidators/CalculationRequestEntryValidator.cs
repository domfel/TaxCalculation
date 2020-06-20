using System;
using System.Linq;
using FluentValidation;
using TaxCalculation.Application.ApplicationModel;

namespace TaxCalculation.Application.ApplicationValidators
{
    public class CalculationRequestEntryValidator : AbstractValidator<CalculationRequestEntry>
    {
        public CalculationRequestEntryValidator()
        {
            RuleFor(x => x.BasePrice)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.ItemName)
                .NotEmpty();

            RuleFor(x => x.TaxRateId)
                .NotEmpty()
                .Must(r => Enum.GetValues(typeof(TaxRate)).Cast<TaxRate>().Any(c => (int) c == r));
        }
    }
}
