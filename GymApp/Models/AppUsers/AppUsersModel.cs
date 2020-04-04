using GymApp.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymApp.Website.Models.AppUsersModel
{
    public class AppUsersModel : AppUser
    {
        public AppUsersModel(){}
        public AppUsersModel( AppUser appUser)
            : this()
        {
            UserName = appUser.UserName;
            PassWord = appUser.PassWord;
            Name = appUser.Name;
            DateOfBirth = appUser.DateOfBirth;
            Email = appUser.Email;
            Phone = appUser.Phone;
            Address = appUser.Address;
            Active = appUser.Active;
            IsLock = appUser.IsLock;
            IsAdmin = appUser.IsAdmin;
        }
        public string RetypePassword { set; get; }
        
    }
    public class LoginModel : BaseUserModel
    {
        public LoginModel() { }
        public LoginModel( AppUser appUser) 
            : this()
        {
            Username = appUser.UserName;
            Password = appUser.PassWord;
            Id = appUser.Id;
            Name = appUser.Name;
            Email = appUser.Email;
            Phone = appUser.Phone;
            ReturnUrl = appUser.ReturnUrl;
            Address = appUser.Address;
            AppGroupUserId = appUser.AppGroupUserId;
            
        }
    }
    public class GroupUserModel : AppGroupUser
    {
       
    }
    public class BaseModel
    {
        public bool IsModelValid { get; set; }
        public bool Success { get; set; }
    }
    public class BaseUserModel : BaseModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public Boolean RememberMe { set; get; }
        public string ReturnUrl { set; get; }
        public string Address { set; get; }
        public Guid? AppGroupUserId { set; get; }

    }
}