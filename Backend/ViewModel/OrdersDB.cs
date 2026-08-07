using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class OrdersDB : BaseDB
    {
        public override BaseEntity CreateModel(BaseEntity be)
        {
            Orders o = be as Orders;
            o.Id = Convert.ToInt32(reader["Id"]);
            o.CustomerId = new CustomersDB().SelectByIDCustomers( Convert.ToInt32(reader["CustomerId"]));
            o.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
            o.Sum = Convert.ToInt32(reader["Sum"]);
            o.CCnum = reader["CCnum"].ToString();
            o.CCdate = Convert.ToDateTime(reader["CCdate"]);
            o.CVV = reader["CVV"].ToString();
            return o;
        }
        public OrdersList SelectAllOrders()
        {
            command.CommandText = "SELECT * FROM  Orders";

            OrdersList o = new OrdersList(base.Select());
            return o;
        }
        public Orders SelectByIDOrders(int id)
        {
            command.CommandText = "SELECT * FROM Orders WHERE Orders.ID = " + id + "";
            OrdersList o = new OrdersList(base.Select());
            if (o.Count > 0)
                return o[0];
            return null;
        }



        public override BaseEntity NewEntity()
        {
            return new Orders() as BaseEntity;
        }

        public void InsertOrders(Orders o)

        {
            string d1 = o.OrderDate.Year + "/" + o.OrderDate.Month + "/" + o.OrderDate.Day;
            string d2 = o.CCdate.Year + "/" + o.CCdate.Month + "/" + o.CCdate.Day;
            string sqlText = string.Format("INSERT INTO Orders ( CustomerId, OrderDate, Sum, CCnum, CCdate, CVV) VALUES" + " ({0},'{1}',{2},'{3}','{4}','{5}')",  o.CustomerId.Id, d1, o.Sum, o.CCnum, d2, o.CVV);
            base.SaveChanges(sqlText);
        }
        public void UpdateOrders(Orders o)
        {
            string sqlText = "UPDATE Orders SET CustomerId=" + o.CustomerId.Id  + " , OrderDate= '" + o.OrderDate + "' , Sum=" + o.Sum + " , CCnum='" + o.CCnum + "', CCdate='" + o.CCdate + "' , CVV='" + o.CVV + "'  WHERE Id=" + o.Id;
            base.SaveChanges(sqlText);
        }
    }
}
