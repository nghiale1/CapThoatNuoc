namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dongho")]
    public partial class dongho
    {
        [Key]
        public int dh_id { get; set; }

        public int kh_id { get; set; }

        [StringLength(100)]
        public string dh_thuonghieu { get; set; }

        [StringLength(20)]
        public string dh_maso { get; set; }

        public DateTime? dh_ngaylap { get; set; }

        public DateTime? dh_ngaykiemdinh { get; set; }

        public virtual khachhang khachhang { get; set; }
    }
}
