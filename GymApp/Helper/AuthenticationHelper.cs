using GymApp.Model.Model;
using GymApp.Website.Models.AppUsersModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace GymApp.Website.Helper
{
    public class AuthenticationHelper
    {
      
        public static bool IsLoggedIn
        {
            get
            {
                try
                {
                    if (HttpContext.Current.Session[Common.CommonConst.UserLoggedIn] != null)
                    {
                        return true;
                    }

                    var existingCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                    if (existingCookie == null || string.IsNullOrWhiteSpace(existingCookie.Value))
                    {
                        return false;
                    }

                    var loggedInUser = FormsAuthentication.Decrypt(existingCookie.Value);
                    if (loggedInUser == null || string.IsNullOrWhiteSpace(loggedInUser.Name))
                    {
                        return false;
                    }
                 
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                return false;
            }
        }
        
        public static string GetUserName()
        {
            if (!AuthenticationHelper.IsLoggedIn)
                return string.Empty;
            var userLogin = HttpContext.Current.Session[Common.CommonConst.UserLoggedIn] as LoginModel;
            return userLogin.Name;

        }
        public static string GetUserAddress()
        {
            if (!AuthenticationHelper.IsLoggedIn)
                return string.Empty;
            var userLogin = HttpContext.Current.Session[Common.CommonConst.UserLoggedIn] as LoginModel;
            return userLogin.Address;
        }
        public void Logout()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.Abandon();
            
        }
        //public static void Authenticated(LoginModel logOnUser, /*string permissionValue*/)
        public static void Authenticated(LoginModel logOnUser, string permissionValue)
        {
            HttpContext.Current.Session[Common.CommonConst.UserLoggedIn] = logOnUser;
            // sesion UserName

            HttpContext.Current.Session[Common.CommonConst.UserName] = logOnUser.Username;
            // Lưu lại seesion list quyền 
            HttpContext.Current.Session[Common.CommonConst.UserRole] = permissionValue;
            SetAuthenticationCookie(logOnUser);
        }
        public static bool HasPermission(string per)
        {
            //return true;
            if (!IsLoggedIn)
                return false;
            return PersByAccount.Contains(per.ToString());
        }
        public static string PersByAccount
        {
            get
            {
                if (!IsLoggedIn)
                    return string.Empty;
                return (HttpContext.Current.Session[Common.CommonConst.UserRole] == null)
                    ? string.Empty
                    : (HttpContext.Current.Session[Common.CommonConst.UserRole] as string);
            }
        }

        private static void SetAuthenticationCookie(LoginModel logOnUser)
        {
            try
            {
                HttpContext.Current.Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
                //if (!logOnUser.RememberMe) return;
                var expiryDate = DateTime.Now.AddMonths(12);
                var ticket = new FormsAuthenticationTicket(2, logOnUser.Username, DateTime.Now, expiryDate, true,
                    string.Empty);
                var encryptedTicket = FormsAuthentication.Encrypt(ticket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                {
                    Expires = ticket.Expiration
                };

                //add the cookie to the response.
                HttpContext.Current.Response.Cookies.Add(authCookie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}