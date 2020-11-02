namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nhanvien")]
    public partial class nhanvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nhanvien()
        {
            hoadons = new HashSet<hoadon>();
            kyghis = new HashSet<kyghi>();
            lotrinhs = new HashSet<lotrinh>();
        }

        [Key]
        public int nv_id { get; set; }

        public int cv_id { get; set; }

        public bool nv_trangthai { get; set; }

        [StringLength(10)]
        public string nv_maso { get; set; }

        [StringLength(100)]
        public string nv_hoten { get; set; }

        [StringLength(100)]
        public string nv_tendangnhap { get; set; }

        [StringLength(100)]
        public string nv_matkhau { get; set; }

        public virtual chucvu chucvu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hoadon> hoadons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kyghi> kyghis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lotrinh> lotrinhs { get; set; }
    }
}
