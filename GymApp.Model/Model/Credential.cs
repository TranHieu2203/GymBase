using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApp.Model.Model
{
    [Table("Credential")]
    public class Credential : AuditableEntity<Guid>
    {
        [Display(Name = "AppGroupUser")]
        public Guid AppGroupUserId { get; set; }

        [ForeignKey("AppGroupUserId")]
        public virtual AppGroupUser AppGroupUser { get; set; }

        [Display(Name = "AppRole")]
        public Guid AppRoleId { get; set; }

        [ForeignKey("AppRoleId")]
        public virtual AppRole AppRole { get; set; }

    }
}