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
    /// Interaction logic for PageUpdateCategory.xaml
    /// </summary>
    public partial class PageUpdateCategory : Page
    {
        Category category;
        

        public PageUpdateCategory()
        {
            InitializeComponent();
            
            lsvCategory.ItemsSource= Vars.service1.SelectAllCategory().ToList(); 
        }
        

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            grd.DataContext = null;
            grd.DataContext = category;
            category = lsvCategory.SelectedItem as Category;

            MessageBox.Show("Updated succesfully!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            Vars.service1.UpdateCategory(this.category);
            lsvCategory.ItemsSource = null; //כדי לרענן אחר כך את הרשימה מחדש
            lsvCategory.ItemsSource= Vars.service1.SelectAllCategory().ToList();
          




            grd.Visibility = Visibility.Hidden;
        }

            private void btnUpdateCategory_Click(object sender, RoutedEventArgs e)
            {



            if (lsvCategory.SelectedItem is Category category)
            {
                grd.Visibility = Visibility.Visible;
                grd.DataContext = category;

               
                category =lsvCategory.SelectedItem as Category;
              
            }

            }
    }
}
