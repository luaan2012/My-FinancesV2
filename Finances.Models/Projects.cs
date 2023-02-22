using System;
using System.Collections.Generic;
using System.Linq;
namespace Finances.Models
{
    public class Projects : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateFinal { get; set; }
        public string ImageUpload { get; set; }
        public string ImageName { get; set; }
        public double Goal { get; set; }
        public double Money { get; set; }
        public Guid UsersId { get; set; }

    }
}
