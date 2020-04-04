using GymApp.Model.Model;
using GymApp.Repository;
using GymApp.Repository.IR;
using GymApp.Service.IR;
using System;
using System.Collections.Generic;
using System.Linq;
using common = GymApp.Common;

namespace GymApp.Service.R
{
    public class AppUserService : EntityService<AppUser>, IAppUserService
    {
        IUnitOfWork _unitOfWork;
        IAppUserRepository _appUserRepository;
        ICredentialRepository _credentialRepository;
        IAppRoleRepository _appRoleRepository;
        IAppGroupUserService _appGroupUserService;
        public AppUserService(IUnitOfWork unitOfWork,
                            IAppUserRepository appUserRepository,
                            ICredentialRepository credentialRepository,
                            IAppRoleRepository appRoleRepository,
                            IAppGroupUserService appGroupUserService)
            : base(unitOfWork, appUserRepository)
        {
            _unitOfWork = unitOfWork;
            _appUserRepository = appUserRepository;
            _credentialRepository = credentialRepository;
            _appRoleRepository = appRoleRepository;
            _appGroupUserService = appGroupUserService;
        }


        public AppUser GetById(Guid Id)
        {
            return _appUserRepository.GetById(Id);
        }
       public  AppUser ReadByUserName(string userName)
        {
            var user = _appUserRepository.ReadByUserName(userName);
            return user;
        }
        public AppUser ReadByUserNameLogin(string userName, string password)
        {
            var user = _appUserRepository.ReadByUserName(userName);
            if (user !=null)
            {
                var passHash = common.Security.HashPassword(password);
                if (user.PassWord != passHash) return null;
            }
            return user;
        }
        public List<string> GetRoleNameByUserId(Guid id)
        {
            var account = _appUserRepository.GetById(id);
            var groupID = account.AppGroupUserId.GetValueOrDefault();
            var roleByGroupId = _credentialRepository.GetByGroupUserId(groupID);
            var lstRole = _appRoleRepository.GetAll();
            var lst = from p in lstRole
                      from p1 in roleByGroupId
                      where p.Id == p1.AppRoleId
                      select (p.RoleName);
            return lst.ToList();
        }
        public List<AppUserInfo> GetListUserWithoutAdmin()
        {
            var data =  _appUserRepository.GetAll().Where(x => !x.UserName.ToUpper().Contains("ADMIN"));
            var groupuser = _appGroupUserService.GetAll();
            var query2 = (
                            from users in data
                            from groups in groupuser
                                 .Where(g => g.Id == users.AppGroupUserId).DefaultIfEmpty(new AppGroupUser())
                            select new AppUserInfo
                            {
                                Id = users.Id,
                                Name = users.Name,
                                UserName = users.UserName,
                                DateOfBirth = users.DateOfBirth,
                                Email = users.Email,
                                Phone = users.Phone,
                                Address = users.Address,
                                Active = users.Active,
                                IsLock = users.IsLock,
                                Avatar = users.Avatar,
                                IsAdmin = users.IsAdmin,
                                AppGroupUserId = users.AppGroupUserId,
                                AppGroupUserName = groups.GroupName
                            });
            
            
            return query2.ToList();
              
        }
    }

}
