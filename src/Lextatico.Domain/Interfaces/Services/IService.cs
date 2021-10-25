using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lextatico.Domain.Interfaces.Services
{
    public interface IService<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IList<T>> GetAllAsync();
        Task<bool> PostAsync(T item);
        Task<bool> PutAsync(T item);
        Task<bool> DeleteAsync(Guid id);
    }
}
