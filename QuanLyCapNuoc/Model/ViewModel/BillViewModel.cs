using System;

namespace Model.ViewModel
{
    public class BillViewModel
    {
        //thông tin chung hóa đơn
        public int nv_id { get; set; }
        public int hd_id { get; set; }
        public DateTime? hd_ngaylap { get; set; }

        public bool hd_trangthai { get; set; }
        ////thông tin khách hàng
        public int kh_id { get; set; }
        public String kh_ma { get; set; }
        public String kh_hoten { get; set; }
        public String kh_diachilapdat { get; set; }
        public String kh_stk { get; set; }
        public String kh_mst { get; set; }
        public String lt_ten { get; set; }
        public String lkh_ten { get; set; }



        ////nội dung hóa đơn
        public int k_id { get; set; }
        public DateTime? k_ngaybatdau { get; set; }
        public string hd_kyghi { get; set; }
        public double? hd_dongia { get; set; }
        public string hd_pttt { get; set; }
        public string hd_kythu { get; set; }
        public int? hd_chiso { get; set; }
        public int? hd_luongtieuthu { get; set; }
        public int? hd_chisokytruoc1 { get; set; }
        public int? hd_tieuthukytruoc1 { get; set; }
        public int? hd_chisokytruoc2 { get; set; }
        public int? hd_tieuthukytruoc2 { get; set; }
        public int? hd_tongtien { get; set; }
        public int cs_chiso { get; set; }
    }
}
