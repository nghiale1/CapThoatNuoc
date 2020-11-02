using QuanLyCapNuoc.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using QuanLyCapNuoc.common;

namespace QuanLyCapNuoc.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.nv_tendangnhap, Encrypter.MD5Hash(model.nv_matkhau), true);
                if (result == 1)
                {
                    var user = dao.GetByID(model.nv_tendangnhap);
                    var nvSession = new UserLogin();
                    nvSession.nv_tendangnhap = user.nv_tendangnhap;
                    nvSession.nv_id = user.nv_id;
                    nvSession.cv_id = user.chucvu.cv_id;
                    var listCredential = dao.GetListCredential(model.nv_tendangnhap);
                    Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredential);
                    Session.Add(CommonConstants.NV_SESSION, nvSession);
            
                    Session.Add(
                        CommonConstants.NV_ID, nvSession.nv_id);
            
                    
                    return RedirectToAction("Index", "Home");
                }
                else if(result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đã bị khóa");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Tài khoản không có quyền đăng nhập");
                }
                else
                    ModelState.AddModelError("", "Đăng nhập không thành công");
            }
            return View("Index");
        }
    }
}