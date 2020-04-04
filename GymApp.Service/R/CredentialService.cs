using GymApp.Model.Model;
using GymApp.Repository;
using GymApp.Repository.IR;
using GymApp.Service.IR;
using System;
using System.Collections.Generic;
using common = GymApp.Common;

namespace GymApp.Service.R
{
    public class CredentialService : EntityService<Credential>, ICredentialService
    {
        IUnitOfWork _unitOfWork;
        ICredentialRepository _credentialRepository;
        public CredentialService(IUnitOfWork unitOfWork, ICredentialRepository credentialRepository)
            : base(unitOfWork, credentialRepository)
        {
            _unitOfWork = unitOfWork;
            _credentialRepository = credentialRepository;
        }


        public Credential GetById(Guid Id)
        {
            return _credentialRepository.GetById(Id);
        }
        public List<Credential> GetByGroupUserId(Guid groupId)
        {
            return _credentialRepository.GetByGroupUserId(groupId);
        }
    }

}
