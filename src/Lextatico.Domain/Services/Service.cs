using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lextatico.Domain.Dtos.Message;
using Lextatico.Domain.Interfaces.Repositories;
using Lextatico.Domain.Interfaces.Services;
using Lextatico.Domain.Models;

namespace Lextatico.Domain.Services
{
    public class Service<T> : IService<T> where T : Base
    {
        private readonly IRepository<T> _repository;
        private readonly IMessage _message;

        public Service(IRepository<T> repository, IMessage message)
        {
            _repository = repository;
            _message = message;
        }

        public virtual async Task<bool> PostAsync(T item)
        {
            return await _repository.InsertAsync(item);
        }

        public virtual async Task<bool> PutAsync(T item)
        {
            return await _repository.UpdateAsync(item);
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual async Task<IList<T>> GetAllAsync()
        {
            return await _repository.SelectAllAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _repository.SelectByIdAsync(id);
        }
    }
}
