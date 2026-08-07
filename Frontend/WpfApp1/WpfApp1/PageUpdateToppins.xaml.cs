using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for PageUpdateToppins.xaml
    /// </summary>
    public partial class PageUpdateToppins : Page
    {
        Toppings toppings;
        string status;
        public PageUpdateToppins()
        {
            InitializeComponent();
           
            lsvToppings.ItemsSource = Vars.service1.SelectAllToppings().ToList();
          
        }
       
        private void btnUpdateTopping_Click(object sender, RoutedEventArgs e)
        {
           
            if (lsvToppings.SelectedItem is Toppings toppings)
            {
                grd2.Visibility = Visibility.Visible;
                grd2.DataContext = toppings;
            
                this.status = "update";
                
                toppings = lsvToppings.SelectedItem as Toppings;
                
            }
           
          

        }

        private void btnNewTopping_Click(object sender, RoutedEventArgs e)
        {
          
                grd2.Visibility = Visibility.Visible;
            txtTopping.Text = "";
            this.status = "New";
            
            
        }

        private void btnFinished_Click(object sender, RoutedEventArgs e)
        {
            grd2.DataContext = null;
            grd2.DataContext = toppings;
            if (this.status == "New")
            {
                toppings = new Toppings();
                toppings.ToppingName = txtTopping.Text.ToString();
                Vars.service1.InsertToppings(toppings);

                lsvToppings.ItemsSource = null;//כדי לרענן אחר כך את הרשימה מחדש
                lsvToppings.ItemsSource = Vars.service1.SelectAllToppings().ToList();

                grd2.Visibility = Visibility.Hidden;
            }
            if (status == "update")
            {
                toppings = lsvToppings.SelectedItem as Toppings;

                Vars.service1.UpdateToppings(toppings);


                lsvToppings.ItemsSource = null;//כדי לרענן אחר כך את הרשימה מחדש
                lsvToppings.ItemsSource = Vars.service1.SelectAllToppings().ToList();

                grd2.Visibility = Visibility.Hidden;
                MessageBox.Show("Updated succesfully!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
