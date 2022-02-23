using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinesLogicLayer.Abstract
{
    public interface IAboutService
    {
        About GetById(byte id);
        void Add(About p);
        void Delete(About p);
        void Update(About p);
        List<About> GetList();
        List<About> WhereList(Expression<Func<About, bool>> filter);

    }
}
