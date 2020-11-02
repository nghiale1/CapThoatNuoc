namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kyghi")]
    public partial class kyghi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kyghi()
        {
            chisoes = new HashSet<chiso>();
            kythus = new HashSet<kythu>();
        }

        [Key]
        public int k_id { get; set; }

        public int nv_id { get; set; }

        [StringLength(100)]
        public string k_ten { get; set; }

        public DateTime? k_ngaybatdau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chiso> chisoes { get; set; }

        public virtual nhanvien nhanvien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kythu> kythus { get; set; }
    }
}
