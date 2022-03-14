#nullable enable

using System.Collections.Generic;
using System.Linq;
using Analyzer.Lextatico.Domain.Dtos.Message;

namespace Analyzer.Lextatico.Application.Dtos.Response
{
    public class Response
    {
        public Response()
        {
        }
        public Response(object? data)
        {
            Data = data;
        }

        public object? Data { get; private set; }

        public IList<Notification> Errors { get; } = new List<Notification>();

        public IList<Notification> Warnings { get; } = new List<Notification>();

        public void AddResult(object data) => Data = data;

        public void AddError(Notification error) => Errors.Add(error);

        public void AddError(string message) => Errors.Add(new Notification(string.Empty, message));

        public void AddError(string property, string message) => Errors.Add(new Notification(property, message));

        public void AddWarning(Notification error) => Warnings.Add(error);

        public void AddWarning(string message) => Warnings.Add(new Notification(string.Empty, message));

        public void AddWarning(string property, string message) => Warnings.Add(new Notification(property, message));
    }
}
