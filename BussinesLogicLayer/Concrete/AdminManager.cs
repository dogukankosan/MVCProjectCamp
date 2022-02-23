using BussinesLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinesLogicLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDAL _adminDal;

        public AdminManager(IAdminDAL adminDAL)
        {
            _adminDal = adminDAL;
        }
        public Admin GetByID(byte id)
        {
            return _adminDal.GetById(x => x.ID == id);
        }

        public List<Admin> WhereList(Expression<Func<Admin, bool>> filter)
        {
            return _adminDal.WhereList(filter);
        }

        public List<Admin> GetList()
        {
            return _adminDal.GetList();
        }

        public void Update(Admin p)
        {
            _adminDal.Update(p);
        }

        public void Delete(Admin p)
        {
            _adminDal.Delete(p);
        }

        public void Add(Admin p)
        {
            _adminDal.Add(p);
        }
    }
}
