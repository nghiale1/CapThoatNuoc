using Model.EF;
using System.Collections.Generic;
using System.Linq;

namespace Model.DAO
{
    public class BankDao
    {
        CapThoatNuoc db = null;
        public BankDao()
        {
            db = new CapThoatNuoc();
        }
        public int Insert(nganhang entity)
        {
            db.nganhangs.Add(entity);
            db.SaveChanges();
            return entity.nh_id;

        }
        public List<nganhang> List()
        {
            return db.nganhangs.ToList();
        }
        public nganhang GetByID(int code)
        {
            return db.nganhangs.SingleOrDefault(x => x.nh_id == code);
        }
        public bool Update(nganhang entity)
        {
            var type = db.nganhangs.Find(entity.nh_id);
            //type.nh_id = entity.nh_id;
            type.nh_ten = entity.nh_ten;
            type.nh_ma = entity.nh_ma;
            db.SaveChanges();
            return true;

        }
        public bool Destroy(int code)
        {
            var check = db.khachhangs.FirstOrDefault(x => x.nh_id == code);
            //check khóa ngoại
            if (check == null)
            {

                var type = db.nganhangs.Find(code);
                db.nganhangs.Remove(type);
                db.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
