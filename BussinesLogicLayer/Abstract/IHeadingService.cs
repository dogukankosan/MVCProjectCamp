using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinesLogicLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        void Update(Heading p);
        void Delete(Heading p);
        void Add(Heading p);
        Heading GetById(short id);
        List<Heading> WhereList(Expression<Func<Heading, bool>> filter);
    }
}
