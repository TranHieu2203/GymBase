﻿using GymApp.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Service.IR
{
    public interface IPersonService : IEntityService<Person>
    {
        Person GetById(Guid Id);
    }

}
