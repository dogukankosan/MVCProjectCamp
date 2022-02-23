using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositries;
using EntitiyLayer.Concrete;

namespace DataAccessLayer.EntitiyFramework
{
    public class EFContentDAL : GenericRepository<Content>, IContentDAL
    {
    }
}
