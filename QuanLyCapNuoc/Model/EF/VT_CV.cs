namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vt_cv
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cv_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vt_id { get; set; }

        [Column(TypeName = "ntext")]
        public string vtcv_ghichu { get; set; }

        public virtual chucvu chucvu { get; set; }

        public virtual vaitro vaitro { get; set; }
    }
}
