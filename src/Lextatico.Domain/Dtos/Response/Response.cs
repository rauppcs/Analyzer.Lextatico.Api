#nullable enable

using System.Collections.Generic;
using System.Linq;

namespace Lextatico.Domain.Dtos.Response
{
    public class Response : IResponse
    {
        public Response()
        {

        }
        public Response(object result)
        {
            Result = result;
        }

        public object? Result { get; set; }
        public IList<Error> Errors { get; set; } = new List<Error>();
        private string _locationObjectCreated = string.Empty;

        public void AddResult(object data) => Result = data;

        public void AddError(Error error) => Errors.Add(error);

        public void AddError(string property, string message) => Errors.Add(new Error(property, message));

        public bool IsValid() => !Errors.Any();

        public void ClearErrors() => Errors.Clear();

        public string GetLocation() => _locationObjectCreated;

        public void SetLocation(string location) => _locationObjectCreated = location;
    }

    public interface IResponse
    {
        void AddResult(object data);
        void AddError(Error error);
        void AddError(string property, string message);
        bool IsValid();
        void ClearErrors();
        string GetLocation();
        void SetLocation(string location);
    }
}
