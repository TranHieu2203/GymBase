using GymApp.Service.IR;
using common =  GymApp.Common;
using System.Web.Mvc;
using help =  GymApp.Website.Helper;
using System.Linq;
using System;
using System.Linq.Dynamic;
using GymApp.Website.Models;
using GymApp.Website.Models.AppUsersModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GymApp.Website.Controllers.AppUser
{
    public class AppUserController : Controller
    {

        private readonly IAppUserService _AppUserService;
        private readonly IAppGroupUserService _AppGroupUserService;
        public AppUserController(IAppUserService AppUserService,
                                IAppGroupUserService AppGroupUserService)
        {
            _AppUserService = AppUserService;
            _AppGroupUserService = AppGroupUserService;
        }

        // phân quyền
        //[Authenticate(Common.CommonConstRole.AppUser_Index)]
        public ActionResult Index()
        {
            ViewBag.Module = "Tài khoản";
            ViewBag.Action = "Danh sách";
            return View(_AppUserService.GetAll());
        }
        // phân quyền
        //[Authenticate(Common.CommonConstRole.AppUser_Index)]
        public JsonResult  GetAllAppUser()
        {
            var objSearch = help.HtmlHelper.GetSearchObject();
            var iName = HttpContext.Request.Form.GetValues("name");
            var objData = _AppUserService.GetListUserWithoutAdmin();
            var resuilt = from p in objData select p;

            if (!(string.IsNullOrEmpty(objSearch.sortColumn) && string.IsNullOrEmpty(objSearch.sortColumnDir)))
            {
                resuilt = resuilt.OrderBy(objSearch.sortColumn + " " + objSearch.sortColumnDir);
            }
            //Search    
            if (!string.IsNullOrEmpty(objSearch.searchValue))
            {
                resuilt = resuilt.Where(m => m.Name.ToUpper().Contains(objSearch.searchValue.ToUpper())
                                        || m.UserName.ToUpper().Contains(objSearch.searchValue.ToUpper())
                                       );
            }
            objSearch.recordsTotal = resuilt.Count();
            var data = resuilt.Skip(objSearch.skip).Take(objSearch.pageSize).ToList();

            return Json(new { draw = objSearch.draw, recordsFiltered = objSearch.recordsTotal, recordsTotal = objSearch.recordsTotal, data = data });
        }
        [HttpGet]
        public JsonResult GetGroupUser()
        {
            try
            {
                var objGroupUser = _AppGroupUserService.GetAll();
                var obj = from p in objGroupUser
                          select new GroupUserModel
                          {
                              Id = p.Id,
                              GroupName = p.GroupName
                          };
                return Json(new ResponseObj(true, obj), JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                return Json(new ResponseObj(false, null, "Can't load data"));
            }

        }
        [HttpPost]
        public JsonResult ModifyUser(Model.Model.AppUser _appUser)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var account = new Model.Model.AppUser();
                    account.Id = _appUser.Id;
                    account.UserName = _appUser.UserName;
                    account.Name = _appUser.Name;
                    account.DateOfBirth = _appUser.DateOfBirth;
                    account.Email = _appUser.Email;
                    account.Phone = _appUser.Phone;
                    account.Address = _appUser.Address;
                    account.AppGroupUserId = _appUser.AppGroupUserId;
                    _AppUserService.Update(account);
                    return Json(new ResponseObj(true, null, "Cập nhật khoản thành công"), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(new ResponseObj(false, null, "Lỗi cập nhật tài khoản"), JsonRequestBehavior.AllowGet);
            }
            return Json(new ResponseObj(false, null, "Lỗi cập nhật tài khoản"), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult CreateUser(Model.Model.AppUser _appUser)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    var account = new Model.Model.AppUser();
                    account.UserName = _appUser.UserName;
                    if (_appUser.PassWord != null)
                    {
                        account.PassWord = common.Security.HashPassword(_appUser.PassWord);
                    }
                    else
                    {
                        account.PassWord = common.Security.HashPassword(common.CommonConst.DefaultPasword);
                    }
                    account.Name = _appUser.Name;
                    account.DateOfBirth = _appUser.DateOfBirth;
                    account.Email = _appUser.Email;
                    account.Phone = _appUser.Phone;
                    account.Address = _appUser.Address;
                    account.AppGroupUserId = _appUser.AppGroupUserId;
                    _AppUserService.Create(account);
                    return Json(new ResponseObj(true, null, "Tạo tài khoản thành công"), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(new ResponseObj(false, null, "Lỗi"), JsonRequestBehavior.AllowGet);
            }
            return Json(new ResponseObj(false, null, "Lỗi"), JsonRequestBehavior.AllowGet);
        }

        public String GetUserById(Guid id)
        {
            try
            {
                var obj = _AppUserService.GetById(id);
                // thêm new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" } để format date nếu có field dạng date
                return JsonConvert.SerializeObject(new ResponseObj(true, obj),
                    new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
            }
            catch (Exception)
            {
                return JsonConvert.SerializeObject(new ResponseObj(false, null, "Không lấy được thông tin tài khoản"));
                throw;
            }
        }

        public JsonResult DeleteUser(Guid id)
        {
            try
            {
                Model.Model.AppUser AppUser = _AppUserService.GetById(id);
                _AppUserService.Delete(AppUser);
                return Json(new ResponseObj(true, null, "Đã xóa tài khoản"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new ResponseObj(false, null, "Lỗi"), JsonRequestBehavior.AllowGet);
                throw;
            }
        }
    }
}