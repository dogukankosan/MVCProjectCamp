using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinesLogicLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetFindList(string p);
        void Update(Content p);
        void Delete(Content p);
        void Add(Content p);
        Content GetById(short id);
        List<Content> WhereList(Expression<Func<Content, bool>> filter);
    }
}
