using GymApp.Model.Model;
using GymApp.Repository;
using GymApp.Repository.IR;
using GymApp.Service.IR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Service.R
{
    public class AppGroupUserService : EntityService<AppGroupUser>, IAppGroupUserService
    {
        IUnitOfWork _unitOfWork;
        IAppGroupUserRepository _AppGroupUserRepository;

        public AppGroupUserService(IUnitOfWork unitOfWork, IAppGroupUserRepository AppGroupUserRepository)
            : base(unitOfWork, AppGroupUserRepository)
        {
            _unitOfWork = unitOfWork;
            _AppGroupUserRepository = AppGroupUserRepository;
        }


        public AppGroupUser GetById(Guid Id)
        {
            return _AppGroupUserRepository.GetById(Id);
        }
    }

}
