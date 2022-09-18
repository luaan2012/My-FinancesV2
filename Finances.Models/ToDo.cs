using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Models
{
    public class ToDo : Entity
    {
        public string Name { get; set; }
        public bool Complete { get; set; }
        public Users Users { get; set; }
        public Guid UsersId { get; set; }

    }
}
