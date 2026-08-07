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
    /// Interaction logic for WinToppin.xaml
    /// </summary>
    public partial class WinToppin : Window
    {
        int count;
        
        ToppingDetails toppingDetails;
        List<Toppings> lisToppings ;
        List<Toppings> lisMyToppings = new List<Toppings>();
        public WinToppin()
        {
            InitializeComponent();
          lisToppings=Vars.service1.SelectAllToppings().ToList();
            foreach(Toppings toppings in lisToppings)
            {
                CheckBox chb=new CheckBox();
             chb.Tag = toppings;
              chb.Content = toppings.ToppingName;
                
                chb.FontSize = 15;  
                
                
                chb.Checked += Chb_Checked;//  משייך את הצקבסק החדש לפעולה של הבחירה
                chb.Unchecked += Chb_Checked;
                //  משייך את הצקבסק החדש לפעולה של הבחירה
                stk1.Children.Add(chb);
                count =count+1;
            }
        }

        private void Chb_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cc = (CheckBox)sender;

            if (cc.IsChecked==true)
            {
                if(lisMyToppings.Count>4)
                {
                    MessageBox.Show("Choose up to 5 Toppings only");
                    cc.IsChecked = false;
                }
                lisMyToppings.Add(cc.Tag as Toppings);  
            }

            if(cc.IsChecked==false)
            {
                lisMyToppings.Remove(cc.Tag as Toppings);   
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Toppings item in lisMyToppings) // מוסיפה את התוספות שנבחרו לרשימה הכללית שנשמרת בוארס
            {
                 Vars.lisMyToppings.Add (item);
            }

           
            Vars.numTop.Add(lisMyToppings.Count);// סופרת כמה תוספות נבחרו לפרוזן הנוכחי ומוסיפה את המספר לרשימה הכללית כדי שנדע כמה פריטים שייחים לכל פרוזן..
            this.Close();
          
        }
    }
}
