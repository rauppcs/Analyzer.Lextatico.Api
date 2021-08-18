using Microsoft.AspNetCore.Mvc;

namespace EasyCompiler.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TesteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Teste()
        {
            var responde = "Funciona";

            return Ok(responde);
        }
    }
}
