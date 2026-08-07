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
using WpfApp1.ServiceReference1;



namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for ManagerViewDrinks.xaml
    /// </summary>
    public partial class ManagerViewDrinks : Page
    {
        

        public ManagerViewDrinks()
        {
            InitializeComponent();
            
          

            
        }



        Items items;
        string status;
        private void btnUpdateDrink_Click(object sender, RoutedEventArgs e)
        {
            status = "update";
            items = lsvDrinks.SelectedItem as Items;
           this.NavigationService.Navigate(new ManagerNewDrink(items,status));
        }

        private void btnNewDrink_Click(object sender, RoutedEventArgs e)
        {
            status = "New";
            items = new Items();
            lsvDrinks.ItemsSource = null;        
            NavigationService.Navigate(new ManagerNewDrink(items, status));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lsvDrinks.ItemsSource = Vars.service1.SelectAllItems().ToList();
        }

       
    }
}
