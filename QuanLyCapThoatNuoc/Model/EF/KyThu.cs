namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KyThu")]
    public partial class KyThu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KyThu()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public int kt_id { get; set; }

        public int kg_id { get; set; }

        public int kt_lanthu { get; set; }

        [Column(TypeName = "date")]
        public DateTime kt_ngaythu { get; set; }

        public int kt_trangthai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual KyGhi KyGhi { get; set; }
    }
}
