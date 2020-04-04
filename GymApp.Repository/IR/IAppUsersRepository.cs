using GymApp.Model.Model;
using System;
using System.Collections.Generic;

namespace GymApp.Repository.IR
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {
        AppUser GetById(Guid id);
        AppUser ReadByUserName(string userName);      
    }

}
    