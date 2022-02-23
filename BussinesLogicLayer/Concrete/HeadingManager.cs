using BussinesLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinesLogicLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        private readonly IHeadingDAL _headingDal;
        public HeadingManager(IHeadingDAL dal)
        {
            _headingDal = dal;
        }
        public List<Heading> GetList()
        {
            return _headingDal.GetList();
        }

        public void Update(Heading p)
        {
            _headingDal.Update(p);
        }

        public void Delete(Heading p)
        {
            _headingDal.Delete(p);
        }

        public void Add(Heading p)
        {
            _headingDal.Add(p);
        }

        public Heading GetById(short id)
        {
            return _headingDal.GetById(x => x.HeadingID == id);
        }

        public List<Heading> WhereList(Expression<Func<Heading, bool>> filter)
        {
            return _headingDal.WhereList(filter);
        }
    }
}
