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
using BfreshProject;
using WpfApp1.ServiceReference1;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for PagePayment.xaml
    /// </summary>
    public partial class PagePayment : Page
    {
        OrderDetails p1;
        Orders orders=new Orders();
        public PagePayment()
        {
            InitializeComponent();
           

        }
        public PagePayment(int s)
        {
            InitializeComponent();
            //מילוי הקומבובוקסים. 12  חדשים לקומבו של החדשים. ובקומבו של השנים מהשנה הנוכחית ו-9 שנים קדימה
            List<int> listYear = new List<int>();   
            List<int> listMonth = new List<int>();   
            for (int i = DateTime.Today.Year; i < (DateTime.Today.Year+9); i++)
            {
                listYear.Add(i);
            }
            for (int i = 1; i <= 12; i++)
            {
                listMonth.Add(i);
            }
          
            cmbyear.ItemsSource = listYear; 
            cmbmonth.ItemsSource = listMonth; 
            

            txtCusName.Text = Vars.cu.FirstName;
            txtCusName.FontSize = 15;
            txtSum.Text = s.ToString();
           
            orders.OrderDate= DateTime.Today;
            this.DataContext = orders;
          
        }


        private void btnSendOrder_Click_1(object sender, RoutedEventArgs e)
        {
           
            if (txtCCnum.Text.Length < 16 || txtCVV.Text.Length < 3 || cmbmonth.SelectedItem==null || cmbyear.SelectedItem==null)
            {
                MessageBox.Show("Please fill in valid amounts in all required fields");
            }
            else
            {

                //מילוי נתונים להזמנה
                // התארין שבחרובדיקת תאריך האם עבר או לא...
                int early = DateTime.Today.Year;
                int earlyMonth = DateTime.Today.Month;
               
                if (Convert.ToInt32(cmbyear.SelectedItem) == early && Convert.ToInt32(cmbmonth.SelectedItem) < earlyMonth)
                {
                    MessageBox.Show("Not Valid Date");


                }

                else
                {

                    DateTime dd = new DateTime(Convert.ToInt32(cmbyear.SelectedItem), Convert.ToInt32(cmbmonth.SelectedItem), 1);
                    orders.CCdate = dd;



                    orders.CCnum = txtCCnum.Text;
                    orders.CVV = txtCVV.Text;
                    orders.Sum = Convert.ToInt32(txtSum.Text);

                    orders.CustomerId = Vars.cu;
                    //הוספת ההזמנה
                    Vars.service1.InsertOrders(this.orders);
                    //רענון להזמנה האחרונה
                    orders = null;
                    orders = Vars.service1.SelectAllOrders().Last();
                    
                   
                    //  לעבור בלולאה על כל רשימת הפריטים בהזמנה מתוך הוארס, להוסיף להם מספרי הזמנה ולהוסיף לדאטה בייס
                    foreach (OrderDetails parit in Vars.sal)
                    {
                        parit.OrderId = orders;
                        Vars.service1.InsertOrderDetails(parit);

                        //רענון האורדרדטייל
                        p1 = Vars.service1.SelectAllOrderDetails().Last();


                        if (parit.ItemId.CategoryId.Id == 3)
                        {
                              for (int i = 0; i < Vars.numTop[0]; i++)
                              {


                                    ToppingDetails toppingDetails = new ToppingDetails();
                                    toppingDetails.ToppingCode = Vars.lisMyToppings[0];
                                   
                                   
                                    toppingDetails.OrderDetails = p1;
                                    Vars.lisMyToppings.RemoveAt(0); //מחיקת הפריט מהסל כדי שפ...;
                                    Vars.service1.InsertToppingDetails(toppingDetails);
                                  
                              }

                                Vars.numTop.RemoveAt(0); 
                            
                        }

                    }
                    MessageBox.Show("Thank you for your purchase!", "Payment Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    Vars. numTop = new List<int>();
                     Vars.lisMyToppings = new List<Toppings>();
                    Vars.sal = new List<OrderDetails>();
                   
                  Vars.cu.Clubpoints += Convert.ToInt32( 0.2*Vars.sum);//הוסף לקלבפויינטס 20 אחוז מהקנייה
                    Vars.sum = 0;
                    Vars.service1.UpdateCustomers(Vars.cu);
                    
                    NavigationService.Navigate(new PageFinish(Vars.cu.Clubpoints));
                }
            }
        }
    
    }
}
