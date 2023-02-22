using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Finances.Models
{
    public class Revenue : Entity
    {
        public double LastEarns { get; set; }
        public double CurrentEarns { get; set; }
        public double DayEarn { get; set; }
        public double CurrenteRevenue { get; set; }
        [JsonIgnore]
        public Users Users { get; set; }
        public Guid UsersId { get; set; }
    }
}
