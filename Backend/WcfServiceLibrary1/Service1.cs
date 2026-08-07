using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ViewModel;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public void InsertCategory(Category category)
        {
            new  CategoryDB ().InsertCategory(category);    
        }

        public void InsertCustomers(Customers customers)
        {
            new CustomersDB().InsertCustomers(customers);
        }

        public void InsertItems(Items items)
        {
            new ItemsDB().InsertItems(items);
        }

        public void InsertOrderDetails(OrderDetails orderdetails)
        {
            new OrderDetailsDB().InsertOrderDetails(orderdetails);
        }

        public void InsertOrders(Orders orders)
        {
            new OrdersDB().InsertOrders(orders);
        }

        public void InsertToppingDetails(ToppingDetails toppingdetails)
        {
            new ToppingDetailsDB().InsertToppingDetails(toppingdetails);
        }

        public void InsertToppings(Toppings toppings)
        {
            new ToppingsDB().InsertToppings(toppings);
        }

        public CategoryList SelectAllCategory()
        {
            return new CategoryDB().SelectAllCategory();
        }

        public  CustomerList SelectAllCustomers()
        {
            return new CustomersDB().SelectAllCustomers();
        }

        public ItemsList SelectAllItems()
        {
            return new ItemsDB().SelectAllItems();
        }

        public OrderDetailsList SelectAllOrderDetails()
        {
            return new OrderDetailsDB().SelectAllOrderDetails();
        }

        public OrdersList SelectAllOrders()
        {
            return new OrdersDB().SelectAllOrders();
        }

        public ToppingDetailsList SelectAllToppingDetails()
        {
            return new ToppingDetailsDB().SelectAllToppingDetails();
        }

        public ToppingsList SelectAllToppings()
        {
            return new ToppingsDB().SelectAllToppings();
        }

       

        public void UpdateCategory(Category category)
        {
            new CategoryDB().UpdateCategory(category);
        }

        public void UpdateCustomers(Customers customers)
        {
            new CustomersDB().UpdateCustomers(customers);
        }

        public void UpdateItems(Items items)
        {
            new ItemsDB().UpdateItems(items);
        }

        public void UpdateOrderDetails(OrderDetails orderdetails)
        {
            new OrderDetailsDB().UpdateOrderDetails(orderdetails);
        }

        public void UpdateOrders(Orders orders)
        {
            new OrdersDB().UpdateOrders(orders);
        }

        public void UpdateToppingDetails(ToppingDetails toppingdetails)
        {
            new ToppingDetailsDB().UpdateToppingDetails(toppingdetails);
        }

        public void UpdateToppings(Toppings toppings)
        {
            new ToppingsDB().UpdateToppings(toppings);
        }
    }
}
