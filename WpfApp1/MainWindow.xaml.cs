using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void data()
        {
            try
            {
                
                SqlConnection thisConnection = new SqlConnection(@"Server=192.168.0.190; Database=mobile; User id=nms; Password=P@ssw0rd");
                thisConnection.Open();

                string Get_Data = "SELECT * FROM product_sell";

                SqlCommand cmd = thisConnection.CreateCommand();
                cmd.CommandText = Get_Data;

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("emp");
                sda.Fill(dt);

                datagrid1.ItemsSource = dt.DefaultView;
            }
            catch
            {
                MessageBox.Show("db error");
            }
        }
    }
}
