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
    public class CredentialRepository : GenericRepository<Credential>, ICredentialRepository
    {
        public CredentialRepository(DbContext context)
              : base(context)
        {

        }
        public Credential GetById(Guid id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
        public List<Credential> GetByGroupUserId(Guid groupId)
        {
            return FindBy(x => x.AppGroupUserId == groupId).ToList();
        }

    }

}
