using GymApp.Model.Model;
using System;

namespace GymApp.Repository.IR
{
    public interface IAppRoleRepository : IGenericRepository<AppRole>
    {
        AppRole GetById(Guid id);
    
  
    }

}
