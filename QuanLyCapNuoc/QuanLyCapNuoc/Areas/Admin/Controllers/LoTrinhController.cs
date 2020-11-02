using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using PagedList;

namespace QuanLyCapNuoc.Areas.Admin.Controllers
{
    public class LoTrinhController : BaseController
    {
        // GET: Admin/LoTrinh
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new LoTrinhDao();
            var model = dao.ListAllPaging(page, pageSize);



            return View(model);
        }

        // GET: Admin/LoTrinh/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/LoTrinh/Create
        public ActionResult Create()
        {
            List<khuvuc> listkv = new LoTrinhDao().GetList_kv();
            ViewData["listkv"] = listkv;
           
            return View();
        }

        // POST: Admin/LoTrinh/Create
        [HttpPost]
        public ActionResult Create(lotrinh collection)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoTrinhDao();

                long id = dao.Insert(collection);
                if (id > 0)
                {

                    return RedirectToAction("Index", "LoTrinh");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View("Index");
        }

        // GET: Admin/LoTrinh/Edit/5
        public ActionResult Edit(int id)
        {
            var dao = new LoTrinhDao();
            var content = dao.GetByID(id);

            List<khuvuc> listkv = new LoTrinhDao().GetList_kv();
            ViewData["listkv"] = listkv;

            return View(content);
        }

        // POST: Admin/LoTrinh/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, lotrinh collection)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoTrinhDao();



                var result = dao.Update(collection, id);
                if (result)
                {

                    return RedirectToAction("Index", "LoTrinh");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Index");
        }

        // GET: Admin/LoTrinh/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/LoTrinh/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, lotrinh collection)
        {
            new LoTrinhDao().Delete(id);

            return RedirectToAction("Index", "LoTrinh");
        }

        
    }
}
