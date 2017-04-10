using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homesick.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodUnit { get; set; }
        public string FoodInfo { get; set; }
        public decimal FoodPrice { get; set; }
        public String FoodAvatar { get; set; }
        public Chef Chef { get; set; }
    }
}
