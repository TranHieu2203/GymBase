using GymApp.Model.Model;
using GymApp.Repository.IR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Repository.R
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(DbContext context)
              : base(context)
        {

        }
        public AppUser GetById(Guid id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
        public AppUser ReadByUserName(string userName)
        {
            return FindBy(x => x.UserName.Equals(userName)).FirstOrDefault();
        }
      
    }

}
