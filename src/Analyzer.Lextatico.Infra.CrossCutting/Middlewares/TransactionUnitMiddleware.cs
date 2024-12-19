using System.Net;
using Analyzer.Lextatico.Infra.CrossCutting.Extensions;
using Analyzer.Lextatico.Infra.Data.Context;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Analyzer.Lextatico.Infra.CrossCutting.Middlewares
{
    public static class TransactionUnitExtension
    {
        public static IApplicationBuilder UseTransaction(this IApplicationBuilder app)
        {
            if (app is null)
                throw new ArgumentNullException(nameof(app));

            app.UseMiddleware<TransactionUnitMiddleware>();

            return app;
        }
    }

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

                    await strategy.ExecuteAsync(async () =>
                    {
                        await using var transaction = await lextaticoContext.StartTransactionAsync();

                        await _next(httpContext);

                        var httpStatusCode = Enum.Parse<HttpStatusCode>(httpContext.Response.StatusCode.ToString());

                        var pathSplit = httpContext.Request.Path.Value.Split("/");

                        if (httpStatusCode.IsSuccess())
                            await lextaticoContext.SubmitTransactionAsync(transaction);
                        else
                        {
                            await lextaticoContext.UndoTransaction(transaction);
                        }
                    });
                }
                else
                {
                    await _next(httpContext);
                }
            }
            catch (Exception)
            {
                await lextaticoContext.UndoTransaction();

            }
            finally
            {
                await lextaticoContext.DiscardCurrentTransactionAsync();
            }
        }
    }
}
