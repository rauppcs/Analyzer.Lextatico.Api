using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lextatico.Domain.Models;

namespace Lextatico.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IList<T>> SelectAllAsync();
    }
}
