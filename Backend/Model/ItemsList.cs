using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ItemsList:List<Items>
    {
        public ItemsList()
        {

        }
        public ItemsList(IEnumerable<Items> list) : base(list)
        {

        }
        public ItemsList(IEnumerable<BaseEntity> list) : base(list.Cast<Items>().ToList())
        {

        }
    }
}
