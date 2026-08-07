using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ToppingsList:List<Toppings>
    {
        public ToppingsList()
        {

        }
        public ToppingsList(IEnumerable<Toppings> list) : base(list)
        {

        }
        public ToppingsList(IEnumerable<BaseEntity> list) : base(list.Cast<Toppings>().ToList())
        {

        }
    }
}
