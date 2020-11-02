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
    public class DongHoController : BaseController
    {
        // GET: Admin/DongHo
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new DongHoDao();
            var model = dao.ListAllPaging(page, pageSize);



            return View(model);
            
        }

        // GET: Admin/DongHo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/DongHo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DongHo/Create
        [HttpPost]
        public ActionResult Create(dongho entity)
        {

            if (ModelState.IsValid)
            {
                var dao = new DongHoDao();



                long id = dao.Insert(entity);
                if (id > 0)
                {

                    return RedirectToAction("Index", "DongHo");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View("Index");

        }

        // GET: Admin/DongHo/Edit/5
        public ActionResult Edit(int id)
        {

            var dao = new DongHoDao();
            var content = dao.GetByID(id);



            return View(content);
        }

        // POST: Admin/DongHo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, dongho dongho)
        {
            if (ModelState.IsValid)
            {
                var dao = new DongHoDao();



                var result = dao.Update(dongho, id);
                if (result)
                {

                    return RedirectToAction("Index", "DongHo");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user không thành công");
                }
            }
            return View("Index");
        }



        // POST: Admin/DongHo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            new DongHoDao().Delete(id);

            return RedirectToAction("Index","DongHo");

        }
    }
}
