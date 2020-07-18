using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.Dao
{
    public class NVDao
    {
        CapThoatNuocDbContext db = null;
        public NVDao()
        {
            db = new CapThoatNuocDbContext();
        }
        public long Insert(NhanVien entity)
        {
            db.NhanViens.Add(entity);
            db.SaveChanges();
            return entity.nv_id;
        }
        public bool Login(string Username, string Password)
        {
            var result = db.NhanViens.Count(x => x.nv_tendangnhap == Username && x.nv_matkhau == Password);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
