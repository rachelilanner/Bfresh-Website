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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for UCNumericUD.xaml
    /// </summary>
    public partial class UCNumericUD : UserControl
    {
        public int value { get; set; }
       
        public UCNumericUD()
        {
            InitializeComponent();
            this.value = 1;
        
            txtNum.Text = this.value.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.value++;
          txtNum.Text = this.value.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.value > 1)
             this.value--;
           
            txtNum.Text = this.value.ToString();
        }
    }
}
