using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinesLogicLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> List();
        Contact GetByID(short id);
        void Update(Contact p);
        void Delete(Contact p);
        void Add(Contact p);
        List<Contact> WhereList(Expression<Func<Contact, bool>> filter);
    }
}
