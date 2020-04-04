using GymApp.Model.Model;
using System;
using System.Collections.Generic;

namespace GymApp.Repository.IR
{
    public interface ICredentialRepository : IGenericRepository<Credential>
    {
        Credential GetById(Guid id);
        List<Credential> GetByGroupUserId(Guid groupId);
    }

}
