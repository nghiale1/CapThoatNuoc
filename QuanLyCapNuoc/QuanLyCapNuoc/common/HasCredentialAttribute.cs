using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.Web.Routing;
using QuanLyCapNuoc.common;

namespace OnlineShop
{
    public class HasCredentialAttribute : AuthorizeAttribute
    {
        public int vt_id { set; get; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (UserLogin)HttpContext.Current.Session[QuanLyCapNuoc.common.CommonConstants.NV_SESSION];
            if (session == null)
            {
                return false;
            }

            List<int> privilegeLevels = this.GetCredentialByLoggedInUser(session.nv_tendangnhap); // Call another method to get rights of the user from DB

            if (privilegeLevels.Contains(this.vt_id) || session.cv_id == Common.CommonConstants.ADMIN_GROUP)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "/Areas/Admin/Views/Shared/View.cshtml"
            };
        }
        private List<int> GetCredentialByLoggedInUser(string userName)
        {
            var vt_cv = (List<int>)HttpContext.Current.Session[QuanLyCapNuoc.common.CommonConstants.SESSION_CREDENTIALS];
            return vt_cv;
        }
    }
}