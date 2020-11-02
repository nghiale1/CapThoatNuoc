
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
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            
            return View();
        }
        [HasCredential(vt_id = 1)]
        public ActionResult HienThiChucVu()
        {
            DBchucvu db = new DBchucvu();
            //chucvu u = db.GetObj_chucvu("Chuc vu 1");
            List<chucvu> list = db.GetList_chucvu();
            //ViewData["list"] = list;
            return View(list);
        }
        [HttpGet]
        public ActionResult CreateChucVu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddChucVu(chucvu obj)
        {
            if (ModelState.IsValid)
            {
                var dao = new DBchucvu();
                long id = dao.Insert(obj);
                if (id > 0)
                {
                    return RedirectToAction("HienThiChucVu", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm dữ liệu thành công");

                }
            }
            return View("HienThiChucVu");
        }

        [HttpGet]
        public ActionResult EditChucVu(int id)
        {
            var chucvu = new DBchucvu().ViewDetail(id);
            return View(chucvu);
        }

        [HttpPost]
        public ActionResult EditChucVu(chucvu entity)
        {
            if (ModelState.IsValid)
            {
                var chucvu = new DBchucvu();
                var result = chucvu.Updatechucvu(entity);
                if (result)
                {
                    return RedirectToAction("HienThiChucVu", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật dữ liệu thành công");

                }
            }
            return View("HienThiChucVu");
        }
        
        public ActionResult DeleteChucVu(int id)
        {
            new DBchucvu().Xoachucvu(id);
            return RedirectToAction("HienThiChucVu", "Home");
        }
    }
}