
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GymApp.Model.Model
{
    [Table("Country")]

    public class Country : Entity<Guid>
    {
      
        [Required]
        [MaxLength(100)]
        [Display(Name = "Country Name")]
        public string Name { get; set; }
        public virtual IEnumerable<Person> Persons { get; set; }
    }

}
