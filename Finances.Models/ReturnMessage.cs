using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Models
{
    public class ReturnMessage
    {
        public string Message { get; set; }
        public string RedirectURL { get; set; }
        public bool Success { get; set; }
    }
}
