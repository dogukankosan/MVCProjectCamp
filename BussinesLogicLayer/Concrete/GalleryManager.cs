using BussinesLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinesLogicLayer.Concrete
{
    public class GalleryManager : IGalleryService
    {
        private readonly IGalleryDAL _galleryDal;

        public GalleryManager(IGalleryDAL galleryDal)
        {
            _galleryDal = galleryDal;
        }
        public Gallery GetByID(byte id)
        {
            return _galleryDal.GetById(x => x.ID == id);
        }

        public List<Gallery> WhereList(Expression<Func<Gallery, bool>> filter)
        {
            return _galleryDal.WhereList(filter);
        }

        public List<Gallery> GetList()
        {
            return _galleryDal.GetList();
        }

        public void Delete(Gallery p)
        {
            _galleryDal.Delete(p);
        }

        public void Update(Gallery p)
        {
            _galleryDal.Update(p);
        }

        public void Add(Gallery p)
        {
            _galleryDal.Add(p);
        }
    }
}
