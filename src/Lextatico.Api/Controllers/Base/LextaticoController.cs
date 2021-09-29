using System.IO;
using System.Threading.Tasks;
using Lextatico.Api.Filters;
using Lextatico.Domain.Dtos.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lextatico.Api.Controllers.Base
{
    /// <summary>
    /// Base controller, containing the validation of the response object and the appropriate status returns of the possible application status codes.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public abstract class LextaticoController : ControllerBase
    {
        private readonly IResponse _response;

        protected LextaticoController(IResponse response)
        {
            _response = response;
        }

        private IActionResult VerifyValidResponse(object data, IActionResult result)
        {
            if (_response is null || !_response.IsValid())
                return BadRequest(_response);

            _response.AddResult(data);

            return result;
        }

        protected virtual IActionResult ReturnOk()
        {
            return NoContent();
        }

        protected virtual IActionResult ReturnOk(object data)
        {
            return VerifyValidResponse(data, Ok(_response));
        }

        protected virtual IActionResult ReturnCreated(object data)
        {
            return VerifyValidResponse(data, Created(_response.GetLocation(), _response));
        }

        protected virtual IActionResult ReturnAccepted(object data)
        {
            return VerifyValidResponse(data, Accepted(_response));
        }

        protected virtual IActionResult ReturnBadRequest()
        {
            return BadRequest(_response);
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
