using FluentValidation;
using TaxCalculation.Application.ApplicationModel;

namespace TaxCalculation.Application.ApplicationValidators
{
    public class TaxRateRequestValidator : AbstractValidator<TaxRateRequest>
    {
        public TaxRateRequestValidator()
        { }
    }
}
