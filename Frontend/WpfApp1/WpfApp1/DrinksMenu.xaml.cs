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

namespace BfreshProject
{
    /// <summary>
    /// Interaction logic for DrinksMenu.xaml
    /// </summary>
    public partial class DrinksMenu : Page
    {
        public DrinksMenu()
        {
            InitializeComponent();
            List<Items> list=Vars.service1.SelectAllItems().ToList();
            foreach (Items item in list)
            {
                UCItems uu = new UCItems(item);
                uu.Width = 100;
                uu.Height = 100;
            wrp.Children.Add(uu);

            }
        }
    }
}
