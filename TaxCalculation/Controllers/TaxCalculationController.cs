using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxCalculation.Application;
using TaxCalculation.Application.ApplicationModel;
using TaxCalculationUtilities.Handlers;

namespace TaxCalculation.Controllers
{
    /// <summary>
    /// Exposes methods for tax calculation
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaxCalculationController : ControllerBase
    {
        private readonly RequestExecutor<CalculationRequest, IEnumerable<CalculationResponse>> _calculationExecutor;

        public TaxCalculationController(RequestExecutor<CalculationRequest, IEnumerable<CalculationResponse>> calculationExecutor)
        {
            _calculationExecutor = calculationExecutor;
        }

        /// <summary>
        /// Returns taxes calculation base on provided input
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CalculateTaxes(CalculationRequest request)
        {
           
            return _calculationExecutor.Execute(request);
        }
    }
}