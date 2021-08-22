using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Lextatico.Application.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lextatico.Api.Filters
{
    /// <summary>
    /// Filter to catch exceptions during operations called by controller methods.
    /// </summary>
    public class FilterExceptionApi : ExceptionFilterAttribute
    {
        /// <summary>
        /// Method called when an exception happens during an operation triggered by the controller.
        /// </summary>
        /// <param name="context">Context object for the exception.</param>
        public override void OnException(ExceptionContext context)
        {
            var response = new Response();

            var exception = context.Exception;

            response.AddError(string.Empty, "Ocorreu um erro inesperado.");

            context.Result = new BadRequestObjectResult(response);
        }

        /// <summary>
        /// Method called when an exception happens during an operation triggered by the controller.
        /// </summary>
        /// <param name="context">Context object for the exception.</param>
        /// <returns></returns>
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);

            return Task.CompletedTask;
        }
    }
}
