using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lextatico.Api.Filters
{
    public class ValidationModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // TODO: SETAR VALIDAÇÃO PARA MANUAL, E TRAZER O CÓDIGO DO CustomResponseModelStateInvalid PARA AQUI
            base.OnActionExecuting(context);
        }
    }
}