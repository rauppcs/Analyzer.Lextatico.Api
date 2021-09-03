using Lextatico.Domain.Dtos.Responses;
using Lextatico.Infra.CrossCutting.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Lextatico.Api.Configurations
{
    public class CustomResponseModelStateInvalid
    {
        public static void Configure(ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var response = new Response();

                foreach (var key in context.ModelState.Keys)
                {
                    var value = context.ModelState[key];
                    foreach (var error in value.Errors)
                    {
                        response.AddError(key.ToCamelCase(), error.ErrorMessage);
                    }
                }

                return new BadRequestObjectResult(response);
            };
        }
    }
}
