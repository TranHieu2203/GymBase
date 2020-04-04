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
    public class AppRoleRepository : GenericRepository<AppRole>, IAppRoleRepository
    {
        public AppRoleRepository(DbContext context)
              : base(context)
        {

        }
        public AppRole GetById(Guid id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
      
    }

}
