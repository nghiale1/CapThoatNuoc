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
    public class KyThuController : BaseController
    {
        // GET: Admin/KyThu
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new KyThuDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        // GET: Admin/KyThu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/KyThu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KyThu/Create
        [HttpPost]
        public ActionResult Create(kythu collection)
        {
            if (ModelState.IsValid)
            {
                var dao = new KyThuDao();



                long id = dao.Insert(collection);
                if (id > 0)
                {

                    return RedirectToAction("Index", "KyThu");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Kỳ Thu không thành công");
                }
            }
            return View("Index");
        }

        // GET: Admin/KyThu/Edit/5
        public ActionResult Edit(int id)
        {
            var dao = new KyThuDao();
            var content = dao.GetByID(id);



            return View(content);
        }

        // POST: Admin/KyThu/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, kythu collection)
        {
            if (ModelState.IsValid)
            {
                var dao = new KyThuDao();



                var result = dao.Update(collection, id);
                if (result)
                {

                    return RedirectToAction("Index", "KyThu");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Index");
        }

        // GET: Admin/KyThu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/KyThu/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, kythu collection)
        {
            new KyThuDao().Delete(id);

            return RedirectToAction("Index", "KyThu");
        }
    }
}
