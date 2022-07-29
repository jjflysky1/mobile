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
        public class checkedBoxIte
        {
            public string MyString { get; set; }
            public bool MyBool { get; set; }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                mobileEntities Con = new mobileEntities();
                List<Product_sell> TableData = Con.Product_sell.ToList();
                TableData.OrderBy(x => x.no);
                TableData.Reverse();
                datagrid1.ItemsSource = TableData;

            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public DataView GridData
        {
            get
            {
                DataSet ds = new DataSet("MyDataSet");

                using (SqlConnection conn = new SqlConnection("Server=192.168.0.190; Database=mobile; User id=nms; Password=P@ssw0rd"))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select no,product,serial,indate,from_location,outdate,to_location, out_user from Product_sell";

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }

                return ds.Tables[0].DefaultView;
            }
        }
    }
}
