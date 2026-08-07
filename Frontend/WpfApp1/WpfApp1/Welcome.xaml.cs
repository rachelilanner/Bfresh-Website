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
using HamburgerMenu;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Page
    {
        public Welcome()
        {
            InitializeComponent();
            txtCusName.Text = Vars.cu.FirstName;
            txtCusName.FontSize = 15;
            
        }

       
       

        private void FrozenYogurt_Selected(object sender, RoutedEventArgs e)
        {
           
            NavigationService.Navigate(new PageFrozenYogurt());
        }

        private void Bubble_Selected(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new PageNewMenu());
        }

        private void Drinks_Selected(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageDrinksMenu());
        }

        private void MyCart_Selected(object sender, RoutedEventArgs e)
        {
           
            NavigationService.Navigate(new Cart());
        }

        private void btnFrozen_Click(object sender, RoutedEventArgs e)
        {
           
            NavigationService.Navigate(new PageFrozenYogurt());
        }

        private void btnBubble_Click(object sender, RoutedEventArgs e)
        {
         
            NavigationService.Navigate(new PageNewMenu());
        }

        private void btnDrinks_Click(object sender, RoutedEventArgs e)
        {
          
            NavigationService.Navigate(new PageDrinksMenu());
        }
    }
}
