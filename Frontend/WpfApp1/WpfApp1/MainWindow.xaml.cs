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
using System.ServiceModel;
using BfreshProject;
using WpfApp1.ServiceReference1;
using WpfApp1;

namespace BfreshProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Service1Client service1Client = new Service1Client();
           
        }

        //private void MyCart_Selected(object sender, RoutedEventArgs e)
        //{
        //    Cart t1 = new Cart();
        //    frm.Navigate(t1);   
        //    //NavigationService.Navigate(new Cart());
        //}

        //private void FrozenYogurt_Selected(object sender, RoutedEventArgs e)
        //{
        //    PageFrozenYogurt t1 = new PageFrozenYogurt();
        //    frm.Navigate(t1);
        //    //NavigationService.Navigate(t1);
        //}

        //private void Bubble_Selected(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Drinks_Selected(object sender, RoutedEventArgs e)
        //{
        //    PageDrinksMenu t1 = new PageDrinksMenu();
        //    frm.Navigate(t1);
        //    //NavigationService.Navigate(new PageDrinksMenu());
        //}
    }
}
