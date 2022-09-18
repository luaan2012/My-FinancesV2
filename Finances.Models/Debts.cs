using Finances.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Models
{
    public class Debts : Entity
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public string NameDebts { get; set; }
        public DateTime DateDebts { get; set; }
        public DateTime DatePayment { get; set; }
        public TypeStatusPay Status { get; set; }
        public Users Users { get; set; }
        public Guid UsersId { get; set; }

    }
}
