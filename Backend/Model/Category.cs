using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public bool Topping { get; set; }
        public int PriceSmall { get; set; }
        public int PriceMedium { get; set; }
        public int PriceLarge { get; set; }
    }
}
