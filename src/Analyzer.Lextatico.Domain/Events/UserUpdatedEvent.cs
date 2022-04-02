using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analyzer.Lextatico.Domain.Models;

namespace Analyzer.Lextatico.Domain.Events
{
    public class UserUpdatedEvent
    {
        public ApplicationUser ApplicationUser { get; set; }
    }
}
