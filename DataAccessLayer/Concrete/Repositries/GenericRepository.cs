using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.Repositries
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        readonly Context db = new();
        readonly DbSet<T> _object;
        public GenericRepository()
        {
            _object = db.Set<T>();
        }
        public List<T> GetList()
        {
            return _object.ToList();
        }
        public void Update(T p)
        {
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Add(T p)
        {
            _object.Add(p);
            db.SaveChanges();
        }
        public void Delete(T p)
        {
            _object.Remove(p);
            db.SaveChanges();
        }
        public List<T> WhereList(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public T GetById(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }
    }
}
