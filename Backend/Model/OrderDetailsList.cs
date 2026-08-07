using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderDetailsList:List<OrderDetails>
    {
        public OrderDetailsList()
        {

        }
        public OrderDetailsList(IEnumerable<OrderDetails> list) : base(list)
        {

        }
        public OrderDetailsList(IEnumerable<BaseEntity> list) : base(list.Cast<OrderDetails>().ToList())
        {

        }
    }
}
