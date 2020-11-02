namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("khachhang")]
    public partial class khachhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public khachhang()
        {
            chisoes = new HashSet<chiso>();
            donghoes = new HashSet<dongho>();
        }

        [Key]
        public int kh_id { get; set; }

        public int? nh_id { get; set; }

        public int lkh_ma { get; set; }

        public int lt_id { get; set; }

        [StringLength(100)]
        public string kh_hoten { get; set; }

        [StringLength(100)]
        public string kh_ma { get; set; }

        [StringLength(20)]
        public string kh_masothue { get; set; }

        [StringLength(1024)]
        public string kh_diachilapdat { get; set; }

        [StringLength(1024)]
        public string kh_diachithanhtoan { get; set; }

        public bool kh_trangthai { get; set; }

        [StringLength(50)]
        public string kh_stk { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chiso> chisoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dongho> donghoes { get; set; }

        public virtual loaikhachhang loaikhachhang { get; set; }

        public virtual lotrinh lotrinh { get; set; }

        public virtual nganhang nganhang { get; set; }
    }
}
