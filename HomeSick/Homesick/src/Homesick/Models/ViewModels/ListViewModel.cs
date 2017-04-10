using Homesick.Models;
using Homesick.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSick.Models.ViewModels
{
    public class ListViewModel
    {
        public IEnumerable<Food> Foods { get; set; }
        public IEnumerable<Chef> Chefs { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
