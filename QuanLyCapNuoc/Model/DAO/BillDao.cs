using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.DAO
{
    public class BillDao
    {
        CapThoatNuoc db = null;
        public BillDao()
        {
            db = new CapThoatNuoc();
        }
        public int Insert(lotrinh entity)
        {

            db.lotrinhs.Add(entity);
            db.SaveChanges();
            return entity.lt_id;

        }
        public hoadon GetByID(int code)
        {
            return db.hoadons.SingleOrDefault(x => x.hd_id == code);
        }

        public List<BillViewModel> ListBill(int kh_id)
        {
            string SQL = "SELECT kh.kh_hoten,hd_luongtieuthu,hd_dongia,kg.k_ngaybatdau,kh.kh_diachilapdat,hd_tongtien,lt_ten,kg.k_ngaybatdau,HoaDon.hd_id,hd_trangthai FROM dbo.KhachHang AS kh LEFT JOIN dbo.LoTrinh AS lt ON lt.lt_id = kh.lt_id LEFT JOIN dbo.ChiSo AS cs ON cs.kh_id = kh.kh_id LEFT JOIN (SELECT MAX(kg.k_ngaybatdau) AS nbd, kg.k_id,kg.k_ngaybatdau FROM dbo.KyGhi AS kg GROUP BY kg.k_id,kg.k_ngaybatdau) AS kg ON kg.k_id = cs.k_id LEFT JOIN dbo.HoaDon ON HoaDon.k_id = kg.k_id  WHERE HoaDon.kh_id='" + kh_id + "' ORDER BY hd_trangthai";
            return db.Database.SqlQuery<BillViewModel>(SQL).ToList();


        }
        public List<lotrinh> DanhSachLoTrinh()
        {
            return db.lotrinhs.OrderByDescending(s => s.lt_id).ToList();
        }
        public List<kyghi> DanhSachKyGhi()
        {
            return db.kyghis.OrderByDescending(s=>s.k_id).ToList();
        }
        public StatisticViewModel StatisticAll()
        {
            string SQL = "SELECT COUNT(*) AS soho,SUM(hd_luongtieuthu) AS sonuoc,SUM(hd_tongtien) AS tongtien FROM dbo.HoaDon ";
            var result = db.Database.SqlQuery<StatisticViewModel>(SQL).FirstOrDefault();
            return result;
        }
        public StatisticViewModel StatisticLT(int lotrinh)
        {
            string SQL = "SELECT lt_ten,COUNT(*) AS soho,SUM(hd_luongtieuthu) AS sonuoc,SUM(hd_tongtien) AS tongtien FROM dbo.HoaDon INNER JOIN dbo.KhachHang ON khachhang.kh_id = hoadon.kh_id INNER JOIN dbo.LoTrinh ON LoTrinh.lt_id = KhachHang.lt_id INNER JOIN dbo.KyGhi ON kyghi.k_id = hoadon.k_id WHERE lotrinh.lt_id='" + lotrinh+"' GROUP BY lt_ten";
            var result = db.Database.SqlQuery<StatisticViewModel>(SQL).FirstOrDefault();
            return result;
        }
        public StatisticViewModel StatisticKG(int kyghi)
        {
            string SQL = "SELECT k_ten,COUNT(*) AS soho,SUM(hd_luongtieuthu) AS sonuoc,SUM(hd_tongtien) AS tongtien FROM dbo.HoaDon INNER JOIN dbo.KhachHang ON khachhang.kh_id = hoadon.kh_id INNER JOIN dbo.LoTrinh ON LoTrinh.lt_id = KhachHang.lt_id INNER JOIN dbo.KyGhi ON kyghi.k_id = hoadon.k_id WHERE kyghi.k_id='" + kyghi+"' GROUP BY k_ten";
            var result = db.Database.SqlQuery<StatisticViewModel>(SQL).FirstOrDefault();
            return result;
        }
        public StatisticViewModel StatisticLTKG(int lotrinh,int kyghi)
        {
            string SQL = "SELECT lt_ten,k_ten,COUNT(*) AS soho,SUM(hd_luongtieuthu) AS sonuoc,SUM(hd_tongtien) AS tongtien FROM dbo.HoaDon INNER JOIN dbo.KhachHang ON khachhang.kh_id = hoadon.kh_id INNER JOIN dbo.LoTrinh ON LoTrinh.lt_id = KhachHang.lt_id INNER JOIN dbo.KyGhi ON kyghi.k_id = hoadon.k_id WHERE lotrinh.lt_id='" + lotrinh + "' AND kyghi.k_id='" + kyghi+"' GROUP BY lt_ten,k_ten";
            var result = db.Database.SqlQuery<StatisticViewModel>(SQL).FirstOrDefault();
            return result;
        }

        public IndexViewModel GetLastBill(int kh_id)
        {
            string SQL = "SELECT * FROM dbo.hoadon JOIN dbo.chiso ON chiso.kh_id = hoadon.kh_id AND chiso.k_id = hoadon.k_id WHERE hoadon.kh_id=" + kh_id + " AND hd_ngaylap=(SELECT MAX(hd_ngaylap) FROM dbo.hoadon) ";
            var result = db.Database.SqlQuery<IndexViewModel>(SQL).FirstOrDefault();
            return result;
        }
        public IndexViewModel GetBillBefore(int k_id, int kh_id)
        {
            string SQL = "SELECT hd_id,chiso.k_id,cs_chiso FROM dbo.hoadon  INNER JOIN dbo.chiso ON chiso.kh_id = hoadon.kh_id AND chiso.k_id = hoadon.k_id WHERE chiso.kh_id=" + kh_id + " AND hd_ngaylap=(SELECT MAX(hd_ngaylap) FROM dbo.hoadon WHERE k_id<" + k_id + ") ";
            var result = db.Database.SqlQuery<IndexViewModel>(SQL).SingleOrDefault();
            return result;
        }

        //lấy chỉ số của kỳ trước đó
        public IndexViewModel GetIndexBefore(int kh_id, int k_id)
        {
            string SQL = "SELECT TOP 1 * FROM dbo.chiso WHERE kh_id=" + kh_id + " AND k_id=(SELECT MAX(k_id) FROM dbo.chiso WHERE k_id<" + k_id + ")";
            var result = db.Database.SqlQuery<IndexViewModel>(SQL).SingleOrDefault();

            return result;
        }
        //lấy chỉ số biết k_id
        public IndexViewModel GetChiSo(int kh_id, int k_id)
        {
            string SQL = "SELECT * FROM dbo.chiso WHERE kh_id=" + kh_id + " AND k_id=" + k_id + ")";
            var result = db.Database.SqlQuery<IndexViewModel>(SQL).SingleOrDefault();

            return result;
        }
        public IndexViewModel GetLastIndex(int kh_id)
        {
            string SQL = "SELECT * FROM dbo.chiso WHERE kh_id=" + kh_id + " AND k_id=(SELECT k_id FROM dbo.kyghi WHERE k_ngaybatdau=(SELECT MAX(k_ngaybatdau) FROM dbo.kyghi) )";
            var result = db.Database.SqlQuery<IndexViewModel>(SQL).SingleOrDefault();

            return result;
        }
        public int GetLKH(int kh_id)
        {
            return db.khachhangs.SingleOrDefault(x => x.kh_id == kh_id).lkh_ma;
        }
        public double GetUnitPrice(int lkh_ma)
        {
            return db.loaikhachhangs.SingleOrDefault(x => x.lkh_ma == lkh_ma).lkh_dongia.Value;
        }
        public hoadon Find(int kh_id)
        {
            return db.hoadons.FirstOrDefault(x => (x.kh_id == kh_id)&&(x.hd_trangthai==false));
        }
        public BillViewModel Show(int hd_id)
        {
            var hoadon = from hd in db.hoadons
                         join cs in db.chisoes
                         on new { hd.k_id, hd.kh_id } equals new { cs.k_id, cs.kh_id }

                         join kg in db.kyghis
                         on hd.k_id equals kg.k_id

                         join kh in db.khachhangs
                         on hd.kh_id equals kh.kh_id

                         join lt in db.lotrinhs
                         on kh.lt_id equals lt.lt_id

                         join lkh in db.loaikhachhangs
                         on kh.lkh_ma equals lkh.lkh_ma

                         //join kt in db.kythus
                         //on kg.k_id equals kt.k_id

                         where hd.hd_id == hd_id
                         select new BillViewModel()
                         {

                             hd_id = hd.hd_id,
                             hd_ngaylap = hd.hd_ngaylap,
                             hd_trangthai = hd.hd_trangthai,
                             //thông tin khách hàng
                             lkh_ten = lkh.lkh_ten,
                             kh_id = kh.kh_id,
                             kh_hoten = kh.kh_hoten,
                             kh_diachilapdat = kh.kh_diachilapdat,
                             kh_stk = kh.kh_stk,
                             kh_mst = kh.kh_masothue,
                             lt_ten = lt.lt_ten,

                             //nội dung hóa đơn
                             //kg_id = kg.kg_id,
                             k_ngaybatdau = kg.k_ngaybatdau,
                             hd_kyghi = kg.k_ten,
                             hd_dongia = hd.hd_dongia,
                             hd_pttt = hd.hd_pttt,
                             //hd_kythu = kt.kt_ngaythu.ToString(),
                             hd_chiso = cs.cs_chiso,
                             hd_luongtieuthu = hd.hd_luongtieuthu,
                             hd_chisokytruoc1 = hd.hd_chisokytruoc1,
                             hd_tieuthukytruoc1 = hd.hd_tieuthukytruoc1,
                             hd_chisokytruoc2 = hd.hd_chisokytruoc2,
                             hd_tieuthukytruoc2 = hd.hd_tieuthukytruoc2,
                             hd_tongtien = hd.hd_tongtien
                         };

            return hoadon.FirstOrDefault();
        }
        public Boolean Insert(hoadon entity)
        {
            db.hoadons.Add(entity);
            db.SaveChanges();

            return true;
        }
        public bool Paid(int hd_id,int nv_id)
        {
            var type = db.hoadons.Find(hd_id);
            //type.nh_id = entity.nh_id;
            type.hd_trangthai = true;
            type.nv_id = nv_id;
            db.SaveChanges();
            return true;
        }
    }
}
