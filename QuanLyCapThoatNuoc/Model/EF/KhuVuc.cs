namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhuVuc")]
    public partial class KhuVuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhuVuc()
        {
            LoTrinhs = new HashSet<LoTrinh>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int kv_id { get; set; }

        public int? p_id { get; set; }

        [StringLength(100)]
        public string kv_ten { get; set; }

        public virtual Phuong Phuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoTrinh> LoTrinhs { get; set; }
    }
}
