using Lextatico.Application.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Lextatico.Api.Configs
{
    public class CustomResponseModelStateInvalid
    {
        public static void Configure(ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var response = new Response();

                foreach(var key in context.ModelState.Keys)
                {
                    var value = context.ModelState[key];
                    foreach(var error in value.Errors)
                    {
                        response.AddError(key, error.ErrorMessage);
                    }
                }

                return new BadRequestObjectResult(response);
            };
        }
    }
}
