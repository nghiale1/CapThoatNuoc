using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using PagedList;

namespace QuanLyCapNuoc.Areas.Admin.Controllers
{
    public class KyGhiController : BaseController
    {
        // GET: Admin/KyGhi
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new KyGhiDao();
            var model = dao.ListAllPaging(page, pageSize);



            return View(model);
            
        }

        // GET: Admin/KyGhi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/KyGhi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KyGhi/Create
        [HttpPost]
        public ActionResult Create(kyghi collection)
        {
            if (ModelState.IsValid)
            {
                var dao = new KyGhiDao();



                long id = dao.Insert(collection);
                if (id > 0)
                {

                    return RedirectToAction("Index", "KyGhi");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Kì Ghi không thành công");
                }
            }
            return View("Index");
        }

        // GET: Admin/KyGhi/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new KyGhiDao();
            var content = dao.GetByID(id);



            return View(content);
        }

        // POST: Admin/KyGhi/Edit/5
        [HttpPost]
        public ActionResult Edit(kyghi collection, int id)
        {
            if (ModelState.IsValid)
            {
                var dao = new KyGhiDao();



                var result = dao.Update(collection, id);
                if (result)
                {

                    return RedirectToAction("Index", "KyGhi");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Index");
        }

        // GET: Admin/KyGhi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/KyGhi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, kyghi collection)
        {
            new KyGhiDao().Delete(id);

            return RedirectToAction("Index", "KyGhi");
        }
    }
}
