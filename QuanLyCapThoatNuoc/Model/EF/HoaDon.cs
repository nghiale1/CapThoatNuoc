namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        public int hd_id { get; set; }

        public int nv_id { get; set; }

        public int kt_id { get; set; }

        public int kh_id { get; set; }

        public int kg_id { get; set; }

        [Required]
        [StringLength(20)]
        public string hd_kyghi { get; set; }

        public DateTime hd_ngaylap { get; set; }

        public int hd_dongia { get; set; }

        [Required]
        [StringLength(100)]
        public string hd_pttt { get; set; }

        [Required]
        [StringLength(100)]
        public string hd_kythu { get; set; }

        public int hd_chiso { get; set; }

        public int hd_luongtieuthu { get; set; }

        public int hd_chosokytruoc1 { get; set; }

        public int hd_tieuthukytruoc1 { get; set; }

        public int hd_chosokytruoc2 { get; set; }

        public int hd_tieuthukytruoc2 { get; set; }

        public virtual KyGhi KyGhi { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual KyThu KyThu { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
