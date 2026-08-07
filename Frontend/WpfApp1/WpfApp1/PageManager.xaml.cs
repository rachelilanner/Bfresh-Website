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


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for PageManager.xaml
    /// </summary>
    public partial class PageManager : Page
    {
        public PageManager()
        {
            InitializeComponent();
        }

        private void btnViewDrinks_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new ManagerViewDrinks());
        }

        private void btnUpdateCategory_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new PageUpdateCategory());
        }

        private void btnUpdateToppings_Click(object sender, RoutedEventArgs e)
        {
          
            NavigationService.Navigate(new PageUpdateToppins());
        }

       
    }
}
