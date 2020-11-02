using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;


namespace Model.DAO
{
    public class DBvaitro
    {
        CapThoatNuoc db = new CapThoatNuoc();

        public vaitro GetObj_vaitro(string ten)
        {
            return db.vaitroes.SingleOrDefault(c => c.vt_ten == ten);
        }

        public List<vaitro> GetList_vaitro()
        {
            return db.vaitroes.ToList();
        }

        public long Insert(vaitro entity)
        {
            db.vaitroes.Add(entity);
            db.SaveChanges();
            return entity.vt_id;
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public bool Updatevaitro(vaitro entity)
        {
            try
            {
                var vaitro = db.vaitroes.Find(entity.vt_id);
                vaitro.vt_ten = entity.vt_ten;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public vaitro ViewDetail(int id)
        {
            return db.vaitroes.Find(id);
        }
        public bool Xoavaitro(int id)
        {
            try
            {
                var vaitro = db.vaitroes.Find(id);
                db.vaitroes.Remove(vaitro);
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
