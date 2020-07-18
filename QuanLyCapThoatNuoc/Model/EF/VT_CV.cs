namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VT_CV
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vt_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cv_id { get; set; }

        [Column(TypeName = "text")]
        public string vtcv_ghichu { get; set; }

        public virtual ChucVu ChucVu { get; set; }

        public virtual VaiTro VaiTro { get; set; }
    }
}
