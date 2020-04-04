using GymApp.Model.Model;
using System;

namespace GymApp.Repository.IR
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Person GetById(Guid id);
    }

}
