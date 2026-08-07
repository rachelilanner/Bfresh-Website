using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for ReturningCustomer.xaml
    /// </summary>
    public partial class ReturningCustomer : Page
    {
        Customers customers;
        public ReturningCustomer()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (txtCustNumber.Text == "")
            {
                MessageBox.Show("Please fill in Phone number field", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if ((Convert.ToInt32(txtCustNumber.Text.Length) > 11) || (Convert.ToInt32(txtCustNumber.Text.Length) < 10))
                {
                    MessageBox.Show("Not a Valid Phone Number", "", MessageBoxButton.OK, MessageBoxImage.Information);
                  txtCustNumber.Text= "";  

                }
                else
                {
                    List<Customers> lst = Vars.service1.SelectAllCustomers().Where(cu => cu.PhoneNum == txtCustNumber.Text).ToList();

                    if (lst.Count == 0)
                    {
                        MessageBox.Show("No Customer Found", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.NavigationService.Navigate(new NewCustomer());

                    }

                    else
                    {
                        if (lst[0].PhoneNum.Equals("0583278158"))
                        {
                            MessageBox.Show("Welcome Manager", "", MessageBoxButton.OK, MessageBoxImage.Information);
                            
                            NavigationService.Navigate(new PageMainWindow3());
                        }
                        else
                        {
                            if ((lst.Count == 1))
                            {
                                MessageBox.Show("Welcome Back " + lst[0].FirstName + " " + lst[0].LastName, "", MessageBoxButton.OK, MessageBoxImage.Information);
                                Vars.cu = lst[0];
                                NavigationService.Navigate(new PageMainWindow2());
                            }

                        }


                    }
                }

            }
        }
    }
}
