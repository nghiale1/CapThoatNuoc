using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using Common;

namespace Model.DAO
{
    public class KyThuDao
    {
        CapThoatNuoc db = null;
        public static string USER_SESSION = "USER_SESSION";
        public KyThuDao()
        {
            db = new CapThoatNuoc();
        }

        public long Insert(kythu entity)
        {
            db.kythus.Add(entity);
            db.SaveChanges();
            return entity.kt_id;
        }

        public bool Update(kythu entity, int id)
        {



            try
            {
                var thu = db.kythus.Find(id);
                thu.k_id = entity.k_id;
                thu.kt_lanthu = entity.kt_lanthu;
                thu.kt_ngaythu = entity.kt_ngaythu;
                thu.kt_trangthai = entity.kt_trangthai;



                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public IEnumerable<kythu> ListAllPaging(int page, int pageSize)
        {
            IQueryable<kythu> model = db.kythus;

            return model.OrderByDescending(x => x.kt_id).ToPagedList(page, pageSize);
        }

        public kythu GetByID(long id)
        {
            return db.kythus.Find(id);
        }


        public kythu ViewDetail(int id)
        {
            return db.kythus.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var KyThu = db.kythus.Find(id);
                db.kythus.Remove(KyThu);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool ChangeStatus(long id)
        {
            var stt = db.kythus.Find(id);
            if (stt.kt_trangthai == 1)
                stt.kt_trangthai = 0;
            else
            {
                stt.kt_trangthai = 1;
            }
            db.SaveChanges();
            return true;
        }
    }
}
