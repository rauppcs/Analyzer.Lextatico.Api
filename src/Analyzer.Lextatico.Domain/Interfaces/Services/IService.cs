using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Analyzer.Lextatico.Domain.Models;

namespace Analyzer.Lextatico.Domain.Interfaces.Services
{
    public interface IService<T> where T : Base
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> CreateAsync(T item);
        Task<bool> UpdateAsync(T item);
        // Task<bool> DeleteAsync(Guid id);
        // Task<bool> DeleteAsync(IEnumerable<Guid> ids);
        Task<bool> DeleteAsync(T item);
        Task<bool> DeleteAsync(IEnumerable<T> items);
    }
}
