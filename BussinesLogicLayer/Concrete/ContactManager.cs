using BussinesLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinesLogicLayer.Concrete
{
    public class ContactManager : IContactService
    {
        public readonly IContactDAL _contactDal;

        public ContactManager(IContactDAL contactDal)
        {
            _contactDal = contactDal;
        }

        public List<Contact> List()
        {
            return _contactDal.GetList();
        }

        public Contact GetByID(short id)
        {
            return _contactDal.GetById(x => x.ContactID == id);
        }

        public void Update(Contact p)
        {
            _contactDal.Update(p);
        }

        public void Delete(Contact p)
        {
            _contactDal.Delete(p);
        }
        public void Add(Contact p)
        {
            _contactDal.Add(p);
        }

        public List<Contact> WhereList(Expression<Func<Contact, bool>> filter)
        {
            return WhereList(filter);
        }
    }
}
