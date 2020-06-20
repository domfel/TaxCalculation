using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TaxCalculation.Application.ApplicationModel;
using TaxCalculationUtilities.Handlers;

namespace TaxCalculation.Controllers
{
    /// <summary>
    /// Exposes methods for obtaining dictionary values used in API 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DictionariesController : ControllerBase
    {
        private readonly RequestExecutor<TaxRateRequest, IEnumerable<TaxRateResponse>> _taxRatesExecutor;

        public DictionariesController(
            RequestExecutor<TaxRateRequest, IEnumerable<TaxRateResponse>> taxRatesExecutor)
        {
            _taxRatesExecutor = taxRatesExecutor;
        }

        /// <summary>
        /// Retries all possible tax rates
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/TaxRates")]
        public IActionResult TaxRates()
        {
            return _taxRatesExecutor.Execute(new TaxRateRequest());
        }

    }
}