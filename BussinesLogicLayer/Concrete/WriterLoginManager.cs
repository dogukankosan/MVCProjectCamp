using BussinesLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;

namespace BussinesLogicLayer.Concrete
{
    public class WriterLoginManager : IWriterLogin
    {
        private readonly IWriterDAL _writerDal;

        public WriterLoginManager(IWriterDAL writerDAL)
        {
            _writerDal = writerDAL;
        }
        public Writer GetByID(string username, string password)
        {
            return _writerDal.GetById(x => x.Mail == username & x.Password == password);
        }
    }
}
