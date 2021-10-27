using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Lextatico.Domain.Interfaces.Repositories;
using Lextatico.Domain.Models;
using Lextatico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Lextatico.Infra.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Base
    {
        protected readonly LextaticoContext _lextaticoContext;
        protected DbSet<T> _dataSet;

        public Repository(LextaticoContext lextaticoContext)
        {
            _lextaticoContext = lextaticoContext;
            _dataSet = lextaticoContext.Set<T>();
        }

        public async Task<bool> InsertAsync(T item)
        {
            await _dataSet.AddAsync(item);

            var result = await _lextaticoContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> UpdateAsync(T item)
        {
            var itemDb = await SelectByIdAsync(item.Id);

            if (itemDb == null)
                return false;

            _lextaticoContext.Entry(itemDb).CurrentValues.SetValues(item);

            var result = await _lextaticoContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var itemDb = await SelectByIdAsync(id);

            if (itemDb == null)
                return false;

            _dataSet.Remove(itemDb);

            var result = await _lextaticoContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<T> SelectByIdAsync(Guid id) =>
            await _dataSet.FindAsync(id);

        public async Task<IEnumerable<T>> SelectAllAsync() =>
            await _dataSet.ToListAsync();

        public async Task<IEnumerable<T>> SelectAllOrderedAsync() =>
            await _dataSet.ToListAsync();

        public async Task<IEnumerable<T>> SelectAllOrderByAscendingAsync<TKey>(Expression<Func<T, TKey>> expression) =>
            await _dataSet.OrderBy(expression).ToListAsync();

        public async Task<IEnumerable<T>> SelectAllOrderByDescendingAsync<TKey>(Expression<Func<T, TKey>> expression) =>
            await _dataSet.OrderByDescending(expression).ToListAsync();

        public async Task<bool> Exists(Guid id)
        {
            var entity = await SelectByIdAsync(id);

            return entity != null;
        }
    }
}
