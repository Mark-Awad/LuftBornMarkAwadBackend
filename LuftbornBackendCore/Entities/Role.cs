using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornBackendCore.Entities
{
    public class Role:BaseEntity
    {
        public string RoleName { get; set; }

        // Navigation property for the one-to-many relationship
        public ICollection<User> Users { get; set; }
    }
}
