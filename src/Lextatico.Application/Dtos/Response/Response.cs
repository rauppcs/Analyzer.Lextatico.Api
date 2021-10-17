#nullable enable

using System.Collections.Generic;
using System.Linq;

namespace Lextatico.Application.Dtos.Response
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data)
        {
            Data = data;
        }

        public T? Data { get; set; }
        public IList<Error> Errors { get; set; } = new List<Error>();
        private string _locationObjectCreated = string.Empty;

        public void AddResult(T data) => Data = data;

        public void AddError(Error error) => Errors.Add(error);

        public void AddError(string property, string message) => Errors.Add(new Error(property, message));

        public bool IsValid() => !Errors.Any();

        public void ClearErrors() => Errors.Clear();

        public string GetLocation() => _locationObjectCreated;

        public void SetLocation(string location) => _locationObjectCreated = location;
    }
}
