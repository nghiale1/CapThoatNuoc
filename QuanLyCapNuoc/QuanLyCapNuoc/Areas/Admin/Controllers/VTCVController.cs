
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
    public class VTCVController : Controller
    {
        // GET: Admin/VTCV

        public ActionResult Index()
        {
            return View();
        }
        [HasCredential(vt_id = 1)]
        public ActionResult HienThiVTCV()
        {
            DB_VTCV db = new DB_VTCV();
            List<vt_cv> list = db.GetList_VTCV();
            return View(list);
        }
        [HttpGet]
        public ActionResult CreateVTCV()
        {
            List<vaitro> listVT = new DB_VTCV().GetList_VT();
            ViewData["listVT"] = listVT;
            List<chucvu> listCV = new DB_VTCV().GetList_CV();
            ViewData["listCV"] = listCV;
            return View();

        }

        [HttpPost]
        public ActionResult AddVTCV(vt_cv obj)
        {
            if (ModelState.IsValid)
            {
                var dao = new DB_VTCV();
                long id = dao.Insert(obj);
                if (id > 0)
                {
                    return RedirectToAction("HienThiVTCV", "VTCV");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm dữ liệu thành công");

                }
            }
            return View("HienThiVTCV", "VTCV");
        }
  
        public ActionResult DeleteVTCV(int idVT, int idCV)
        {
            new DB_VTCV().XoaVTCV(idCV, idVT);
            return RedirectToAction("HienThiVTCV", "VTCV");
        }
        [HttpGet]
        public ActionResult EditVTCV(int idVT, int idCV)
        {
            var vtcv = new DB_VTCV().ViewDetailVTCV(idVT, idCV);
            List<vaitro> listVT = new DB_VTCV().GetList_VT();
            ViewData["listVT"] = listVT;
            List<chucvu> listCV = new DB_VTCV().GetList_CV();
            ViewData["listCV"] = listCV;
            return View(vtcv);
        }

        [HttpPost]
        public ActionResult EditVTCV(vt_cv entity)
        {
            if (ModelState.IsValid)
            {
                var cvvt = new DB_VTCV();
                var result = cvvt.UpdateVTCV(entity);
                if (result)
                {
                    return RedirectToAction("HienThiVTCV", "VTCV");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật dữ liệu thành công");

                }
            }
            return View("HienThiVTCV");
        }

    }
}