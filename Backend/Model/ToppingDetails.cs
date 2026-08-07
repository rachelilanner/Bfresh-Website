using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ToppingDetails:BaseEntity
    {
        public Toppings ToppingCode { get; set; }
        public OrderDetails OrderDetails { get; set; }
    }
}
