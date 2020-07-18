namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoTrinh")]
    public partial class LoTrinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoTrinh()
        {
            KhachHangs = new HashSet<KhachHang>();
        }

        [Key]
        public int lt_id { get; set; }

        public int? kv_id { get; set; }

        public int? nv_id { get; set; }

        [Required]
        [StringLength(100)]
        public string lt_ten { get; set; }

        [StringLength(100)]
        public string lt_ghichu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }

        public virtual KhuVuc KhuVuc { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
