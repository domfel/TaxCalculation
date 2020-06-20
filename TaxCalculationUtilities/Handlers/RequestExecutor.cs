using System;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TaxCalculationUtilities.Handlers
{
    /// <summary>
    /// Executor used for ensuring proper request validation and error handling for all requests
    /// </summary>
    public class RequestExecutor<TIn,TOut>
    {
        private readonly ILogger _logger;
        private readonly AbstractValidator<TIn> _validator;
        private readonly IQueryHandler<TIn, TOut> _handler;

        public RequestExecutor(
            ILogger logger,
            AbstractValidator<TIn> validator,
            IQueryHandler<TIn, TOut> handler
        )
        {
            _logger = logger;
            _validator = validator;
            _handler = handler;
        }


        public IActionResult Execute(TIn input)
        {
            try
            {
                var result = _validator.Validate(input);
                if (result.IsValid)
                {
                    TOut response = _handler.Execute(input);
                    return new OkObjectResult(response);
                }
                return new BadRequestObjectResult(result.Errors);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e, "Unhandled Exception");
                return new ObjectResult("INTERNAL SERVER ERROR")
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                }; 
            }
        }
    }
}
