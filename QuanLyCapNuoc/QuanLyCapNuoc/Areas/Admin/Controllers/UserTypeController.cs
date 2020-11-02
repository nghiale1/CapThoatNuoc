using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace QuanLyCapNuoc.Areas.Admin.Controllers
{
    public class UserTypeController : Controller
    {
        // GET: Admin/UserType
        public ActionResult Index()
        {
            UserTypeDao db = new UserTypeDao();
            List<loaikhachhang> list = db.List();
            loaikhachhang type = new loaikhachhang();
            ViewData["list"] = list;
            ViewData["type"] = type;
            return View();
        }
        public ActionResult Store(loaikhachhang model)
        {
            try
            {

                UserTypeDao db = new UserTypeDao();
                db.Insert(model);
                if (TempData["ModelSuccess"] == null)
                    TempData.Add("ModelSuccess", "Thêm thành công.");
                return RedirectToAction("Index", "UserType");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (TempData["ModelErrors"] == null)
                TempData.Add("ModelErrors", "Có lỗi xảy ra! Không thể thêm.");
            return RedirectToAction("Index", "UserType");
        }
        public ActionResult Edit(int code)
        {
            var type = new UserTypeDao().GetByID(code);
            return View(type);
        }
        public ActionResult Update(loaikhachhang model)
        {
            try
            {
                var type = new UserTypeDao().Update(model);
                if (TempData["ModelSuccess"] == null)
                    TempData.Add("ModelSuccess", "Cập nhật thành công.");
                return RedirectToAction("Index", "UserType");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (TempData["ModelErrors"] == null)
                TempData.Add("ModelErrors", "Có lỗi xảy ra! Không thể cập nhật.");
            return RedirectToAction("Index", "UserType");


        }
        public ActionResult Destroy(int code)
        {
            try
            {

                var type = new UserTypeDao().Destroy(code);
                if (TempData["ModelSuccess"] == null)
                    TempData.Add("ModelSuccess", "Xóa thành công.");
                return RedirectToAction("Index", "UserType");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (TempData["ModelErrors"] == null)
                TempData.Add("ModelErrors", "Có lỗi xảy ra! Không thể xóa.");
            return RedirectToAction("Index", "UserType");
        }
    }
}