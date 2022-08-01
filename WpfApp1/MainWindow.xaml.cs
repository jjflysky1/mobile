using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
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
using System.Data.Common;

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
        private mobileEntities adventureWorksLT2008R2Entities = new mobileEntities();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //var query =
                //from product in adventureWorksLT2008R2Entities.Product_sell
                //orderby product.no descending
                //select new { product.no, product.product, product.serial, product.indate, product.from_location, product.outdate, product.to_location, product.out_user };



                //datagrid1.ItemsSource = query.ToList();

                mobileEntities Con = new mobileEntities();
                List<Product_sell> TableData = Con.Product_sell.ToList();

                TableData.OrderBy(x => x.no);
                TableData.Reverse();
                datagrid1.ItemsSource = TableData;




                //this.datagrid1.Background = new System.Windows.Media.SolidColorBrush(Colors.White);

                //for (int i = 0; i < 5; i++)
                //{
                //    checkedBoxIte ite = new checkedBoxIte();
                //    ite.MyString = i.ToString();
                //    TableData.Add(ite);
                //}
                //datagrid1.ItemsSource = TableData;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            textbox1.Text = calendar.SelectedDate.Value.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("HH:mm:ss");

        }

        private void datagrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {


                object item = datagrid1.SelectedItem;
                string ID = (datagrid1.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                if (textbox2.Text.Contains(ID) == true)
                {
                    textbox2.Text = textbox2.Text.Replace(ID + ",", "");
                    var index = ((DataGrid)sender).SelectedIndex;// 
                    DataGridRow row = (DataGridRow)((DataGrid)sender).ItemContainerGenerator.ContainerFromIndex(index);
                    row.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    textbox2.Text += ID + ",";
                    var index = ((DataGrid)sender).SelectedIndex;// 
                    DataGridRow row = (DataGridRow)((DataGrid)sender).ItemContainerGenerator.ContainerFromIndex(index);
                    row.Background = new SolidColorBrush(Colors.Red);
                }

            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

        }

        private void datagrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }



        private void datagrid1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            // 해당 컬럼이 날짜 형식인지 확인
            if (e.PropertyName == "indate" || e.PropertyName == "outdate")
            {
                DataGridTextColumn column = e.Column as DataGridTextColumn;
                Binding binding = column.Binding as Binding;
                binding.StringFormat = "yyyy-MM-dd hh:mm";
            }

            if(e.PropertyName == "oudate")
            {
                this.datagrid1.Background = new System.Windows.Media.SolidColorBrush(Colors.BlueViolet);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textbox3.Text == "")
                {
                    MessageBox.Show("반출처를 입력해주세요");
                }
                else if (textbox1.Text == "")
                {
                    MessageBox.Show("반출날짜를 입력해주세요");
                }
                else if (textbox2.Text == "")
                {
                    MessageBox.Show("물품을 선택해주세요");
                }
                else if (textbox4.Text == "")
                {
                    MessageBox.Show("반출자를 입력해주세요");
                }
                else
                {
                    string[] num = textbox2.Text.Split(',');
                    foreach (string no in num)
                    {
                        SqlConnection CON = new SqlConnection("Server=192.168.0.190; Database=mobile; User id=nms; Password=P@ssw0rd");
                        CON.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = CON;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "update Product_sell set outdate = @outdate , to_location = @to_location, out_user = @out_user where no = @no ";
                        cmd.Parameters.Add("@outdate", SqlDbType.NVarChar, 50).Value = textbox1.Text;
                        cmd.Parameters.Add("@to_location", SqlDbType.NVarChar, 50).Value = textbox3.Text;
                        cmd.Parameters.Add("@out_user", SqlDbType.NVarChar, 50).Value = textbox4.Text;
                        cmd.Parameters.Add("@no", SqlDbType.NVarChar, 4000).Value = no;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        cmd = null;
                        CON.Close();

                    }
                    MessageBox.Show(textbox2.Text + " 물품이" + textbox3.Text + " 로 " + textbox1.Text + " 시간에 반출되었습니다");
                }





                textbox1.Text = "";
                textbox2.Text = "";
                textbox3.Text = "";
                textbox4.Text = "";
                
                this.datagrid1.Background = new System.Windows.Media.SolidColorBrush(Colors.White);

                datagrid1.Items.Refresh();

            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message);
            }
            
        }
    }
}
