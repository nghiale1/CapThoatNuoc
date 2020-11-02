using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CustomerDao
    {
        CapThoatNuoc db = null;
        public CustomerDao()
        {
            db = new CapThoatNuoc();
        }
        public long InsertKH(khachhang entity)
        {
            db.khachhangs.Add(entity);
            db.SaveChanges();
            return entity.kh_id;
        }
        public bool UpdateKH(khachhang entity)
        {
            try
            {
                var kh = db.khachhangs.Find(entity.kh_id);
                kh.kh_hoten = entity.kh_hoten;
                kh.nh_id = entity.nh_id;
                kh.lkh_ma = entity.lkh_ma;
                kh.lt_id = entity.lt_id;
                kh.kh_masothue = entity.kh_masothue;
                kh.kh_diachilapdat = entity.kh_diachilapdat;
                kh.kh_diachithanhtoan = entity.kh_diachithanhtoan;
                kh.kh_stk = entity.kh_stk;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

       /* public bool CheckUserName(string userName)
        {
            return db.khachhangs.Count(x => x.kh_diachilapdat == userName) > 0;
        }*/

        public bool ChangeStatus(int id)
        {
            var kh = db.khachhangs.Find(id);
            kh.kh_trangthai = !kh.kh_trangthai;
            db.SaveChanges();
            return kh.kh_trangthai;
        }


        /* public bool DeleteKH(int id)
         {
             try
             {
                 var kh = db.KhachHangs.Find(id);
                 db.KhachHangs.Remove(kh);
                 db.SaveChanges();
                 return true;
             }
             catch (Exception)
             {
                 return false;
             }

         }*/

        public IEnumerable<khachhang> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<khachhang> model = db.khachhangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.kh_hoten.Contains(searchString) || x.kh_ma.Contains(searchString));
            }
            return model.OrderByDescending(x => x.kh_id).ToPagedList(page, pageSize);
        }

        public khachhang ViewDetail(int id)
        {
            return db.khachhangs.Find(id);
        }

        public List<loaikhachhang> ListAlllkh()
        {
            return db.loaikhachhangs.ToList();
        }

        public List<nganhang> ListAllnh()
        {
            return db.nganhangs.ToList();
        }

        public List<lotrinh> ListAlllt()
        {
            return db.lotrinhs.ToList();
        }

        public List<khachhang> ListAllmst()
        {
            return db.khachhangs.ToList();
        }

    }
}
