using System;
using System.Threading.Tasks;
using EasyCompiler.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EasyCompiler.Infra.CrossCutting.Extensions
{
    public class TransactionUnitMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IContextDb _easyCompilerContext;

        public TransactionUnitMiddleware(RequestDelegate next, EasyCompilerContext easyCompilerContext)
        {
            _easyCompilerContext = easyCompilerContext;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                string httpVerb = httpContext.Request.Method.ToUpper();

                if (httpVerb == "POST" || httpVerb == "PUT" || httpVerb == "DELETE")
                {
                    var strategy = _easyCompilerContext.CreateExecutionStrategy();

                    await strategy.ExecuteAsync(async () => {
                        await using var transaction = await _easyCompilerContext.StartTransactionAsync();

                        await _next(httpContext);

                        await _easyCompilerContext.SubmitTransactionAsync(transaction);
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
