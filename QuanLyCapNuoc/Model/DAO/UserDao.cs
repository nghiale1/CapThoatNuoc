using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Common;
using Model.EF;
using PagedList;
using PagedList.Mvc;

namespace Model.DAO
{

    public class UserDao
    {
        CapThoatNuoc db = null;
        public UserDao()
        {
            db = new CapThoatNuoc();
        }

        public long Insert(nhanvien entity)
        {
            
            db.nhanviens.Add(entity);
            db.SaveChanges();
            return entity.nv_id;
        }

        public IEnumerable<nhanvien> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<nhanvien> model = db.nhanviens;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.nv_hoten.Contains(searchString) || x.nv_maso.Contains(searchString));
            }
            return model.OrderByDescending(x => x.nv_id).ToPagedList(page, pageSize);
        }

        public nhanvien GetByID(string username)
        {
            return db.nhanviens.SingleOrDefault(x => x.nv_tendangnhap == username);
        }

        public nhanvien ViewDetail(int id)
        {
            return db.nhanviens.Find(id);
        }

        public List<int> GetListCredential(string userName)
        {
            var user = db.nhanviens.Single(x => x.nv_tendangnhap == userName);
            var data =  (from a in db.vt_cv
                        join b in db.chucvus on a.cv_id equals b.cv_id
                        join c in db.vaitroes on a.vt_id equals c.vt_id
                        where b.cv_id == user.cv_id
                        select new
                        {
                            vt_id = a.vt_id,
                            cv_id = a.cv_id
                        }).AsEnumerable().Select(x => new vt_cv()
                        {
                            vt_id = x.vt_id,
                            cv_id = x.cv_id
                        });           
            
            return data.Select(x => x.vt_id).ToList();

        }

        public int Login(string username, string password, bool isLoginAdmin = false)
        {
            var result = db.nhanviens.SingleOrDefault(x => x.nv_tendangnhap == username);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    /*if (result.chucvu.cv_ten == CommonConstants.ADMIN_GROUP || result.chucvu.cv_ten == CommonConstants.TK_GROUP || result.chucvu.cv_ten == CommonConstants.NV_GROUP)
                    {*/
                        if (result.nv_trangthai == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.nv_matkhau == password)
                        {
                            return 1;
                        }
                        else
                            return -2;
                        }

                    //}
                   /* else
                    {
                        return -3;
                    }*/
                }
                else
                {
                    if (result.nv_trangthai == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.nv_matkhau == password)
                        return 1;
                    else
                        return -2;
                    }
                }
            }
        }
        /* public bool Update(NhanVien entity)
         {
             try
             {
                 var nv = db.NhanViens.Find(entity.nv_id);
                 nv.nv_hoten = entity.nv_hoten;
                 db.SaveChanges();
                 return true;
             }
             catch (Exception ex)
             {
                 return false;
             }
         }*/
        public bool ChangeStatus(int id)
        {
            var nv = db.nhanviens.Find(id);
            nv.nv_trangthai = !nv.nv_trangthai;
            db.SaveChanges();
            return nv.nv_trangthai;
        }
        public bool CheckUserName(string userName)
        {
            var nv= db.nhanviens.Count(x => x.nv_tendangnhap == userName) > 0;
            return nv;
        }

        public List<chucvu> ListAll()
        {
            return db.chucvus.ToList();
        }
    }
}