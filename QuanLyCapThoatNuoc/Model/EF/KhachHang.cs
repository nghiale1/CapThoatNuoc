namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            ChiSoes = new HashSet<ChiSo>();
            DongHoes = new HashSet<DongHo>();
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public int kh_id { get; set; }

        public int? nh_id { get; set; }

        [Required]
        [StringLength(10)]
        public string lkh_ma { get; set; }

        public int lt_id { get; set; }

        [StringLength(100)]
        public string kh_hoten { get; set; }

        [StringLength(20)]
        public string kh_masothue { get; set; }

        [StringLength(1024)]
        public string kh_diachilapdat { get; set; }

        [StringLength(1024)]
        public string kh_diachithanhtoan { get; set; }

        public int kh_trangthai { get; set; }

        [StringLength(20)]
        public string kh_stk { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiSo> ChiSoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DongHo> DongHoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual LoaiKhachHang LoaiKhachHang { get; set; }

        public virtual LoTrinh LoTrinh { get; set; }

        public virtual NganHang NganHang { get; set; }
    }
}
