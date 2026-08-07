using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CustomerList:List<Customers>
    {
        public CustomerList()
        {

        }
        public CustomerList(IEnumerable<Customers> list) : base(list)
        {

        }
        public CustomerList(IEnumerable<BaseEntity> list) : base(list.Cast<Customers>().ToList())
        {

        }
    }
}
