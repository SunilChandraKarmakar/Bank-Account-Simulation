using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Contracts
{
    public interface IBusinessLogicManager<T> where T : class
    {
        public T GetById(int? id);
        public ICollection<T> GetAll();
        public bool Add(T entity);
        public bool Update(T entity);
        public bool Remove(T entity);
    }
}
