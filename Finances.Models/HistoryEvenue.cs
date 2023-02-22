using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Finances.Models
{
    public class HistoryEvenue : Entity
    {
        public string NameTransfer { get; set; }
        public DateTime HourTransfer { get; set; }
        public double Money { get; set; }
        [JsonIgnore]
        public Users Users { get; set; }
        public Guid UsersId { get; set; }
    }
}
