using BussinesLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinesLogicLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        readonly private ICategoryDAL _categoryDal;

        public CategoryManager(ICategoryDAL categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public List<Category> GetList()
        {
            return _categoryDal.GetList();
        }

        public void Add(Category p)
        {
            _categoryDal.Add(p);
        }

        public void Update(Category p)
        {
            _categoryDal.Update(p);
        }

        public void Delete(Category p)
        {
            _categoryDal.Delete(p);
        }

        public List<Category> WhereList(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.WhereList(filter);
        }

        public Category GetById(byte id)
        {
            return _categoryDal.GetById(x => x.CategoryID == id);
        }
    }
}
