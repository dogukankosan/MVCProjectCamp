using BussinesLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinesLogicLayer.Concrete
{
    public class ContentManager : IContentService
    {
        private readonly IContentDAL _contentDAL;
        public ContentManager(IContentDAL contentDAL)
        {
            _contentDAL = contentDAL;
        }
        public void Add(Content p)
        {
            _contentDAL.Add(p);
        }
        public void Delete(Content p)
        {
            _contentDAL.Delete(p);
        }
        public Content GetById(short id)
        {
            return _contentDAL.GetById(x => x.HeadingID == id);
        }
        public List<Content> GetList()
        {
            return _contentDAL.GetList();
        }

        public List<Content> GetFindList(string p)
        {
            return _contentDAL.WhereList(x => x.ContentText.ToLower().Contains(p.ToLower()));
        }

        public void Update(Content p)
        {
            _contentDAL.Update(p);
        }
        public List<Content> WhereList(Expression<Func<Content, bool>> filter)
        {
            return _contentDAL.WhereList(filter);
        }
    }
}
