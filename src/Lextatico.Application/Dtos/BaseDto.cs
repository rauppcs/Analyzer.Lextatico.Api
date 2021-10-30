using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lextatico.Application.Dtos
{
    public abstract class BaseDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
