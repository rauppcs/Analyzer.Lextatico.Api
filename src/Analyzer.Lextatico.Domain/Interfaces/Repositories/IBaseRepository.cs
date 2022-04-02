using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Analyzer.Lextatico.Domain.Models;

namespace Analyzer.Lextatico.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : Base
    {
        IUnityOfWork UnityOfWork { get; }
        Task<T> SelectByIdAsync(Guid id);
        Task<IEnumerable<T>> SelectAllAsync();
        Task<IEnumerable<T>> SelectAllOrderByAscendingAsync<TKey>(Expression<Func<T, TKey>> expression);
        Task<IEnumerable<T>> SelectAllOrderByDescendingAsync<TKey>(Expression<Func<T, TKey>> expression);
        Task<bool> InsertAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(T item);
        Task<bool> DeleteAsync(IEnumerable<T> items);
        Task<bool> ExistsAsync(Guid id);
    }
}
