using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1;
using WpfApp1.ServiceReference1;

namespace BfreshProject
{
    /// <summary>
    /// Interaction logic for NewCustomer.xaml
    /// </summary>
    public partial class NewCustomer : Page
    {
        Customers customer = new Customers();
        public NewCustomer()
        {
            InitializeComponent();
            customer.Manager = false;
          customer.Birthday = DateTime.Now;
            this.DataContext = customer;
            DobDatePicker.DisplayDateStart = DateTime.MinValue;    
            DobDatePicker.DisplayDateEnd = DateTime.Today.AddDays(0);    

        }
      
        public NewCustomer(Customers customer)
        {
           
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = null;
            this.DataContext = customer;
            if (FirstNameTextBox.Text == "" || LastNameTextBox.Text == ""|| PhoneTextBox.Text == "")
            {
                MessageBox.Show("Please fill in all required fields", "", MessageBoxButton.OK, MessageBoxImage.Information);
                

            }
           
             else
             {
              Vars.service1.InsertCustomers(customer);
              Vars.cu = customer;
              MessageBox.Show(customer.FirstName + " " + customer.LastName + " has now joined B-Fresh ", "", MessageBoxButton.OK, MessageBoxImage.Information);
              NavigationService.Navigate(new PageMainWindow2());
             }
                
                
            
           
        }
    }
}
