#nullable enable

using System.Collections.Generic;
using System.Linq;

namespace Lextatico.Domain.Dtos.Responses
{
    public class Response
    {
        public Response()
        {

        }
        public Response(object result)
        {
            Result = result;
        }

        private string _locationObjectCreated = string.Empty;
        public IList<Error> Errors { get; set; } = new List<Error>();

        public object? Result { get; set; }

        public void AddError(Error error) => Errors.Add(error);

        public void AddError(string property, string message) => Errors.Add(new Error(property, message));

        public bool IsValid() => !Errors.Any();

        public void ClearErrors() => Errors.Clear();

        public string GetLocation() => _locationObjectCreated;

        public void SetLocation(string location) => _locationObjectCreated = location;
    }
}
