using WpfApp1.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using WpfApp1;

namespace BfreshProject
{
    public static class Vars
    {
        public static List<int> numTop = new List<int>();
        public static List<Toppings> lisMyToppings = new List<Toppings>();//
        
        public static Service1Client service1 = new Service1Client();
        public static Customers cu;
        public static Orders orders;
        public static List<OrderDetails> sal=new List<OrderDetails>();
        public static int sum=0;
             public static string GetCurrectPath()
        {
            //הפעולה  מחזירה את המיקום הנוכחי של קובץ ההרצה 
            return System.IO.Directory.GetCurrentDirectory();
        }
    }
}
