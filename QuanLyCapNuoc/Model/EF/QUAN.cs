namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("quan")]
    public partial class quan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public quan()
        {
            phuongs = new HashSet<phuong>();
        }

        [Key]
        public int q_id { get; set; }

        public int t_id { get; set; }

        [StringLength(100)]
        public string q_ten { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phuong> phuongs { get; set; }

        public virtual tinh tinh { get; set; }
    }
}
