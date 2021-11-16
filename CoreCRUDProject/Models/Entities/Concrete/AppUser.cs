using CoreCRUDProject.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCRUDProject.Models.Entities.Concrete
{
    public class AppUser:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
