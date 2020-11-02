namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("khuvuc")]
    public partial class khuvuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public khuvuc()
        {
            lotrinhs = new HashSet<lotrinh>();
        }

        [Key]
        public int kv_id { get; set; }

        public int p_id { get; set; }

        [StringLength(100)]
        public string kv_ten { get; set; }

        public virtual phuong phuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lotrinh> lotrinhs { get; set; }
    }
}
