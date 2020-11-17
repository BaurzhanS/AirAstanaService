using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DatabaseAccess.Contracts
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationContext ApplicationContext { get; set; }

        public RepositoryBase(ApplicationContext ApplicationContext)
        {
            this.ApplicationContext = ApplicationContext;
        }
       
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.ApplicationContext.Set<T>().Where(expression);
        }

        public void Insert(T entity)
        {
            this.ApplicationContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.ApplicationContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.ApplicationContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return this.ApplicationContext.Set<T>();
        }
    }
}
