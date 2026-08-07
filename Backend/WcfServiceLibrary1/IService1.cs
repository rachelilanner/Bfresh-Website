using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Text;
using ViewModel;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        void InsertCategory(Category category);

        [OperationContract]
        void UpdateCategory(Category category);

        [OperationContract]
        CategoryList SelectAllCategory();

       
        //
        [OperationContract]
        void InsertCustomers(Customers customers);
        [OperationContract]
        void UpdateCustomers(Customers customers);  
        [OperationContract] 
        CustomerList SelectAllCustomers();  
        
        //
        [OperationContract]
        void InsertItems(Items items);
        [OperationContract]
        void UpdateItems(Items items);
        [OperationContract]
        ItemsList SelectAllItems();
      
        //
        [OperationContract]
        void InsertOrderDetails(OrderDetails orderdetails);
        [OperationContract]
        void UpdateOrderDetails(OrderDetails orderdetails);
        [OperationContract]
        OrderDetailsList SelectAllOrderDetails();
       
        //
        [OperationContract]
        void InsertOrders(Orders orders);
        [OperationContract]
        void UpdateOrders(Orders orders);
        [OperationContract]
        OrdersList SelectAllOrders();
       
        //
        [OperationContract]
        void InsertToppingDetails(ToppingDetails toppingDetails);
        [OperationContract]
        void UpdateToppingDetails(ToppingDetails toppingDetails);
        [OperationContract]
        ToppingDetailsList SelectAllToppingDetails();
        
        //
        [OperationContract]
        void InsertToppings(Toppings toppings);
        [OperationContract]
        void UpdateToppings(Toppings toppings);
        [OperationContract]
        ToppingsList SelectAllToppings();
        
        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfServiceLibrary1.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }

    }
}
