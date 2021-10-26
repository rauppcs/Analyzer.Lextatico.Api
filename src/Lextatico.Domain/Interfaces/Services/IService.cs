using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lextatico.Domain.Models;

namespace Lextatico.Domain.Interfaces.Services
{
    public interface IService<T> where T : Base
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> PostAsync(T item);
        Task<bool> PutAsync(T item);
        Task<bool> DeleteAsync(Guid id);
    }
}
