using BussinesLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinesLogicLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        private readonly IWriterDAL IWriterDal;

        public WriterManager(IWriterDAL writer)
        {
            IWriterDal = writer;
        }
        public List<Writer> GetList()
        {
            return IWriterDal.GetList();
        }

        public void Update(Writer p)
        {
            IWriterDal.Update(p);
        }

        public void Delete(Writer p)
        {
            IWriterDal.Delete(p);
        }

        public void Add(Writer p)
        {
            IWriterDal.Add(p);
        }

        public Writer GetById(short id)
        {
            return IWriterDal.GetById(x => x.WriterID == id);
        }

        public List<Writer> WhereList(Expression<Func<Writer, bool>> filter)
        {
            return IWriterDal.WhereList(filter);
        }
    }
}
