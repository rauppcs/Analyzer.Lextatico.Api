using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lextatico.Domain.Models
{
    public class BaseModel
    {
        public BaseModel(DateTime createdAt)
        {
            CreatedAt = createdAt;
        }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
