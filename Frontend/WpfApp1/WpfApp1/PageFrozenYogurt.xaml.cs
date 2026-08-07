using BfreshProject;
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
using WpfApp1.ServiceReference1;
using WpfApp2;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for PageFrozenYogurt.xaml
    /// </summary>
    public partial class PageFrozenYogurt : Page
    {
        Items items;
        OrderDetails orderDetails = new OrderDetails();
        public PageFrozenYogurt()
        {
            InitializeComponent();
            txtCusName.Text = Vars.cu.FirstName;
            txtCusName.FontSize = 15;

            List<Items> list = Vars.service1.SelectAllItems().ToList();
            list = list.Where(it => it.CategoryId.Id == 3).ToList();

            this.items = list[0];
            this.DataContext = items;

          
            try
            {

                Uri uri = new Uri(Vars.GetCurrectPath() + @"\Images\" + items.Pic);
                img2.Source = new BitmapImage(uri);
            }
            catch (Exception)
            {


            }
            orderDetails.ItemId = items;
            txtFrozen.Text = items.ItemName;
            radiobtnSmall.Content = items.CategoryId.PriceSmall.ToString();
            radiobtnMedium.Content = items.CategoryId.PriceMedium.ToString();
            radiobtnLarge.Content = items.CategoryId.PriceLarge.ToString();
        }
       

          
          
        
        bool s, l, v;

        private void btnToppingWindow_Click(object sender, RoutedEventArgs e)
        {
            WinToppin win = new WinToppin();
            win.Show();
        }

        private void radiobtnSmall_Checked(object sender, RoutedEventArgs e)
        {
            if (radiobtnSmall.IsChecked == true)
            {
                s = true;
            }
            else
            {
                s = false;
            }
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            
            if ((s == false) && (v == false) && (l == false))
            {
                MessageBox.Show("Choose Size", "", MessageBoxButton.OK, MessageBoxImage.Information );
            }
            else
            {
                OrderDetails orderDetails = new OrderDetails();
                orderDetails.ItemId = this.items;

                orderDetails.Quentity = Convert.ToInt32(ucNum.txtNum.Text);
                //להוסיף לפרוט קניה את הגודל וכן, את המחיר לשנות לפני 
                if (s == true)
                {
                    orderDetails.Ssize = items.CategoryId.PriceSmall.ToString();
                    //להוסיף לפרוט קניה את הגודל וכן, את המחיר לשנות לפני 
                    Vars.sum += this.items.CategoryId.PriceSmall * Convert.ToInt32(ucNum.txtNum.Text);



                }
                else
                {
                    if (v == true)
                    {
                        orderDetails.Ssize = items.CategoryId.PriceMedium.ToString();
                        Vars.sum += this.items.CategoryId.PriceMedium * Convert.ToInt32(ucNum.txtNum.Text);


                    }
                    else
                    {
                        if (l == true)
                        {
                            orderDetails.Ssize = items.CategoryId.PriceLarge.ToString();
                            Vars.sum += this.items.CategoryId.PriceLarge * Convert.ToInt32(ucNum.txtNum.Text);


                        }
                    }
                }
                MessageBox.Show("Item added to order successfully!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                Vars.sal.Add(orderDetails);
                radiobtnLarge.IsChecked = false;
                radiobtnMedium.IsChecked = false;
                radiobtnSmall.IsChecked = false;
                this.ucNum.value = 1;
                NavigationService.Navigate(new PageMainWindow2());

            }
        }

        private void radiobtnMedium_Checked(object sender, RoutedEventArgs e)
        {
            if (radiobtnMedium.IsChecked == true)
            {
                v = true;
            }
            else
            {
                v = false;
            }
        }

        private void radiobtnLarge_Checked(object sender, RoutedEventArgs e)
        {
            if (radiobtnLarge.IsChecked == true)
            {
                l = true;
            }
            else
            {
                l = false;
            }
        }
    }
}
