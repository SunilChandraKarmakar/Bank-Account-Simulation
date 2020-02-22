using Microsoft.EntityFrameworkCore;
using ProjectContext;
using ProjectRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectRepository.BaseRpository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly OurContext ourContext;
        
        public BaseRepository()
        {
            ourContext = new OurContext();
        }

        public virtual T GetById(int? id)
        {
            return ourContext.Set<T>().Find(id);
        }

        public virtual ICollection<T> GetAll()
        {
            return ourContext.Set<T>().ToList();
        }

        public virtual bool Add(T entity)
        {
            ourContext.Set<T>().Add(entity);
            return ourContext.SaveChanges() > 0;
        }

        public virtual bool Update(T entity)
        {
            ourContext.Entry(entity).State = EntityState.Modified;
            return ourContext.SaveChanges() > 0;
        }

        public virtual bool Remove(T entity)
        {
            ourContext.Set<T>().Remove(entity);
            return ourContext.SaveChanges() > 0;
        }
    }
}
