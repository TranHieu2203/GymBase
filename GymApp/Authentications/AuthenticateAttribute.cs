
using GymApp.Common;
using GymApp.Website.Helper;
using System;
using System.Web;
using System.Web.Mvc;

namespace BA.STaxi.Web.Authentications
{
    public class AuthenticateAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        private readonly string _urlCode;

        public AuthenticateAttribute()
        {
        }

        public AuthenticateAttribute(String urlCode)
        {
            _urlCode = urlCode;
        }

        public bool EnableSkipChecking { get; set; }
        public bool ApplyForRetrieveReport { get; set; }

        public void OnAuthorization(AuthorizationContext filterContext)
        {

            var allowPer = true;
            if (AuthenticationHelper.IsLoggedIn)
            {
                //return;
                // check per
                if (_urlCode != null)
                {
                   

                    allowPer = AuthenticationHelper.HasPermission(_urlCode);
                    if (allowPer)
                    {
                        return; //User đã đăng nhập
                    }
                }
                else
                {
                    return; //User đã đăng nhập
                }
            }

            //Check nếu đang sử dụng request từ ajax
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                filterContext.Result = new HttpStatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
            }
            else
            {
              



                var incommingUrl = HttpUtility.UrlEncode(HttpContext.Current.Request.Url.AbsolutePath.ToString());

               
                if (string.Equals("POST", HttpContext.Current.Request.RequestType, StringComparison.OrdinalIgnoreCase))
                    incommingUrl = string.Empty;

                var urlRedirect = allowPer ? "/Home/Login" : "/Error/AccessDenied";
              
                var redirectUrl = string.Format("{0}?ReturnUrl={1}", urlRedirect, incommingUrl);


                filterContext.Result =
                    new RedirectResult(redirectUrl, true);
            }
        }
    }
}