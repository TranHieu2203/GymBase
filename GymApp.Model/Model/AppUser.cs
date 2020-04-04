using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApp.Model.Model
{
    [Table("AppUser")]
   public  class AppUser : AuditableEntity<Guid>
    {
        [Required]
        public string UserName { set; get; }
        public string PassWord { set; get; }

        public string Name { set; get; }
    
        public DateTime? DateOfBirth { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public Boolean? Active { set; get; }
        public Boolean? IsLock { set; get; }
        public int? CountFail { set; get; }
        public Guid? ResetKey { set; get; }
        public DateTime? TimeExpire { set; get; }
        public string Avatar { set; get; }
        public DateTime? LastPasswordChanged { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public Boolean? IsAdmin { set; get; }
        public string ReturnUrl { set; get; }
        public Guid? AppGroupUserId { get; set; }

    }

    public class UserLogin
    {
        public string UserName { set; get; }
        public string Name { set; get; }
        public DateTime? DateOfBirth { set; get; }
        public string Phone { set; get; }
        public string ReturnUrl { set; get; }
        public string Address { set; get; }
    }
    public class AppUserInfo 
    {
        public Guid Id { set; get; }
        public string UserName { set; get; }
        public string Name { set; get; }
        public DateTime? DateOfBirth { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public Boolean? Active { set; get; }
        public Boolean? IsLock { set; get; }
        public string Avatar { set; get; }
        public Boolean? IsAdmin { set; get; }
        public string ReturnUrl { set; get; }
        public string AppGroupUserName { set; get; }
        public Guid? AppGroupUserId { set; get; }
    }
}
