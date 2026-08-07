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
    /// Interaction logic for PageMainWindow2.xaml
    /// </summary>
    public partial class PageMainWindow2 : Page
    {
        public PageMainWindow2()
        {
            InitializeComponent();
        }
        private void FrozenYogurt_Selected(object sender, RoutedEventArgs e)
        {
           
            frm1.Navigate(new PageFrozenYogurt());
        }

        private void Bubble_Selected(object sender, RoutedEventArgs e)
        { 
            frm1.Navigate(new PageNewMenu());
        }

        private void Drinks_Selected(object sender, RoutedEventArgs e)
        {
            
            frm1.Navigate(new PageDrinksMenu());
        }

        private void MyCart_Selected(object sender, RoutedEventArgs e)
        {
            frm1.Navigate(new Cart());
        }


        private void Drinks1_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Home_Selected(object sender, RoutedEventArgs e)
        {
            TypeOfCustomer t = new TypeOfCustomer();
            NavigationService.Navigate(t);
        }
    }
}
