using BfreshProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for UCOrderLict.xaml
    /// </summary>
    public partial class UCOrderLict : UserControl
    {
        OrderDetails order;
        Cart pageSourc;
        public UCOrderLict(OrderDetails orderDetails, Cart page)
        {
            InitializeComponent();
            this.order = orderDetails;
            this.pageSourc = page;
            this.order.Note = txtNote.Text;
            this.DataContext = order;

            txtprice.Text = order.Quentity.ToString();
            Uri uri = new Uri(Vars.GetCurrectPath() + @"\Images\" + order.ItemId.Pic);
            try
            {
                img.Source = new BitmapImage(uri);
            }
            catch (Exception)
            {


            }

        }

        public UCOrderLict(OrderDetails orderDetails, int from, int count, Cart page)//פריט מסוג פרוזן יש להציג את התוספות שנבחרו
        {
            InitializeComponent();
            this.order = orderDetails;
            this.pageSourc = page;
            for (int i = from; i < count; i++)
            {
                CheckBox cc = new CheckBox();
                cc.Background = new SolidColorBrush(Colors.Red);
                cc.Content = Vars.lisMyToppings[i].ToppingName;
                cc.IsChecked = true;
                cc.Margin = new Thickness(5);
                cc.IsEnabled = false;
                stkTop.Children.Add(cc);
            }




            this.order.Note = txtNote.Text;
            this.DataContext = order;


            Uri uri = new Uri(Vars.GetCurrectPath() + @"\Images\" + order.ItemId.Pic);
            try
            {
                img.Source = new BitmapImage(uri);
            }
            catch (Exception)
            {


            }
            txtprice.Text = order.Quentity.ToString();

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Vars.sum -= order.Quentity * Convert.ToInt32(txtSsize.Text);
            Vars.sal.Remove(this.order);
            pageSourc.ToWrp();
            MessageBox.Show("Cart updated successfully!", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            if (this.order.ItemId.CategoryId.PriceMedium == Convert.ToInt32(txtSsize.Text))
            {
                Vars.sum += this.order.ItemId.CategoryId.PriceMedium;
                order.Quentity = Convert.ToInt32(txtprice.Text) + 1;
                txtprice.Text = order.Quentity.ToString();


            }
            else
            {
                if (this.order.ItemId.CategoryId.PriceLarge == Convert.ToInt32(txtSsize.Text))
                {
                    Vars.sum += this.order.ItemId.CategoryId.PriceLarge;
                    order.Quentity = Convert.ToInt32(txtprice.Text) + 1;
                    txtprice.Text = ((Convert.ToInt32(txtprice.Text)) + 1).ToString();

                }
                else
                {
                    Vars.sum += this.order.ItemId.CategoryId.PriceSmall;
                    order.Quentity = Convert.ToInt32(txtprice.Text) + 1;
                    txtprice.Text = ((Convert.ToInt32(txtprice.Text)) + 1).ToString();
                }
            }
            pageSourc.ToWrp();
            MessageBox.Show("Cart updated successfully!", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(txtprice.Text) == 1)
            {
               
                MessageBox.Show("Minimun amount", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (this.order.ItemId.CategoryId.PriceMedium == Convert.ToInt32(txtSsize.Text))
                {
            Vars.sum -= this.order.ItemId.CategoryId.PriceMedium;
            order.Quentity = Convert.ToInt32(txtprice.Text) - 1;
            txtprice.Text = (Convert.ToInt32(txtprice.Text) - 1).ToString();
        }

                else
                {
            if (this.order.ItemId.CategoryId.PriceLarge == Convert.ToInt32(txtSsize.Text))
            {
                Vars.sum -= this.order.ItemId.CategoryId.PriceLarge;
                order.Quentity = Convert.ToInt32(txtprice.Text) - 1;
                txtprice.Text = (Convert.ToInt32(txtprice.Text) - 1).ToString();
            }
            else
            {
                Vars.sum -= this.order.ItemId.CategoryId.PriceSmall;
                order.Quentity = Convert.ToInt32(txtprice.Text) - 1;
                txtprice.Text = (Convert.ToInt32(txtprice.Text) - 1).ToString();
            }
        }
        pageSourc.ToWrp();
                MessageBox.Show("Cart updated successfully!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
    }

