using System;
using System.Threading.Tasks;
using Lextatico.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Lextatico.Infra.CrossCutting.Extensions
{
    public class TransactionUnitMiddleware
    {
        private readonly RequestDelegate _next;

        public TransactionUnitMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, LextaticoContext lextaticoContext)
        {
            try
            {
                string httpVerb = httpContext.Request.Method.ToUpper();

                if (httpVerb == "POST" || httpVerb == "PUT" || httpVerb == "DELETE")
                {
                    var strategy = lextaticoContext.CreateExecutionStrategy();

                    await strategy.ExecuteAsync(async () => {
                        await using var transaction = await lextaticoContext.StartTransactionAsync();

                        await _next(httpContext);

                        await lextaticoContext.SubmitTransactionAsync(transaction);
                    });
                }
                else
                {
                    await _next(httpContext);
                }
            }
            catch (Exception ex)
            {
                // _logger TODO: fazer log

                throw;
            }
        }
    }
}
