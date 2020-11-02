using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;


namespace Model.DAO
{
    public class DBchucvu
    {
        CapThoatNuoc db = new CapThoatNuoc();

        public chucvu GetObj_chucvu(string ten)
        {
            return db.chucvus.SingleOrDefault(c => c.cv_ten == ten);
        }

        public List<chucvu> GetList_chucvu()
        {
            return db.chucvus.ToList();
        }

        public long Insert(chucvu entity)
        {
            db.chucvus.Add(entity);
            db.SaveChanges();
            return entity.cv_id;
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public bool Updatechucvu(chucvu entity)
        {
            try
            {
                var chucvu = db.chucvus.Find(entity.cv_id);
                chucvu.cv_ten = entity.cv_ten;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public chucvu ViewDetail(int id)
        {
            return db.chucvus.Find(id);
        }
        public bool Xoachucvu(int id)
        {
            try
            {
                var chucvu = db.chucvus.Find(id);
                db.chucvus.Remove(chucvu);
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
