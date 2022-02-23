using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace BussinesLogicLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        void Add(Category p);
        void Update(Category p);
        void Delete(Category p);
        List<Category> WhereList(Expression<Func<Category, bool>> filter);
        Category GetById(byte id);
    }
}
