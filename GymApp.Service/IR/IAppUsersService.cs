using GymApp.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Service.IR
{
    public interface IAppUserService : IEntityService<AppUser>
    {
        AppUser GetById(Guid Id);
        AppUser ReadByUserName(string userName);
        AppUser ReadByUserNameLogin(string userName, string password);

        List<String> GetRoleNameByUserId(Guid id);
        List<AppUserInfo> GetListUserWithoutAdmin();
    }

}
