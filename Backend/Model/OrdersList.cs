using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrdersList:List<Orders>
    {
        public OrdersList()
        {

        }
        public OrdersList(IEnumerable<Orders> list) : base(list)
        {

        }
        public OrdersList(IEnumerable<BaseEntity> list) : base(list.Cast<Orders>().ToList())
        {

        }
    }
}
