using Model.EF;
using System.Collections.Generic;
using System.Linq;

namespace Model.DAO
{
    public class UserTypeDao
    {
        CapThoatNuoc db = null;
        public UserTypeDao()
        {
            db = new CapThoatNuoc();
        }
        public int Insert(loaikhachhang entity)
        {
            db.loaikhachhangs.Add(entity);
            db.SaveChanges();
            return entity.lkh_ma;

        }
        public List<loaikhachhang> List()
        {
            return db.loaikhachhangs.ToList();
        }
        public loaikhachhang GetByID(int code)
        {
            return db.loaikhachhangs.SingleOrDefault(x => x.lkh_ma == code);
        }
        public bool Update(loaikhachhang entity)
        {
            var type = db.loaikhachhangs.Find(entity.lkh_ma);
            type.lkh_ten = entity.lkh_ten;
            type.lkh_dongia = entity.lkh_dongia;
            db.SaveChanges();
            return true;

        }
        public bool Destroy(int code)
        {
            var check = db.khachhangs.FirstOrDefault(x => x.lkh_ma == code);
            //check khóa ngoại
            if (check == null)
            {

                var type = db.loaikhachhangs.Find(code);
                db.loaikhachhangs.Remove(type);
                db.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
