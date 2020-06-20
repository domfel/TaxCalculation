using System.Collections.Generic;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TaxCalculation.Application;
using TaxCalculation.Application.ApplicationModel;
using TaxCalculation.Application.ApplicationValidators;
using TaxCalculationUtilities.Handlers;

namespace TaxCalculation
{
    public static class DependencyRegistrations
    {
        public static void AddValidators(this IServiceCollection collection)
        {
            collection.AddTransient<AbstractValidator<CalculationRequestEntry>, CalculationRequestEntryValidator>();
            collection.AddTransient<AbstractValidator<CalculationRequest>, CalculationRequestValidator>();
            collection.AddTransient<AbstractValidator<TaxRateRequest>, TaxRateRequestValidator>();
        }

        public static void AddHandlers(this IServiceCollection collection)
        {
            collection.AddTransient<IQueryHandler<TaxRateRequest, IEnumerable<TaxRateResponse>>, GetTaxRatesQueryHandler>();
            collection.AddTransient<IQueryHandler<CalculationRequest, IEnumerable<CalculationResponse>>, TaxCalculationQueryHandler>();
        }

        public static void AddExecutors(this IServiceCollection collection)
        {
            collection.AddTransient<RequestExecutor<TaxRateRequest, IEnumerable<TaxRateResponse>>>();
            collection.AddTransient<RequestExecutor<CalculationRequest, IEnumerable<CalculationResponse>>>();
        }
    }
}
