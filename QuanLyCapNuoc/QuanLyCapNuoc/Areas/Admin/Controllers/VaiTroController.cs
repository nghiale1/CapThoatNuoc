
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
    public class VaiTroController : Controller
    {
        // GET: Admin/vaitro
        
        public ActionResult Index()
        {
            return View();
        }
        [HasCredential(vt_id = 1)]
        public ActionResult HienThiVaiTro()
        {
            DBvaitro db = new DBvaitro();
            //ChucVu u = db.GetObj_Chucvu("Chuc vu 1");
            List<vaitro> list = db.GetList_vaitro();
            //ViewData["list"] = list;
            return View(list);
        }
        [HttpGet]
        public ActionResult CreateVaiTro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddVaiTro(vaitro obj)
        {
            if (ModelState.IsValid)
            {
                var dao = new DBvaitro();
                long id = dao.Insert(obj);
                if (id > 0)
                {
                    return RedirectToAction("HienThiVaiTro", "VaiTro");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm dữ liệu thành công");

                }
            }
            return View("HienThiVaiTro");
        }

        [HttpGet]
        public ActionResult EditVaiTro(int id)
        {
            var vaitro = new DBvaitro().ViewDetail(id);
            return View(vaitro);
        }

        [HttpPost]
        public ActionResult EditVaiTro(vaitro entity)
        {
            if (ModelState.IsValid)
            {
                var vaitro = new DBvaitro();
                var result = vaitro.Updatevaitro(entity);
                if (result)
                {
                    return RedirectToAction("HienThiVaiTro", "VaiTro");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật dữ liệu thành công");

                }
            }
            return View("HienThiVaiTro");
        }

        public ActionResult DeleteVaiTro(int id)
        {
            new DBvaitro().Xoavaitro(id);
            return RedirectToAction("HienThiVaiTro", "VaiTro");
        }
    }
}