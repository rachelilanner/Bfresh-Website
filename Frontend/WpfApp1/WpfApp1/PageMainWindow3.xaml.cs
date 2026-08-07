using System;
using System.Collections.Generic;
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
using BfreshProject;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for PageMainWindow3.xaml
    /// </summary>
    public partial class PageMainWindow3 : Page
    {
        public PageMainWindow3()
        {
            InitializeComponent();
        }
        private void Drinks_Selected(object sender, RoutedEventArgs e)
        {
            frm2.Navigate(new ManagerViewDrinks());
        }

        private void Category_Selected(object sender, RoutedEventArgs e)
        {
           
            frm2.Navigate(new PageUpdateCategory());
        }

        private void Toppings_Selected(object sender, RoutedEventArgs e)
        {
           
            frm2.Navigate(new PageUpdateToppins());
        }

        private void Empty_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Home_Selected(object sender, RoutedEventArgs e)
        {
            TypeOfCustomer t = new TypeOfCustomer();
           NavigationService.Navigate(t);
        }
    }
}
