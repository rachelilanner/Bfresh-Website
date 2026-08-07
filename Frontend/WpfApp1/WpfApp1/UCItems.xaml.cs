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
using WpfApp1;
using WpfApp1.ServiceReference1;
using WpfApp2;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for UCItems.xaml
    /// </summary>
    public partial class UCItems : UserControl
    {
        Items items;
        
        bool s, l, v;
        public UCItems(Items items)
        {
            InitializeComponent();
            this.items = items;
            this.DataContext = items;   
            Uri uri=new Uri(Vars.GetCurrectPath() +  @"\Images\" + items.Pic);
            try
            {
                imgPic.Source = new BitmapImage(uri);
            }
            catch (Exception)
            {

                
            }
          radiobtnSmall.Content= items.CategoryId.PriceSmall.ToString();
          radiobtnMedium.Content= items.CategoryId.PriceMedium.ToString();
          radiobtnLarge.Content= items.CategoryId.PriceLarge.ToString();
           
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
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



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((s == false) && (v == false) && (l == false))
            {
                MessageBox.Show("Choose Size", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Item has been added to your cart succesfully!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                OrderDetails orderDetails = new OrderDetails();
                orderDetails.ItemId = this.items;

                orderDetails.Quentity = Convert.ToInt32(ucNum.txtNum.Text);
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
                
              Vars.sal.Add(orderDetails);

               
            }
        }

        
        }
    }

