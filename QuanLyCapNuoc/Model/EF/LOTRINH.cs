namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lotrinh")]
    public partial class lotrinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public lotrinh()
        {
            khachhangs = new HashSet<khachhang>();
        }

        [Key]
        public int lt_id { get; set; }

        public int kv_id { get; set; }

        public int? nv_id { get; set; }

        [StringLength(100)]
        public string lt_ten { get; set; }

        [Column(TypeName = "ntext")]
        public string lt_ghichu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<khachhang> khachhangs { get; set; }

        public virtual khuvuc khuvuc { get; set; }

        public virtual nhanvien nhanvien { get; set; }
    }
}
