using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Items:BaseEntity
    {
        public string ItemName { get; set; }
        public Category CategoryId { get; set; }
     public string FullName { get; set; }
        public string Pic { get; set; }
        public string Ingredients { get; set; }
    }
}
