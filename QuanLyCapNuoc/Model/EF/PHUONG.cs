namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("phuong")]
    public partial class phuong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phuong()
        {
            khuvucs = new HashSet<khuvuc>();
        }

        [Key]
        public int p_id { get; set; }

        public int q_id { get; set; }

        [StringLength(100)]
        public string p_ten { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<khuvuc> khuvucs { get; set; }

        public virtual quan quan { get; set; }
    }
}
