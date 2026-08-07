using BfreshProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : Page
    {
        public Cart()
        {
            InitializeComponent();
            
            txtCusName.Text = Vars.cu.FirstName;
            txtCusName.FontSize = 15;
            this.ToWrp();
            
           
        }
        public void ToWrp()//עוברת על הסל קניות ומיצרת יוזר קונטרול לתוך הוורפ 
        {
            int index = 0;
            
            int ezer = 0;
            wrp1.Children.Clear();
            foreach (OrderDetails od in Vars.sal)//לכל פריט בעגלה שבווארס
            {
                UCOrderLict ol;
                if (od.ItemId.CategoryId.Id == 3)//אם הפריט מסוג פרוזן
                {
                    ol = new UCOrderLict(od, index, Vars.numTop[ezer] + index, this);

                    index = Vars.numTop[ezer] + index;
                   
                    ezer++;

                }
                else
                {
                    ol = new UCOrderLict(od,this);
                }



                ol.Width = 650;
                ol.Height = 450;
                ol.Margin = new Thickness(75);
                wrp1.Children.Add(ol);
                txtAmount.Text = Vars.sum.ToString();
            }
        }
        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
     
            int s = Vars.sum;
           
            PagePayment t1 = new PagePayment(s);
            NavigationService.Navigate(t1);

        }

        
    }
}
