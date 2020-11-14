using System;
using System.Collections.Generic;
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
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Find(object query)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> List()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
