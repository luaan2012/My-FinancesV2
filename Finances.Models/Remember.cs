using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Models
{
    public class Remember : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateRemember { get; set; }
        public Users Users { get; set; }
        public Guid UsersId { get; set; }

    }
}
