using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderDetails:BaseEntity
    {
        public Orders OrderId { get; set; }
        public Items ItemId { get; set; }
        public string Note { get; set; }
        public int Quentity { get; set; }
        public string Ssize { get; set; }


    }
}
