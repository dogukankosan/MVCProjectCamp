using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinesLogicLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        void Update(Writer p);
        void Delete(Writer p);
        void Add(Writer p);
        Writer GetById(short id);
        List<Writer> WhereList(Expression<Func<Writer, bool>> filter);
    }
}
