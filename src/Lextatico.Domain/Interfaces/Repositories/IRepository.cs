using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lextatico.Domain.Models;

namespace Lextatico.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : Base
    {
        Task<bool> InsertAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectByIdAsync(Guid id);
        Task<IList<T>> SelectAllAsync();
    }
}
