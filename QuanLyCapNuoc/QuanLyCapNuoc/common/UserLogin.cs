using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyCapNuoc.common
{
    [Serializable]
    public class UserLogin
    {
        public long nv_id { set; get; }
        public string nv_tendangnhap { get; set; }
        public int cv_id { get; set; }
    }
}