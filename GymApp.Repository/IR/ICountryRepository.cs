using GymApp.Model.Model;
using System;

namespace GymApp.Repository.IR
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Country GetById(Guid id);
    }

}
