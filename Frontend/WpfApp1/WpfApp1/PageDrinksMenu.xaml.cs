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


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for PageDrinksMenu.xaml
    /// </summary>
    public partial class PageDrinksMenu : Page
    {
        public PageDrinksMenu()
        {
            InitializeComponent();
            txtCusName.Text = Vars.cu.FirstName;
            txtCusName.FontSize = 15;
            List<Items> list = Vars.service1.SelectAllItems().ToList();
            list = list.Where(it => it.CategoryId.Id == 1).ToList();//סינון הרשימה כך שיביא לי רק פריטים מקטוריה 

            foreach (Items item in list)
            {
                UCItems uu = new UCItems(item);
                uu.Width =455;
                uu.Margin = new Thickness(75);
                uu.Height = 355;
                
                wrp.Children.Add(uu);
            }
        }

        private void btnToCart_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new Cart());
        }
    }
}
