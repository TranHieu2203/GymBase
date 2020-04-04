using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApp.Model.Model
{
    [Table("AppRole")]
   public  class AppRole : AuditableEntity<Guid>
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Role Name")]
        public string RoleName { set; get; }
        public virtual IEnumerable<Credential> Credentials { get; set; }
    }
       

}
