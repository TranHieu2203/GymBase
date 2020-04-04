using GymApp.Model.Model;
using GymApp.Service.IR;
using GymApp.Website.Helper;
using GymApp.Website.Models;
using GymApp.Website.Models.AppUsersModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using authe = GymApp.Website.Helper.AuthenticationHelper;
namespace GymApp.Controllers
{
   

    public class HomeController : Controller
    {
        IAppUserService _appUserService;
        IAppGroupUserService _appGroupUserService;
        ICredentialService _credentialService;
        public HomeController(IAppUserService appUserService, ICredentialService credentialService, IAppGroupUserService appGroupUserService)
        {
            _appUserService = appUserService;
            _appGroupUserService = appGroupUserService;
            _credentialService = credentialService;
        }
        [Authorize]
        public ActionResult Index()
        {

            if (!AuthenticationHelper.IsLoggedIn)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
           
            if (AuthenticationHelper.IsLoggedIn)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Title = ResourceHelper.GetText("TitleLogin");
            return View("Login");
        }
        [HttpPost]
        public JsonResult UserLogin (LoginModel loginModel)
        {
            if (string.IsNullOrWhiteSpace(loginModel.Username))
            {
                //ModelState.AddModelError("UserName", "Tên đăng nhập không được để trống");
                loginModel.IsModelValid = false;
                return  Json(new ResponseObj(false, null, "Tên đăng nhập không được để trống"), JsonRequestBehavior.AllowGet);
            }
            if (string.IsNullOrWhiteSpace(loginModel.Password))
            {
                //ModelState.AddModelError("Password", "Password không được để trống");
                loginModel.IsModelValid = false;
                return Json(new ResponseObj(false, null, "Password không được để trống"), JsonRequestBehavior.AllowGet);
            }
            var account = _appUserService.ReadByUserNameLogin(loginModel.Username, loginModel.Password);
            string lst = string.Empty;
            if (account != null)
            {
              
     
                var userLog = new LoginModel();
                userLog.Username = account.UserName;
                userLog.Name = account.Name;
                userLog.Phone = account.Phone;
                userLog.ReturnUrl = account.ReturnUrl;
                userLog.Address = account.Address;
                userLog.Id = account.Id;
                var userRole = _appUserService.GetRoleNameByUserId(userLog.Id);
                lst += string.Join(",", userRole);
                authe.Authenticated(userLog, lst);
                //FormsAuthentication.SetAuthCookie(loginModel.Username, loginModel.RememberMe);
                return Json(new ResponseObj(true, null, "Đăng nhập thành công"));
            }
            return Json(new ResponseObj(false, null, "Tên đăng nhập hoặc mật khẩu không khớp"));
        }
        [HttpGet]
     
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public JsonResult UserLogout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return Json(new ResponseObj(true, null));
        }
    }
}