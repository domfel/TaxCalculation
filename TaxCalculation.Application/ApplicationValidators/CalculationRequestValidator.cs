using FluentValidation;
using TaxCalculation.Application.ApplicationModel;

namespace TaxCalculation.Application.ApplicationValidators
{
    public class CalculationRequestValidator : AbstractValidator<CalculationRequest>
    {
        public CalculationRequestValidator(AbstractValidator<CalculationRequestEntry> entryValidator)
        {
            RuleFor(x => x.Data)
                .NotEmpty();

            RuleForEach(x => x.Data)
                .SetValidator(entryValidator);

        }
    }
}
