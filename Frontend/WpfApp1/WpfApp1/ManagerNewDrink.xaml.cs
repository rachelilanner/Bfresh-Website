using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.ServiceModel.Channels;
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
using Microsoft.Win32;
using WpfApp1.ServiceReference1;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for ManagerNewDrink.xaml
    /// </summary>
    public partial class ManagerNewDrink : Page
    {

        Items items = new Items();//נבנה פריט חדש ריק
        string status;//ותא שנכניס את המצב
        public ManagerNewDrink()
        {
            InitializeComponent();
           
        }
            public ManagerNewDrink(Items items,string st)//פעולה המקבלת פריט וסטטוס
        {
           
            
                InitializeComponent();
                this.items = items;//נאתחל את הפריט עם מה שקיבלנו          

                this.DataContext = this.items;
                this.DataContext = items;
                //ממלא את הנתונים שהוכנסו לפריט החדש
                List<Category> listcategory = Vars.service1.SelectAllCategory().ToList();
                List<Items> listitems = Vars.service1.SelectAllItems().ToList();
                this.cmb.ItemsSource = listcategory;//מילוי הקומבובוקס בסוגי הקטגוריה

                this.status = st;//נאתחל את המצב במה שקיבלנו          
                if (status == "update")
                {


                    cmb.SelectedItem = listcategory.Find(ca => ca.Id == items.CategoryId.Id);//שיהיה כבר כתוב בקומבו מאיזה קטגוריה הפריט שנבחר

                    try//שיראה התמונה של הפריט הנבחר לעדכון
                    {
                        Uri u = new Uri(Vars.GetCurrectPath() + @"\Images\" + items.Pic);
                        imgPic.Source = new BitmapImage(u);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
            
           
        }



            private void btnOK_Click(object sender, RoutedEventArgs e)
        {  
            this.DataContext = null;
            
            this.DataContext = this.items;
            
            
              
                if (status == "New")
                {
                    Vars.service1.InsertItems(this.items);

                }

               
                NavigationService.Navigate(new ManagerViewDrinks());

                if (status == "update")
                {
                    Vars.service1.UpdateItems(this.items);
                }
                this.DataContext = null;

                this.DataContext = this.items;//רענון


                NavigationService.Navigate(new ManagerViewDrinks());
            
        }

        private void btnPic_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();//שיפתח חלונית לבחירת תמונה
            if (openFileDialog.ShowDialog() == true) 
            {
               
                Uri uri=new Uri(openFileDialog.FileName);
                imgPic.Source=new BitmapImage(uri);
                items.Pic = openFileDialog.SafeFileName;
                
            }
        }

       
    }
}
