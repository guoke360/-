using Resposity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShelfWeb.Filter
{
    public class CustAuthorizeAttribute : AuthorizeAttribute
    {
        private UserRole[] roles;

        public CustAuthorizeAttribute(params UserRole[] role)
        {
            roles = role;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            UserRole role = UserInfo.UserRole;
            if (role != UserRole.None)
            {
                return roles.Contains(role);
            }
            return base.AuthorizeCore(httpContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            UrlHelper url = new UrlHelper(filterContext.RequestContext);
            filterContext.Result = new RedirectResult("~/Login/Login");
        }
    }
}