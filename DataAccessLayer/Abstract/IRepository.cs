using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetList();
        void Update(T p);
        void Add(T p);
        void Delete(T p);
        List<T> WhereList(Expression<Func<T, bool>> filter);
        T GetById(Expression<Func<T, bool>> filter);
    }
}
