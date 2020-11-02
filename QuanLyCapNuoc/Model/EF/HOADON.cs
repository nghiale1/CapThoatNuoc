namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hoadon")]
    public partial class hoadon
    {
        [Key]
        public int hd_id { get; set; }

        public int nv_id { get; set; }

        public bool hd_trangthai { get; set; }

        public int kh_id { get; set; }

        public int k_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? hd_ngaylap { get; set; }

        public double? hd_dongia { get; set; }

        [StringLength(100)]
        public string hd_pttt { get; set; }

        public int? hd_luongtieuthu { get; set; }

        public int? hd_chisokytruoc1 { get; set; }

        public int? hd_tieuthukytruoc1 { get; set; }

        public int? hd_chisokytruoc2 { get; set; }

        public int? hd_tieuthukytruoc2 { get; set; }

        public int? hd_tongtien { get; set; }

        public virtual chiso chiso { get; set; }

        public virtual nhanvien nhanvien { get; set; }
    }
}
