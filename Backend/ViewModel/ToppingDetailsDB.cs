using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ToppingDetailsDB : BaseDB
    {
        public override BaseEntity CreateModel(BaseEntity be)
        {
            ToppingDetails td = be as ToppingDetails;
            td.Id = Convert.ToInt32(reader["Id"]);
            td.ToppingCode = new ToppingsDB().SelectByIDToppings(Convert.ToInt32(reader["ToppingCode"]));
            td.OrderDetails = new OrderDetailsDB().SelectByIDOrderDetails(Convert.ToInt32(reader["OrderDetails"]));

            return td;
        }

        public ToppingDetailsList SelectAllToppingDetails()
        {
            command.CommandText = "SELECT * FROM ToppingDetails";
            ToppingDetailsList td = new ToppingDetailsList(base.Select());
            return td;
        }
        public ToppingDetails SelectByIDToppingDetails(int id)
        {
            command.CommandText = "SELECT * FROM ToppingDetails WHERE ToppingDetails.ID = " + id + "";
            ToppingDetailsList td = new ToppingDetailsList(base.Select());
            if (td.Count > 0)
                return td[0];
            return null;
        }

        public override BaseEntity NewEntity()
        {
            return new Category() as BaseEntity;
        }

        public void InsertToppingDetails(ToppingDetails td)

        {
            string sqlText = string.Format("INSERT INTO ToppingDetails ( ToppingCode, OrderDetails) VALUES " + " ({0},{1})",  td.ToppingCode.Id, td.OrderDetails.Id);
            base.SaveChanges(sqlText);
        }
        public void UpdateToppingDetails(ToppingDetails td)
        {
            string sqlText = "UPDATE ToppingDetails SET ToppingCode=" + td.ToppingCode + " , OrderDetails= '" + td.OrderDetails + "'  WHERE Id=" + td.Id;
            base.SaveChanges(sqlText);
        }
    }
}
