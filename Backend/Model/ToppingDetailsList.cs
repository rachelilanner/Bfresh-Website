using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ToppingDetailsList:List<ToppingDetails>
    {
        public ToppingDetailsList()
        {

        }
        public ToppingDetailsList(IEnumerable<ToppingDetails> list) : base(list)
        {

        }
        public ToppingDetailsList(IEnumerable<BaseEntity> list) : base(list.Cast<ToppingDetails>().ToList())
        {

        }
    }
}
