using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lextatico.Domain.Models;
using Lextatico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Lextatico.Infra.Data.Repositories
{
    public class Repository<T> where T : Base
    {
        protected readonly LextaticoContext _lextaticoContext;
        private DbSet<T> _dataSet;

        public Repository(LextaticoContext lextaticoContext)
        {
            _lextaticoContext = lextaticoContext;
            _dataSet = lextaticoContext.Set<T>();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var itemDb = await SelectAsync(id);
            if (itemDb == null)
                return false;

            _dataSet.Remove(itemDb);

            await _lextaticoContext.SaveChangesAsync();

            return true;
        }

        public async Task<T> SelectAsync(Guid id)
        {
            var itemDb = await _dataSet.FindAsync(id);
            return itemDb;
        }

        public async Task<IList<T>> SelectAllAsync()
        {
            var itensDb = await _dataSet.ToListAsync();
            return itensDb;
        }

        public async Task<T> InsertAsync(T item)
        {
            //TODO: VERIFICAR A NECESSIDADE DESSA LINHA -> item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;

            await _dataSet.AddAsync(item);

            await _lextaticoContext.SaveChangesAsync();

            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            var itemDb = await SelectAsync(item.Id);

            if (itemDb == null)
                return null;

            _lextaticoContext.Entry(itemDb).CurrentValues.SetValues(item);

            await _lextaticoContext.SaveChangesAsync();

            return item;
        }
    }
}
