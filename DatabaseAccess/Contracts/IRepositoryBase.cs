using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.Contracts
{
    public interface IRepositoryBase<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        T Get(int id);
        T Find(object query);
        List<T> List();
        int Count();
    }
}
