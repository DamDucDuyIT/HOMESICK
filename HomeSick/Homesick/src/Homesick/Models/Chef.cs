using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homesick.Models
{
    public class Chef
    {
        public int ChefId { get; set; }
        public string ChefName { get; set; }
        public string ChefDisplayName { get; set; }
        public string ChefCareer { get; set; }
        public string ChefAddress { get; set; }
        public string ChefPhone { get; set; }
        public string ChefInfo { get; set; }
        public String ChefAvatar { get; set; }
        public ICollection<Food> Foods { get; set; }
    }
}
