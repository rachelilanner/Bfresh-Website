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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for PageFinish.xaml
    /// </summary>
    public partial class PageFinish : Page
    {
        public PageFinish()
        {
            InitializeComponent();
            txtCusName.Text = Vars.cu.FirstName;
            txtCusName.FontSize = 15;
        }
        public PageFinish(int clubpoints)
        {
            InitializeComponent();
            txtCusName.Text = Vars.cu.FirstName;
            txtCusName.FontSize = 15;
            MessageBox.Show("You now have " + clubpoints + " clubpoints!", "", MessageBoxButton.OK, MessageBoxImage.Information);
           
        }

        private void btnNewOrder_Click(object sender, RoutedEventArgs e)
        {
         
            NavigationService.Navigate(new PageMainWindow2());

        }
    }
}
