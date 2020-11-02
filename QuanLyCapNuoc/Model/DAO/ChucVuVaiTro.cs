using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;


namespace Model.DAO
{
    public class DB_VTCV
    {
        CapThoatNuoc db = new CapThoatNuoc();

       
        public List<vt_cv> GetList_VTCV()
        {
            return db.vt_cv.ToList();
        }
        public List<vaitro> GetList_VT()
        {
            return db.vaitroes.ToList();
        }
        public List<chucvu> GetList_CV()
        {
            return db.chucvus.ToList();
        }

        public long Insert(vt_cv entity)
        {
            db.vt_cv.Add(entity);
            db.SaveChanges();
            return entity.cv_id;
        }
        public bool XoaVTCV(int idCV, int idVT)
        {
            try
            {
                var rm = db.vt_cv.FirstOrDefault(x => (x.vt_id == idVT) && (x.cv_id==idCV));
                //var rm = db.Database.SqlQuery<vt_cv>
                //    (
                //    "SELECT * FROM vt_cv WHERE vt_id=@V AND cv_id=@C;",
                //    new SqlParameter("@C", 1),
                //    new SqlParameter("@V", 1)
                //    ).SingleOrDefault();
                db.vt_cv.Remove(rm);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateVTCV(vt_cv entity)
        {
            try
            {
                var vtcv = db.vt_cv.FirstOrDefault(x => (x.vt_id == entity.vt_id) && (x.cv_id == entity.cv_id));
                vtcv.vtcv_ghichu = entity.vtcv_ghichu;
                vtcv.vt_id = entity.vt_id;
                vtcv.cv_id = entity.cv_id;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public vt_cv ViewDetailVTCV(int idVT, int idCV)
        {
            return db.vt_cv.FirstOrDefault(x => (x.vt_id == idVT) && (x.cv_id == idCV));
        }

    }
}

