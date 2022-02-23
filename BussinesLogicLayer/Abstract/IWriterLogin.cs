using EntitiyLayer.Concrete;

namespace BussinesLogicLayer.Abstract
{
    public interface IWriterLogin
    {
        Writer GetByID(string username, string password);
    }
}
