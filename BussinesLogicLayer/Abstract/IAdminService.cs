using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinesLogicLayer.Abstract
{
    public interface IAdminService
    {
        Admin GetByID(byte id);
        List<Admin> WhereList(Expression<Func<Admin, bool>> filter);
        List<Admin> GetList();
        void Update(Admin p);
        void Delete(Admin p);
        void Add(Admin p);
    }
}
