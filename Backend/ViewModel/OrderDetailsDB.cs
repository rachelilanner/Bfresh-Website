using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class OrderDetailsDB : BaseDB
    {
        public override BaseEntity CreateModel(BaseEntity be)
        {
            OrderDetails od = be as OrderDetails;
            od.Id = Convert.ToInt32(reader["Id"]);
            od.Quentity = Convert.ToInt32(reader["Quentity"]);
            od.OrderId = new OrdersDB().SelectByIDOrders(Convert.ToInt32(reader["OrderId"]));
            od.ItemId = new ItemsDB().SelectByIDItems(Convert.ToInt32(reader["ItemId"]));
            try
            {
            od.Note = reader["Note"].ToString();
            }
            catch (Exception)
            {

               
            }
           
            od.Ssize = reader["Ssize"].ToString();


            return od;
        }

        public OrderDetailsList SelectAllOrderDetails()
        {
            command.CommandText = "SELECT * FROM OrderDetails";
            OrderDetailsList od = new OrderDetailsList(base.Select());
            return od;
        }
        public OrderDetails SelectByIDOrderDetails(int id)
        {
            command.CommandText = "SELECT * FROM OrderDetails WHERE OrderDetails.ID = " + id + "";
            OrderDetailsList od = new OrderDetailsList(base.Select());
            if (od.Count > 0)
                return od[0];
            return null;
        }

        public override BaseEntity NewEntity()
        {
            return new OrderDetails() as BaseEntity;
        }

        public void InsertOrderDetails(OrderDetails od)

        {
            string sqlText = string.Format("INSERT INTO OrderDetails ( OrderId, ItemId, Note,Quentity,Ssize) VALUES ({0},{1},'{2}',{3},'{4}')", od.OrderId.Id, od.ItemId.Id, od.Note,od.Quentity,od.Ssize );
            base.SaveChanges(sqlText);
        }
        public void UpdateOrderDetails(OrderDetails od)
        {
            string sqlText = "UPDATE OrderDetails SET  OrderId=" + od.OrderId.Id + " , ItemId= " + od.ItemId.Id  + " , Note='" + od.Note + "'  WHERE Id=" + od.Id;
            base.SaveChanges(sqlText);
        }
    }
}
