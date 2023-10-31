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

namespace PP_U2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] idStrings = TextBox1.Text.Split(' ');
            List<int> ids = new List<int>();

            foreach (string idString in idStrings)
            {
                if (int.TryParse(idString, out int id))
                {
                    ids.Add(id);
                }
            }
            try
            {
                CustomerRepository s = new CustomerRepository();
                List<Customer> foundCustomers = await s.SearchByIDsAsync(ids);
                ListBoxResult.Items.Clear();

                foreach (var customer in foundCustomers)
                {
                    ListBoxResult.Items.Add($"ID: {customer.Id}, Name: {customer.Name}, Address: {customer.Address}, Orders: {customer.NumberOfOrders}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка при търсене: {ex.Message}");
            }
            //ListBoxResult.Items.Add()
        }
    }
}
