using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinesLogicLayer.Abstract
{
    public interface IGalleryService
    {
        Gallery GetByID(byte id);
        List<Gallery> WhereList(Expression<Func<Gallery, bool>> filter);
        List<Gallery> GetList();
        void Delete(Gallery p);
        void Update(Gallery p);
        void Add(Gallery p);
    }
}