using GymApp.Model.Model;
using GymApp.Repository;
using GymApp.Repository.IR;
using GymApp.Service.IR;
using System;
using common = GymApp.Common;

namespace GymApp.Service.R
{
    public class AppRoleService : EntityService<AppRole>, IAppRoleService
    {
        IUnitOfWork _unitOfWork;
        IAppRoleRepository _appRoleRepository;

        public AppRoleService(IUnitOfWork unitOfWork, IAppRoleRepository AppRoleRepository)
            : base(unitOfWork, AppRoleRepository)
        {
            _unitOfWork = unitOfWork;
            _appRoleRepository = AppRoleRepository;
        }


        public AppRole GetById(Guid Id)
        {
            return _appRoleRepository.GetById(Id);
        }
    
    }

}
