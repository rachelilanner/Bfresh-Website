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
    /// Interaction logic for PageNewMenu.xaml
    /// </summary>
    public partial class PageNewMenu : Page
    {
        public PageNewMenu()
        {
            InitializeComponent();
            txtCusName.Text = Vars.cu.FirstName;
            txtCusName.FontSize = 15;

            List<Items> list = Vars.service1.SelectAllItems().ToList();
            list = list.Where(it => it.CategoryId.Id == 2).ToList();//סינון הרשימה כך שיביא לי רק פריטים מקטוריה 

            foreach (Items item in list)

            {
            UCBubbleItem UC=new UCBubbleItem(item);
                UC.Width = 425;
                UC.Height = 325;
                UC.Margin = new Thickness(75);

                wrp1.Children.Add(UC);
            }


        }

      

    
        private void btnToCart_Click(object sender, RoutedEventArgs e)
        {
           
            NavigationService.Navigate(new Cart());
        }
    }
}
