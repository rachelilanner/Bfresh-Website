using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Orders:BaseEntity
    {
        public Customers CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Sum { get; set; }
        public string CCnum { get; set; }
        public DateTime CCdate { get; set; }
        public string CVV { get; set; }
    }
}
