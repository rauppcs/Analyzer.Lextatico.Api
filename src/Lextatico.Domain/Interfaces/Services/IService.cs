using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lextatico.Domain.Interfaces.Services
{
    public interface IService<T> where T : class
    {
        Task<T> GetAsync(Guid id);
        Task<IList<T>> GetAllAsync();
        Task<T> PostAsync(T item);
        Task<T> PutAsync(T item);
        Task<bool> DeleteAsync(Guid id);
    }
}
