using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CustomersDB:BaseDB
    {
        public override BaseEntity CreateModel(BaseEntity be)
        {
            Customers c = be as Customers;
            c.Id = Convert.ToInt32(reader["Id"]);
            c.FirstName = reader["FirstName"].ToString();
            c.LastName = reader["LastName"].ToString();
            c.PhoneNum = reader["PhoneNum"].ToString();
            c.Birthday = Convert.ToDateTime(reader["Birthday"]);
            c.Clubpoints = Convert.ToInt32(reader["Clubpoints"]);
            c.Manager = Convert.ToBoolean(reader["Manager"]);
            return c;
        }

        public CustomerList SelectAllCustomers()
        {
            command.CommandText = "SELECT * FROM Customers";
            CustomerList cl = new CustomerList(base.Select());
            return cl;
        }
        public Customers SelectByIDCustomers(int id)
        {
            command.CommandText = "SELECT * FROM Customers WHERE Customers.ID = " + id + "";
            CustomerList cl = new CustomerList(base.Select());
            if (cl.Count > 0)
                return cl[0];
            return null;
        }

        public override BaseEntity NewEntity()
        {
            return new Customers() as BaseEntity;
        }

        public void InsertCustomers(Customers c)

        {
           
            string sqlText = string.Format("INSERT INTO Customers (FirstName, LastName, PhoneNum, Birthday, Clubpoints, Manager) VALUES ('{0}','{1}','{2}','{3}',{4},'{5}')", c.FirstName, c.LastName, c.PhoneNum, c.Birthday.ToString("yyyy-MM-dd"), c.Clubpoints,  c.Manager);
            base.SaveChanges(sqlText);
            LastId = c.Id;
        }
        public void UpdateCustomers(Customers c)
        {
            string sqlText = "UPDATE Customers SET FirstName='" + c.FirstName + "' , LastName= '" + c.LastName + "' , PhoneNum='" + c.PhoneNum +"', Clubpoints=" + c.Clubpoints + " WHERE Id=" + c.Id;
            base.SaveChanges(sqlText);
        }
    }
}
