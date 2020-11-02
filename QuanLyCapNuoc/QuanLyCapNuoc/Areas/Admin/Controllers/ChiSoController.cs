using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Model.EF;
using Model.DAO;

namespace QuanLyCapNuoc.Areas.Admin.Controllers
{
    public class ChiSoController : BaseController
    {
        // GET: Admin/ChiSo
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var sess = Session[QuanLyCapNuoc.common.CommonConstants.NV_ID];
            var dao = new ChiSoDao();
            var model = dao.ListAllPagingkh(page, pageSize);
            return View(model);
        }

        // GET: Admin/ChiSo/Details/5
        public ActionResult Details(int id, int page = 1, int pageSize = 10)
        {

            var dao = new ChiSoDao();
            var model = dao.ListAllPaging(id, page, pageSize);
            return View(model);
        }

        // GET: Admin/ChiSo/Create
        public ActionResult Create(int id)
        {
            ViewBag.kh_id = id;
            return View();
        }

        // POST: Admin/ChiSo/Create
        [HttpPost]
        public ActionResult Create(chiso collection)
        {
            if (ModelState.IsValid)
            {
                var dao = new ChiSoDao();



                long id = dao.Insert(collection);
                if (id > 0)
                {
                    new BillController().Create(collection);

                    return RedirectToAction("Index", "ChiSo");
                }
                else
                {
                    ModelState.AddModelError("", "Ghi không thành công");
                }
            }
            return View("Index");
        }

        // GET: Admin/ChiSo/Edit/5
        public ActionResult Edit(int kh_id , int k_id)
        {
            var data = new ChiSoDao().ViewDetail(kh_id, k_id);
            ViewBag.kh_id = kh_id;
            ViewBag.k_id = k_id;
            return View(data);
        }

        // POST: Admin/ChiSo/Edit/5
        [HttpPost]
        public ActionResult Edit(int kh_id, chiso collection)
        {
            if (ModelState.IsValid)
            {
                var dao = new ChiSoDao();



                var result = dao.Update(collection);
                if (result)
                {

                    return RedirectToAction("Details/"+kh_id, "ChiSo");
                }
                else
                {
                    ModelState.AddModelError("", " không thành công");
                }
            }
            return View("Index");
        }

        // GET: Admin/ChiSo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ChiSo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
       
    }
}
