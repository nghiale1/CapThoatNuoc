namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
            KyGhis = new HashSet<KyGhi>();
            LoTrinhs = new HashSet<LoTrinh>();
        }

        [Key]
        public int nv_id { get; set; }

        public int cv_id { get; set; }

        [Required]
        [StringLength(10)]
        public string nv_ma { get; set; }

        [Required]
        [StringLength(100)]
        public string nv_hoten { get; set; }

        [Required]
        [StringLength(100)]
        public string nv_tendangnhap { get; set; }

        [Required]
        [StringLength(1000)]
        public string nv_matkhau { get; set; }

        public virtual ChucVu ChucVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KyGhi> KyGhis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoTrinh> LoTrinhs { get; set; }
    }
}
