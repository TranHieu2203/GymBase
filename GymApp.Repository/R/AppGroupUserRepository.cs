using GymApp.Model.Model;
using GymApp.Repository.IR;
using System;
using System.Data.Entity;
using System.Linq;


namespace GymApp.Repository.R
{
    public class AppGroupUserRepository : GenericRepository<AppGroupUser>, IAppGroupUserRepository
    {
        public AppGroupUserRepository(DbContext context)
              : base(context)
        {

        }
        public AppGroupUser GetById(Guid id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
       
    }

}
