namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KyGhi")]
    public partial class KyGhi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KyGhi()
        {
            ChiSoes = new HashSet<ChiSo>();
            HoaDons = new HashSet<HoaDon>();
            KyThus = new HashSet<KyThu>();
        }

        [Key]
        public int kg_id { get; set; }

        public int nv_id { get; set; }

        [Required]
        [StringLength(100)]
        public string kg_ten { get; set; }

        [Column(TypeName = "date")]
        public DateTime kg_ngaybatdau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiSo> ChiSoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KyThu> KyThus { get; set; }
    }
}
