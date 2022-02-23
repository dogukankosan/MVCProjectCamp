using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositries;
using EntitiyLayer.Concrete;

namespace DataAccessLayer.EntitiyFramework
{
    public class EFAdminDAL : GenericRepository<Admin>, IAdminDAL
    {
    }
}
