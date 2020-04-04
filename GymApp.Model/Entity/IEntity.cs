using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Model
{
    public interface IEntity<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        T Id { get; set; }
    }

}
