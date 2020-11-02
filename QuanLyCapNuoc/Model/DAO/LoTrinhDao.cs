using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.DAO;
using PagedList;

namespace Model.DAO
{
    public class LoTrinhDao
    {
        CapThoatNuoc db = null;
        public static string USER_SESSION = "USER_SESSION";
        public LoTrinhDao()
        {
            db = new CapThoatNuoc();
        }

        public long Insert(lotrinh entity)
        {
            db.lotrinhs.Add(entity);
            db.SaveChanges();
            return entity.lt_id;
        }

        public bool Update(lotrinh entity, int id)
        {



            try
            {
                var data = db.lotrinhs.Find(id);

                data.kv_id = entity.kv_id;
                data.lt_ten = entity.lt_ten;
                data.nv_id = entity.nv_id;
                data.lt_ghichu = entity.lt_ghichu;


                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public IEnumerable<lotrinh> ListAllPaging(int page, int pageSize)
        {
            IQueryable<lotrinh> model = db.lotrinhs;

            return model.OrderByDescending(x => x.lt_id).ToPagedList(page, pageSize);
        }

        public lotrinh GetByID(long id)
        {
            return db.lotrinhs.Find(id);
        }


        public lotrinh ViewDetail(int id)
        {
            return db.lotrinhs.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var data = db.lotrinhs.Find(id);
                db.lotrinhs.Remove(data);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<khuvuc> GetList_kv()
        {
            return db.khuvucs.ToList();
        }

        public IEnumerable<khuvuc> ListAllPagingkh(int page, int pageSize)
        {
            return db.khuvucs.OrderByDescending(x => x.kv_id).ToPagedList(page, pageSize);
        }

    }
}
