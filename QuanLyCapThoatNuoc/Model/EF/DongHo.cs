namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DongHo")]
    public partial class DongHo
    {
        [Key]
        public int dh_id { get; set; }

        public int kh_id { get; set; }

        [Required]
        [StringLength(100)]
        public string dh_thuonghieu { get; set; }

        [Required]
        [StringLength(20)]
        public string dh_maso { get; set; }

        [Column(TypeName = "date")]
        public DateTime dh_ngaylap { get; set; }

        [Column(TypeName = "date")]
        public DateTime dh_ngaykiemdinh { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
