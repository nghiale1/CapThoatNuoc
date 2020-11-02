using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.DAO
{
    public class KyGhiDao
    {
        CapThoatNuoc db = null;
        public static string USER_SESSION = "USER_SESSION";
        public KyGhiDao()
        {
            db = new CapThoatNuoc();
        }

        public long Insert(kyghi entity)
        {
            db.kyghis.Add(entity);
            db.SaveChanges();
            return entity.k_id;
        }

        public bool Update(kyghi entity, int id)
        {

            try
            {
                var ghi = db.kyghis.Find(id);
                ghi.nv_id = entity.nv_id;
               
                ghi.k_ten = entity.k_ten;
                ghi.k_ngaybatdau = entity.k_ngaybatdau;
                

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public IEnumerable<kyghi> ListAllPaging(int page, int pageSize)
        {
            IQueryable<kyghi> model = db.kyghis;

            return model.OrderByDescending(x => x.k_id).ToPagedList(page, pageSize);
        }

        public kyghi GetByID(long id)
        {
            return db.kyghis.Find(id);
        }


        public kyghi ViewDetail(int id)
        {
            return db.kyghis.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var kyghi = db.kyghis.Find(id);
                db.kyghis.Remove(kyghi);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
