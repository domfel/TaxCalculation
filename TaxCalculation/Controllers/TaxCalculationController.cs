using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxCalculation.Application;
using TaxCalculation.Application.ApplicationModel;

namespace TaxCalculation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxCalculationController : ControllerBase
    {
        private readonly TaxCalculationHandler _handler;

        public TaxCalculationController(TaxCalculationHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Returns taxes calculation base on provided input
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CalculateTaxes(IEnumerable<CalculationRequestEntry> request)
        {
           
            return Ok(_handler.Execute(request));
        }
    }
}