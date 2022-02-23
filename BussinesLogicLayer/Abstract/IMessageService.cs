using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinesLogicLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> WhereList(Expression<Func<Message, bool>> filter);
        Message GetByID(short id);
        List<Message> GetList();
        void Delete(Message p);
        void Add(Message p);
        void Update(Message p);
    }
}
