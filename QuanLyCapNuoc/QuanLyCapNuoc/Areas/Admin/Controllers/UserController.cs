using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using QuanLyCapNuoc.common;
using PagedList.Mvc;
using PagedList;
using OnlineShop;

namespace QuanLyCapNuoc.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        [HasCredential(vt_id = 1)]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        
        [HttpGet]
        [HasCredential(vt_id = 2)]
        public ActionResult Create()
        {
            List<chucvu> listcv = new UserDao().ListAll();
            ViewData["listcv"] = listcv;
            return View();
        }

        public ActionResult Edit(int id)
        {
            var nv = new UserDao().ViewDetail(id);
            return View(nv);
        }

        [HttpPost]
        [HasCredential(vt_id =2)]
        public ActionResult Create(nhanvien nv)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckUserName(nv.nv_tendangnhap))
                {
                    ModelState.AddModelError("", "Nhân viên đã tồn tại");
                }
                else
                {
                    var EncrypterMD5 = Encrypter.MD5Hash(nv.nv_matkhau);
                    nv.nv_matkhau = EncrypterMD5;
                    long id = dao.Insert(nv);
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        SetAlert("Thêm user thành công", "success");
                        ModelState.AddModelError("", "Thêm nhân viên không thành công");
                    }
                }
            }
        
            return RedirectToAction("Index", "User");
        }
        /*[HttpPost]
        public ActionResult Edit(NhanVien nv)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(nv.nv_matkhau))
                {
                    var EncrypterMD5 = Encrypter.MD5Hash(nv.nv_matkhau);
                    nv.nv_matkhau = EncrypterMD5;
                }

                var result = dao.Update(nv);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thành công");
                }
            }
            return View("Index");
        }*/
        
        [HttpPost]
        [HasCredential(vt_id = 3)]
        public JsonResult ChangeStatus(int id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        /*public void SetViewBag(int? selectedId = null)
        {
            var dao = new UserDao();
            ViewBag.NHANVIENNV_ID = new SelectList(dao.ListAll(), "NV_ID", "CV_ID", selectedId);
        }*/

        public ActionResult Logout()
        {
            Session[CommonConstants.NV_SESSION] = null;
            return Redirect("/");
        }
    }
}