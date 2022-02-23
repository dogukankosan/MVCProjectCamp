using BussinesLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinesLogicLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDAL _messageDal;

        public MessageManager(IMessageDAL message)
        {
            _messageDal = message;
        }

        public List<Message> WhereList(Expression<Func<Message, bool>> filter)
        {
            return _messageDal.WhereList(filter);
        }

        public Message GetByID(short id)
        {
            return _messageDal.GetById(x => x.ID == id);
        }

        public List<Message> GetList()
        {
            return _messageDal.GetList();
        }

        public void Delete(Message p)
        {
            _messageDal.Delete(p);
        }

        public void Add(Message p)
        {
            _messageDal.Add(p);
        }

        public void Update(Message p)
        {
            _messageDal.Update(p);
        }
    }
}
