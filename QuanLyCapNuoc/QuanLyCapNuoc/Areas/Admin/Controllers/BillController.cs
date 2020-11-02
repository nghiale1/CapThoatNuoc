using Model.DAO;
using Model.EF;
using Model.ViewModel;
using QuanLyCapNuoc.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyCapNuoc.Areas.Admin.Controllers
{
    public class BillController : Controller
    {
        // GET: Admin/Bill
        public ActionResult Index()
        {
            var ss = (UserLogin)System.Web.HttpContext.Current.Session[QuanLyCapNuoc.common.CommonConstants.NV_SESSION];
            return View();
        }
        public ActionResult ListBill(int kh_id)
        {
            BillDao db = new BillDao();
            List<BillViewModel> list = db.ListBill(kh_id);
            ViewData["list"] = list;
            var check = list.Count();

            if (check > 0)
            {
                ViewBag.status = true;
            }
            else
            {
                ViewBag.status = false;
            }
            return View();
        }
        public void Create(chiso entity)
        {

            
            //BillDao db = new BillDao();
            //int list = db.GetOldBill(1);
            //var ss = (UserLogin)System.Web.HttpContext.Current.Session[QuanLyCapNuoc.common.CommonConstants.NV_SESSION];
            BillDao db = new BillDao();


            var hd_luongtieuthu = 0;
            var hd_chisokytruoc1 = 0;
            var hd_tieuthukytruoc1 = 0;
            var hd_chisokytruoc2 = 0;
            var hd_tieuthukytruoc2 = 0;


            //Lấy hóa đơn cuối cùng và hóa đơn kỳ trước và trước nữa
            //lấy chỉ số cuối cùng
            //lấy chỉ số dựa trên các hd trước
            //tính lượng tiêu thụ
            //var hd_chisokynay = db.GetLastIndex(kh_id);
            var hd_chisokynay = entity.cs_chiso;
            var check_hd_chisokytruoc1 = db.GetLastBill(entity.kh_id);
            if (check_hd_chisokytruoc1 != null)
            {
                hd_chisokytruoc1 = check_hd_chisokytruoc1.cs_chiso;
                hd_luongtieuthu = (hd_chisokynay) - (hd_chisokytruoc1);
                var check_hd_chisokytruoc2 = db.GetIndexBefore(entity.kh_id, check_hd_chisokytruoc1.k_id);
                if (check_hd_chisokytruoc2 != null)
                {
                    hd_chisokytruoc2 = check_hd_chisokytruoc2.cs_chiso;
                    hd_tieuthukytruoc1 = db.GetChiSo(entity.kh_id, check_hd_chisokytruoc1.k_id).cs_chiso;
                    var check_hd_chisokytruoc3 = db.GetIndexBefore(entity.kh_id, check_hd_chisokytruoc2.k_id);
                    if (check_hd_chisokytruoc3 != null)
                    {

                        hd_tieuthukytruoc2 = db.GetChiSo(entity.kh_id, check_hd_chisokytruoc3.k_id).cs_chiso - db.GetChiSo(entity.kh_id, check_hd_chisokytruoc3.k_id).cs_chiso;
                    }
                }
                else
                {
                    hd_tieuthukytruoc1 = 0;
                    hd_chisokytruoc2 = 0;
                    hd_tieuthukytruoc2 = 0;
                }
            }
            else
            {
                hd_luongtieuthu = entity.cs_chiso;
                hd_chisokytruoc1 = 0;
                hd_tieuthukytruoc1 = 0;
                hd_chisokytruoc2 = 0;
                hd_tieuthukytruoc2 = 0;

            }






            //lấy đơn giá
            var temp = db.GetLKH(entity.kh_id);
            var dongia = db.GetUnitPrice(temp);
            var bill = new hoadon();
            bill.nv_id = (int)((UserLogin)System.Web.HttpContext.Current.Session[QuanLyCapNuoc.common.CommonConstants.NV_SESSION]).nv_id;
            bill.kh_id = entity.kh_id;
            bill.k_id = entity.k_id;
            bill.hd_ngaylap = DateTime.Now;
            bill.hd_dongia = dongia;
            bill.hd_pttt = "Tiền mặt";
            bill.hd_luongtieuthu = hd_luongtieuthu;
            bill.hd_chisokytruoc1 = hd_chisokytruoc1;
            bill.hd_tieuthukytruoc1 = hd_tieuthukytruoc1;
            bill.hd_chisokytruoc2 = hd_chisokytruoc2;
            bill.hd_tieuthukytruoc2 = hd_tieuthukytruoc2;
            bill.hd_tongtien = hd_luongtieuthu * (int)dongia;

            bool list = db.Insert(bill);


            //return RedirectToAction("Index", "Bill");
            
        }
        public ActionResult Paid(hoadon hd)
        {
            int nv_id= (int)((UserLogin)System.Web.HttpContext.Current.Session[QuanLyCapNuoc.common.CommonConstants.NV_SESSION]).nv_id;
            BillDao db = new BillDao();
            db.Paid(hd.hd_id,nv_id);
            return RedirectToAction("Show", "Bill", new { hd.hd_id });
        }


        //123 => một trăm hai ba đồng
        //1,123,000=>một triệu một trăm hai ba nghìn đồng
        //1,123,345,000 => một tỉ một trăm hai ba triệu ba trăm bốn lăm ngàn đồng

        string[] mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
        //Viết hàm chuyển số hàng chục, giá trị truyền vào là số cần chuyển và một biến đọc phần lẻ hay không ví dụ 101 => một trăm lẻ một
        private string DocHangChuc(double so, bool daydu)
        {
            string chuoi = "";
            //Hàm để lấy số hàng chục ví dụ 21/10 = 2
            Int64 chuc = Convert.ToInt64(Math.Floor((double)(so / 10)));
            //Lấy số hàng đơn vị bằng phép chia 21 % 10 = 1
            Int64 donvi = (Int64)so % 10;
            //Nếu số hàng chục tồn tại tức >=20
            if (chuc > 1)
            {
                chuoi = " " + mNumText[chuc] + " mươi";
                if (donvi == 1)
                {
                    chuoi += " mốt";
                }
            }
            else if (chuc == 1)
            {//Số hàng chục từ 10-19
                chuoi = " mười";
                if (donvi == 1)
                {
                    chuoi += " một";
                }
            }
            else if (daydu && donvi > 0)
            {//Nếu hàng đơn vị khác 0 và có các số hàng trăm ví dụ 101 => thì biến daydu = true => và sẽ đọc một trăm lẻ một
                chuoi = " lẻ";
            }
            if (donvi == 5 && chuc >= 1)
            {//Nếu đơn vị là số 5 và có hàng chục thì chuỗi sẽ là " lăm" chứ không phải là " năm"
                chuoi += " lăm";
            }
            else if (donvi > 1 || (donvi == 1 && chuc == 0))
            {
                chuoi += " " + mNumText[donvi];
            }
            return chuoi;
        }
        private string DocHangTram(double so, bool daydu)
        {
            string chuoi = "";
            //Lấy số hàng trăm ví du 434 / 100 = 4 (hàm Floor sẽ làm tròn số nguyên bé nhất)
            Int64 tram = Convert.ToInt64(Math.Floor((double)so / 100));
            //Lấy phần còn lại của hàng trăm 434 % 100 = 34 (dư 34)
            so = so % 100;
            if (daydu || tram > 0)
            {
                chuoi = " " + mNumText[tram] + " trăm";
                chuoi += DocHangChuc(so, true);
            }
            else
            {
                chuoi = DocHangChuc(so, false);
            }
            return chuoi;
        }
        private string DocHangTrieu(double so, bool daydu)
        {
            string chuoi = "";
            //Lấy số hàng triệu
            Int64 trieu = Convert.ToInt64(Math.Floor((double)so / 1000000));
            //Lấy phần dư sau số hàng triệu ví dụ 2,123,000 => so = 123,000
            so = so % 1000000;
            if (trieu > 0)
            {
                chuoi = DocHangTram(trieu, daydu) + " triệu";
                daydu = true;
            }
            //Lấy số hàng nghìn
            Int64 nghin = Convert.ToInt64(Math.Floor((double)so / 1000));
            //Lấy phần dư sau số hàng nghin 
            so = so % 1000;
            if (nghin > 0)
            {
                chuoi += DocHangTram(nghin, daydu) + " nghìn";
                daydu = true;
            }
            if (so > 0)
            {
                chuoi += DocHangTram(so, daydu);
            }
            return chuoi;
        }
        public string ChuyenSoSangChuoi(double so)
        {
            if (so == 0)
                return mNumText[0];
            string chuoi = "", hauto = "";
            Int64 ty;
            do
            {
                //Lấy số hàng tỷ
                ty = Convert.ToInt64(Math.Floor((double)so / 1000000000));
                //Lấy phần dư sau số hàng tỷ
                so = so % 1000000000;
                if (ty > 0)
                {
                    chuoi = DocHangTrieu(so, true) + hauto + chuoi;
                }
                else
                {
                    chuoi = DocHangTrieu(so, false) + hauto + chuoi;
                }
                hauto = " tỷ";
            } while (ty > 0);
            return chuoi + " đồng";
        }
        public ActionResult Show(int hd_id)
        {

            var hoadon = new BillDao().Show(hd_id);
            ViewData["bangChu"] = ChuyenSoSangChuoi((double)hoadon.hd_tongtien);
            return View(hoadon);
            
        }
        public ActionResult Statistic()
        {
            BillDao db = new BillDao();
            List<lotrinh> lt = db.DanhSachLoTrinh();
            List<kyghi> kg = db.DanhSachKyGhi();
            ViewData["lt"] = lt;
            ViewData["kg"] = kg;
            return View();
        }
        public JsonResult StatisticSubmit(int lotrinh, int kyghi)
        { 
            
            BillDao db = new BillDao();
            var result = new StatisticViewModel();
            if (lotrinh == 0 && kyghi == 0)
            {
                 result = db.StatisticAll();
            }
            else if (lotrinh != 0 && kyghi == 0){
                 result = db.StatisticLT(lotrinh);
            }
            else if(lotrinh == 0 && kyghi != 0){
                 result = db.StatisticKG(kyghi);
            }
            else
            {
                 result = db.StatisticLTKG(lotrinh, kyghi);
            }
            var data = new { lt_ten = result.lt_ten, k_ten =result.k_ten, soho=result.soho, sonuoc = result.sonuoc, tongtien=result.tongtien };
            var j=Json(data, JsonRequestBehavior.AllowGet);
            return j;
        }
    }

}