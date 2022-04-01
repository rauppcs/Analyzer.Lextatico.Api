using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Analyzer.Lextatico.Domain.Models
{
    public class ApplicationUser : Base
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Analyzer> Analyzers { get; } = new List<Analyzer>();
    }
}
