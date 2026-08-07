using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customers:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNum { get; set; }
        public DateTime Birthday { get; set; }
        public int Clubpoints { get; set; }
        public bool Manager { get; set; }

    }
}
