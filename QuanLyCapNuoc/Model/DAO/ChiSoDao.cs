using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.DAO;
using PagedList;
using System.Security.Cryptography.X509Certificates;

namespace Model.DAO
{
    public class ChiSoDao
    {
        CapThoatNuoc db = null;
        public static string USER_SESSION = "USER_SESSION";
        public ChiSoDao()
        {
            db = new CapThoatNuoc();
        }
        public List<khachhang> GetList_kh()
        {
            return db.khachhangs.ToList();
        }
        public int Insert(chiso entity)
        {
            db.chisoes.Add(entity);
            db.SaveChanges();
            return entity.cs_chiso;
        }

        public bool Update(chiso entity)
        {

            try
            {
                
                var data = db.chisoes.FirstOrDefault(x => (x.kh_id == entity.kh_id) && (x.k_id == entity.k_id));
                data.kh_id = entity.kh_id;
                data.k_id = entity.k_id;
                data.cs_chiso = entity.cs_chiso;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public IEnumerable<chiso> ListAllPaging(int id,int page, int pageSize)
        {
            IQueryable<chiso> a = db.chisoes;
            var model = a.Where(x => x.kh_id == id);
            return model.OrderByDescending(x => x.kh_id).ToPagedList(page, pageSize);
        }
        public IEnumerable<khachhang> ListAllPagingkh( int page, int pageSize)
        {
             return db.khachhangs.OrderByDescending(x => x.kh_id).ToPagedList(page, pageSize);
        }


    








        public chiso ViewDetail(int kh, int ghi)
        {

            return db.chisoes.FirstOrDefault(x => (x.kh_id == kh) && (x.k_id == ghi));
        }
        public bool Delete(int ghi, int kh)
        {
            try
            {
                var data = db.chisoes.FirstOrDefault(x => (x.kh_id == kh) && (x.k_id == ghi));
                db.chisoes.Remove(data);
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
