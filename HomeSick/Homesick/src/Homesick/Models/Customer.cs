using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homesick.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerDisplayName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerInfo { get; set; }
    }
}
