using BusinessLogicLayer.Contracts;
using ProjectRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.BaseBLL
{
    public abstract class BaseManager<T> : IBusinessLogicManager<T> where T : class
    {
        private readonly IRepository<T> _iRepository;
        
        public BaseManager(IRepository<T> repository)
        {
            _iRepository = repository;
        }

        public virtual T GetById(int? id)
        {
            return _iRepository.GetById(id);
        }

        public virtual ICollection<T> GetAll()
        {
            return _iRepository.GetAll();
        }

        public virtual bool Add(T entity)
        {
            return _iRepository.Add(entity);
        }

        public virtual bool Update(T entity)
        {
            return _iRepository.Update(entity);
        }

        public virtual bool Remove(T entity)
        {
            return _iRepository.Remove(entity);
        }
    }
}
