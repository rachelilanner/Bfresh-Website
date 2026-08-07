using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ToppingsDB : BaseDB
    {
        public override BaseEntity CreateModel(BaseEntity be)
        {
            Toppings t = be as Toppings;
            t.Id = Convert.ToInt32(reader["Id"]);
            t.ToppingName = reader["ToppingName"].ToString();


            return t;
        }

        public ToppingsList SelectAllToppings()
        {
            command.CommandText = "SELECT * FROM Toppings";
            ToppingsList t = new ToppingsList(base.Select());
            return t;
        }
        public Toppings SelectByIDToppings(int id)
        {
            command.CommandText = "SELECT * FROM Toppings WHERE Toppings.ID = " + id + "";
            ToppingsList t = new ToppingsList(base.Select());
            if (t.Count > 0)
                return t[0];
            return null;
        }

        public override BaseEntity NewEntity()
        {
            return new Toppings() as BaseEntity;
        }

        public void InsertToppings(Toppings t)

        {
            string sqlText = string.Format("INSERT INTO Toppings (ToppingName) VALUES ('{0}')", t.ToppingName );
            base.SaveChanges(sqlText);
        }
        public void UpdateToppings(Toppings t)
        {
            string sqlText = "UPDATE Toppings SET ToppingName='" + t.ToppingName + "'  WHERE Id=" + t.Id;
            base.SaveChanges(sqlText);
        }
    }
}
