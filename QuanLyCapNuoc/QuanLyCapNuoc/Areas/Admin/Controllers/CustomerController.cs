using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using PagedList.Mvc;
using PagedList;
using Model.EF;

namespace QuanLyCapNuoc.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Admin/Customer
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new CustomerDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<nganhang> listnh = new CustomerDao().ListAllnh();
            ViewData["listnh"] = listnh;

            List<loaikhachhang> listlkh = new CustomerDao().ListAlllkh();
            ViewData["listlkh"] = listlkh;

            List<lotrinh> listlt = new CustomerDao().ListAlllt();
            ViewData["listlt"] = listlt;

            List<khachhang> listmst = new CustomerDao().ListAllmst();
            ViewData["listmst"] = listmst;

            return View();
        }


        public ActionResult Edit(int id)
        {
            List<nganhang> listnh = new CustomerDao().ListAllnh();
            ViewData["listnh"] = listnh;

            List<loaikhachhang> listlkh = new CustomerDao().ListAlllkh();
            ViewData["listlkh"] = listlkh;

            List<lotrinh> listlt = new CustomerDao().ListAlllt();
            ViewData["listlt"] = listlt;

            List<khachhang> listmst = new CustomerDao().ListAllmst();
            ViewData["listmst"] = listmst;

            var kh = new CustomerDao().ViewDetail(id);
            return View(kh);
        }

        [HttpPost]
        public ActionResult Create(khachhang kh)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
               /* if (dao.CheckUserName(kh.KH_DIACHILAPDAT))
                {
                    ModelState.AddModelError("", "Khách hàng đã tồn tại");
                }*/

                /*else
                {*/
                    long id = dao.InsertKH(kh);
                if (id > 0)
                {
                    //SetAlert("Thêm user thành công", "success");
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm khách hàng không thành công");
                }

                //}
            }
            return  RedirectToAction("Index", "Customer"); 
        }

        [HttpPost]
        //[HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(khachhang kh)
        {

            var dao = new CustomerDao();

            var result = dao.UpdateKH(kh);
            if (result)
            {
                SetAlert("Sửa user thành công", "success");
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật khách hàng không thành công");
            }
        
            return RedirectToAction("Index", "Customer");
        }

        /*[HttpDelete]
        public ActionResult Delete(int id)
        {
            new CustomerDao().Delete(id);
            return RedirectToAction("Index");
        }*/
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = new CustomerDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}