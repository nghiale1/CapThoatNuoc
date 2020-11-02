using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class DongHoDao
    {
        CapThoatNuoc db = null;
        public static string USER_SESSION = "USER_SESSION";
        public DongHoDao()
        {
            db = new CapThoatNuoc();
        }

        public long Insert(dongho entity)
        {
            db.donghoes.Add(entity);
            db.SaveChanges();
            return entity.dh_id;
        }

        public bool Update(dongho entity, int id)
        {



            try
            {
                var dongho = db.donghoes.Find(id);

                dongho.kh_id = entity.kh_id;
                dongho.dh_thuonghieu = entity.dh_thuonghieu;
                dongho.dh_maso = entity.dh_maso;
                dongho.dh_ngaykiemdinh = entity.dh_ngaykiemdinh;
                dongho.dh_ngaylap = entity.dh_ngaylap;
                

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public IEnumerable<dongho> ListAllPaging(int page, int pageSize)
        {
            IQueryable<dongho> model = db.donghoes;

            return model.OrderByDescending(x => x.dh_id).ToPagedList(page, pageSize);
        }

        public dongho GetByID(long id)
        {
            return db.donghoes.Find(id);
        }


        public dongho ViewDetail(int id)
        {
            return db.donghoes.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var dongho = db.donghoes.Find(id);
                db.donghoes.Remove(dongho);
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
