using System.IO;
using System.Threading.Tasks;
using Lextatico.Api.Filters;
using Lextatico.Domain.Dtos.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lextatico.Api.Controllers.Base
{
    // [FilterExceptionApi]
    /// <summary>
    /// Base controller, containing the validation of the response object and the appropriate status returns of the possible application status codes.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    [FilterExceptionApi]
    public abstract class MyControllerBase : ControllerBase
    {
        private IActionResult VerifyValidResponse(Response response, IActionResult result)
        {
            if (response is null || !response.IsValid())
                return BadRequest(response);

            return result;
        }

        protected virtual IActionResult ReturnOk()
        {
            return NoContent();
        }

        protected virtual IActionResult ReturnOk(Response response)
        {
            return VerifyValidResponse(response, Ok(response));
        }

        protected virtual IActionResult ReturnCreated(Response response)
        {
            return VerifyValidResponse(response, Created(response.GetLocation(), response));
        }

        protected virtual IActionResult ReturnAccepted(Response response)
        {
            return VerifyValidResponse(response, Accepted(response));
        }

        protected virtual IActionResult ReturnBadRequest(Response response)
        {
            return BadRequest(response);
        }

        protected virtual IActionResult ReturnFileResult(string nameFile, string file, string contentType)
        {
            var ms = new MemoryStream();
            var streamWriter = new StreamWriter(ms);

            streamWriter.WriteLine(file);
            streamWriter.Flush();

            ms.Position = 0;

            return File(ms, contentType, nameFile);
        }

        protected virtual async Task<IActionResult> ReturnFileResultAsync(string nameFile, string file, string contentType)
        {
            var ms = new MemoryStream();
            var streamWriter = new StreamWriter(ms);

            await streamWriter.WriteLineAsync(file);
            await streamWriter.FlushAsync();

            ms.Position = 0;

            return File(ms, contentType, nameFile);
        }

        protected virtual IActionResult ReturnCustomResult(IActionResult actionResult) => actionResult;
    }
}
