using GymApp.Model.Model;
using System;

namespace GymApp.Repository.IR
{
    public interface IAppGroupUserRepository : IGenericRepository<AppGroupUser>
    {
        AppGroupUser GetById(Guid id);
  
    }

}
