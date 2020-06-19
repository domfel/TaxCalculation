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
    public class DictionariesController : ControllerBase
    {
        private readonly GetCurrenciesHandler _currenciesHandler;
        private readonly GetTaxRatesHandler _taxRatesHandler;

        public DictionariesController(GetCurrenciesHandler currenciesHandler, GetTaxRatesHandler taxRatesHandler)
        {
            _currenciesHandler = currenciesHandler;
            _taxRatesHandler = taxRatesHandler;
        }

        [HttpGet]
        [Route("/Currencies")]
        public IActionResult Currencies()
        {
            return Ok(_currenciesHandler.Execute(new CurrenciesRequest()));
        }

        [HttpGet]
        [Route("/TaxRates")]
        public IActionResult TaxRates()
        {
            return Ok(_taxRatesHandler.Execute(new TaxRateRequest()));
        }

    }
}