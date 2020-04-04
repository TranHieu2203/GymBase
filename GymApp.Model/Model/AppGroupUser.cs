using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApp.Model.Model
{
    [Table("AppGroupUser")]
   public  class AppGroupUser : AuditableEntity<Guid>
    {
       
        public string GroupName { set; get; }
        public virtual IEnumerable<Credential> Credentials { get; set; }
      
    }
      
}
