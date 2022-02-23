using BussinesLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinesLogicLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDAL _about;

        public AboutManager(IAboutDAL aboutDAL)
        {
            _about = aboutDAL;
        }
        public About GetById(byte id)
        {
            return _about.GetById(x => x.AboutID == id);
        }

        public void Add(About p)
        {
            _about.Add(p);
        }

        public void Delete(About p)
        {
            _about.Delete(p);
        }

        public void Update(About p)
        {
            _about.Update(p);
        }

        public List<About> GetList()
        {
            return _about.GetList();
        }

        public List<About> WhereList(Expression<Func<About, bool>> filter)
        {
            return _about.WhereList(filter);
        }
    }
}
