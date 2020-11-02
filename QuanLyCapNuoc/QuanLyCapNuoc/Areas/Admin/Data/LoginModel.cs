using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyCapNuoc.Areas.Admin.Data
{
    public class LoginModel
    {
        [Required(ErrorMessage = " Mời nhập tên đăng nhập")]
        public String nv_tendangnhap { get; set; }

        [Required(ErrorMessage = " Mời nhập mật khẩu")]
        public String nv_matkhau { get; set; }

        public bool RememberMe { get; set; }
    }
}