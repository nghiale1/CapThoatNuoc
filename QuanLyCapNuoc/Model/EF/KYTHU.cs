namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kythu")]
    public partial class kythu
    {
        [Key]
        public int kt_id { get; set; }

        public int k_id { get; set; }

        public int? kt_lanthu { get; set; }

        public DateTime? kt_ngaythu { get; set; }

        public int? kt_trangthai { get; set; }

        public virtual kyghi kyghi { get; set; }
    }
}
