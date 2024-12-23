using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace insert
{
    public partial class Form2 : Form
    {
        DBCON.Class1 DBCON = new DBCON.Class1();
        public Form2()
        {
            InitializeComponent();
            comboBox1.Items.Add("제품 키");
            comboBox1.Items.Add("제품 명");
            comboBox1.Items.Add("반입 처");
            comboBox1.Items.Add("반출 처");
            comboBox1.Items.Add("반출 자");
            comboBox1.Items.Add("매출 처");

            this.ResizeRedraw = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            data4();
            data3();
            data2();
            data();
        }
        public void data()
        {

            ///체크박스
            ///
            dataGridView1.Columns.Clear();
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "X";
            //checkColumn.HeaderText = "";
            checkColumn.ReadOnly = true;

            dataGridView1.Columns.Add(checkColumn);


            SqlConnection CON = new SqlConnection(DBCON.DBCON);
            //where outdate is null
            string SQL = "select no,product,serial,indate,from_purchaser, from_location,outdate,to_location, customer, out_user  from Product_sell order by no desc";
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, CON);
            //ADT.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(ADT);
            //ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= 1 and tempno <= 9999 and outdate is null");
            //ADT.SelectCommand.Parameters.AddWithValue("@search", " ");
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            ADT.Fill(table);
            bindingSource1.DataSource = table;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns["no"].ReadOnly = true;
            dataGridView1.Columns["no"].HeaderText = "번호";
            dataGridView1.Columns["product"].ReadOnly = true;
            dataGridView1.Columns["product"].HeaderText = "상품";
            dataGridView1.Columns["serial"].ReadOnly = true;
            dataGridView1.Columns["serial"].HeaderText = "시리얼";
            dataGridView1.Columns["indate"].ReadOnly = true;
            dataGridView1.Columns["indate"].HeaderText = "반입 일";
            dataGridView1.Columns["from_purchaser"].ReadOnly = true;
            dataGridView1.Columns["from_purchaser"].HeaderText = "매입 처";
            dataGridView1.Columns["from_location"].ReadOnly = true;
            dataGridView1.Columns["from_location"].HeaderText = "반입 처";
            dataGridView1.Columns["outdate"].ReadOnly = true;
            dataGridView1.Columns["outdate"].HeaderText = "반출 일";
            dataGridView1.Columns["to_location"].ReadOnly = true;
            dataGridView1.Columns["to_location"].HeaderText = "반출 처";
            dataGridView1.Columns["customer"].ReadOnly = true;
            dataGridView1.Columns["customer"].HeaderText = "매출 처";
            dataGridView1.Columns["out_user"].ReadOnly = true;
            dataGridView1.Columns["out_user"].HeaderText = "반출 자";


            dataGridView1.Columns["no"].Visible = false;


            groupBox5.Text = "재고 목록 : " + dataGridView1.RowCount.ToString();




            ///data
            //string SQL = "select distinct serverip from ser_config";
            //SqlDataAdapter ADT2 = new SqlDataAdapter(SQL, CON);
            //DataSet DBSET2 = new DataSet();
            //ADT2.Fill(DBSET2, "BD");
            //string serverip = "";
            //foreach (DataRow row in DBSET2.Tables["BD"].Rows)
            //{
            //    serverip = row["serverip"].ToString();
            //}




            //DataGridViewButtonColumn buttoncell = new DataGridViewButtonColumn();
            //buttoncell.Name = "삭제";
            //buttoncell.HeaderText = "삭제";
            //dataGridView1.Columns.Add(buttoncell);

            foreach (DataGridViewRow Myrow in dataGridView1.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                         //MessageBox.Show(Myrow.Cells[4].Value.ToString());


                if (Myrow.Cells[7].Value.ToString() == "")// Or your condition 
                {

                    //Myrow.DefaultCellStyle.BackColor = Color.Red;
                    //Myrow.DefaultCellStyle.BackColor = Color.LightGreen;

                }
                else
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Khaki;
                }
            }


            //if (dataGridView1.Columns["outdate"].ToString() == "")
            //{
            //    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Green;
            //}


        }
        public void data2()
        {

            ///체크박스
            ///
            dataGridView2.Columns.Clear();
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "X";
            checkColumn.HeaderText = "";
            checkColumn.ReadOnly = false;
            dataGridView2.Columns.Add(checkColumn);


            SqlConnection CON = new SqlConnection(DBCON.DBCON);
            //where outdate is null
            string SQL = "select no,product,serial,indate,from_location,outdate,to_location,customer, out_user from product_mine   order by no desc";
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, CON);
            //ADT.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(ADT);
            //ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= 1 and tempno <= 9999 and outdate is null");
            //ADT.SelectCommand.Parameters.AddWithValue("@search", " ");
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            ADT.Fill(table);
            bindingSource2.DataSource = table;

            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.DataSource = bindingSource2;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            //checkColumn.Width = 20;

            dataGridView2.Columns[0].Width = 40;
            dataGridView2.Columns["no"].ReadOnly = true;
            dataGridView2.Columns["no"].HeaderText = "번호";
            dataGridView2.Columns["product"].ReadOnly = true;
            dataGridView2.Columns["product"].HeaderText = "상품";
            dataGridView2.Columns["serial"].ReadOnly = true;
            dataGridView2.Columns["serial"].HeaderText = "시리얼";
            dataGridView2.Columns["indate"].ReadOnly = true;
            dataGridView2.Columns["indate"].HeaderText = "반입 일";
            dataGridView2.Columns["from_location"].ReadOnly = true;
            dataGridView2.Columns["from_location"].HeaderText = "반입 처";
            dataGridView2.Columns["outdate"].ReadOnly = true;
            dataGridView2.Columns["outdate"].HeaderText = "반출 일";
            dataGridView2.Columns["to_location"].ReadOnly = true;
            dataGridView2.Columns["to_location"].HeaderText = "반출 처";
            dataGridView2.Columns["customer"].ReadOnly = true;
            dataGridView2.Columns["customer"].HeaderText = "매출 처";
            dataGridView2.Columns["out_user"].ReadOnly = true;
            dataGridView2.Columns["out_user"].HeaderText = "반출 자";


            dataGridView2.Columns["no"].Visible = false;


            groupBox5.Text = "재고 목록 : " + dataGridView2.RowCount.ToString();




            ///data
            //string SQL = "select distinct serverip from ser_config";
            //SqlDataAdapter ADT2 = new SqlDataAdapter(SQL, CON);
            //DataSet DBSET2 = new DataSet();
            //ADT2.Fill(DBSET2, "BD");
            //string serverip = "";
            //foreach (DataRow row in DBSET2.Tables["BD"].Rows)
            //{
            //    serverip = row["serverip"].ToString();
            //}




            //DataGridViewButtonColumn buttoncell = new DataGridViewButtonColumn();
            //buttoncell.Name = "삭제";
            //buttoncell.HeaderText = "삭제";
            //dataGridView2.Columns.Add(buttoncell);

            foreach (DataGridViewRow Myrow in dataGridView2.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                         //MessageBox.Show(Myrow.Cells[4].Value.ToString());
                if (Myrow.Cells[7].Value.ToString() == "")// Or your condition 
                {

                    //Myrow.DefaultCellStyle.BackColor = Color.Red;
                    //Myrow.DefaultCellStyle.BackColor = Color.LightGreen;

                }
                else
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Khaki;

                }
            }


            //if (dataGridView2.Columns["outdate"].ToString() == "")
            //{
            //    dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.Green;
            //}


        }
        public void data3()
        {

            ///체크박스
            ///
            dataGridView3.Columns.Clear();
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "X";
            checkColumn.HeaderText = "";
            checkColumn.ReadOnly = false;
            ////checkColumn.Width = 20;
            dataGridView3.Columns.Add(checkColumn);


            SqlConnection CON = new SqlConnection(DBCON.DBCON);
            //where outdate is null
            string SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer,out_user from product_demo  order by no desc";
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, CON);
            //ADT.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(ADT);
            //ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= 1 and tempno <= 9999 and outdate is null");
            //ADT.SelectCommand.Parameters.AddWithValue("@search", " ");
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            ADT.Fill(table);
            bindingSource3.DataSource = table;

            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.DataSource = bindingSource3;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView3.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);



            dataGridView3.Columns[0].Width = 40;
            dataGridView3.Columns["no"].ReadOnly = true;
            dataGridView3.Columns["no"].HeaderText = "번호";
            dataGridView3.Columns["product"].ReadOnly = true;
            dataGridView3.Columns["product"].HeaderText = "상품";
            dataGridView3.Columns["serial"].ReadOnly = true;
            dataGridView3.Columns["serial"].HeaderText = "시리얼";
            dataGridView3.Columns["indate"].ReadOnly = true;
            dataGridView3.Columns["indate"].HeaderText = "반입 일";
            dataGridView3.Columns["from_location"].ReadOnly = true;
            dataGridView3.Columns["from_location"].HeaderText = "반입 처";
            dataGridView3.Columns["outdate"].ReadOnly = true;
            dataGridView3.Columns["outdate"].HeaderText = "반출 일";
            dataGridView3.Columns["to_location"].ReadOnly = true;
            dataGridView3.Columns["to_location"].HeaderText = "반출 처";
            dataGridView3.Columns["customer"].ReadOnly = true;
            dataGridView3.Columns["customer"].HeaderText = "매출 처";
            dataGridView3.Columns["out_user"].ReadOnly = true;
            dataGridView3.Columns["out_user"].HeaderText = "반출 자";


            dataGridView3.Columns["no"].Visible = false;


            groupBox5.Text = "재고 목록 : " + dataGridView3.RowCount.ToString();




            ///data
            //string SQL = "select distinct serverip from ser_config";
            //SqlDataAdapter ADT2 = new SqlDataAdapter(SQL, CON);
            //DataSet DBSET2 = new DataSet();
            //ADT2.Fill(DBSET2, "BD");
            //string serverip = "";
            //foreach (DataRow row in DBSET2.Tables["BD"].Rows)
            //{
            //    serverip = row["serverip"].ToString();
            //}




            //DataGridViewButtonColumn buttoncell = new DataGridViewButtonColumn();
            //buttoncell.Name = "삭제";
            //buttoncell.HeaderText = "삭제";
            //dataGridView3.Columns.Add(buttoncell);

            foreach (DataGridViewRow Myrow in dataGridView3.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                         //MessageBox.Show(Myrow.Cells[4].Value.ToString());
                if (Myrow.Cells[7].Value.ToString() == "")// Or your condition 
                {

                    //Myrow.DefaultCellStyle.BackColor = Color.Red;
                    //Myrow.DefaultCellStyle.BackColor = Color.LightGreen;

                }
                else
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Khaki;


                }
            }


            //if (dataGridView3.Columns["outdate"].ToString() == "")
            //{
            //    dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.Green;
            //}


        }
        public void data4()
        {
            try
            {
                ///체크박스
                ///
                dataGridView4.Columns.Clear();
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "X";
                checkColumn.HeaderText = "";
                checkColumn.ReadOnly = false;
                dataGridView4.Columns.Add(checkColumn);
                ////checkColumn.Width = 20;
                SqlConnection CON = new SqlConnection(DBCON.DBCON);
                //where outdate is null
                string SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_rma order by no desc";
                SqlDataAdapter ADT = new SqlDataAdapter(SQL, CON);
                //ADT.SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(ADT);
                //ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= 1 and tempno <= 9999 and outdate is null");
                //ADT.SelectCommand.Parameters.AddWithValue("@search", " ");
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                ADT.Fill(table);
                bindingSource4.DataSource = table;

                dataGridView4.AllowUserToAddRows = false;
                dataGridView4.DataSource = bindingSource4;
                dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dataGridView3.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);



                dataGridView4.Columns[0].Width = 40;
                dataGridView4.Columns["no"].ReadOnly = true;
                dataGridView4.Columns["no"].HeaderText = "번호";
                dataGridView4.Columns["product"].ReadOnly = true;
                dataGridView4.Columns["product"].HeaderText = "상품";
                dataGridView4.Columns["serial"].ReadOnly = true;
                dataGridView4.Columns["serial"].HeaderText = "시리얼";
                dataGridView4.Columns["indate"].ReadOnly = true;
                dataGridView4.Columns["indate"].HeaderText = "반입 일";
                dataGridView4.Columns["from_location"].ReadOnly = true;
                dataGridView4.Columns["from_location"].HeaderText = "반입 처";
                dataGridView4.Columns["outdate"].ReadOnly = true;
                dataGridView4.Columns["outdate"].HeaderText = "반출 일";
                dataGridView4.Columns["to_location"].ReadOnly = true;
                dataGridView4.Columns["to_location"].HeaderText = "반출 처";
                dataGridView4.Columns["customer"].ReadOnly = true;
                dataGridView4.Columns["customer"].HeaderText = "매출 처";
                dataGridView4.Columns["out_user"].ReadOnly = true;
                dataGridView4.Columns["out_user"].HeaderText = "반출 자";

                dataGridView4.Columns["no"].Visible = false;


                groupBox5.Text = "재고 목록 : " + dataGridView4.RowCount.ToString();


                foreach (DataGridViewRow Myrow in dataGridView4.Rows)
                {            //Here 2 cell is target value and 1 cell is Volume
                             //MessageBox.Show(Myrow.Cells[4].Value.ToString());
                    if (Myrow.Cells[7].Value.ToString() == "")// Or your condition 
                    {

                        //Myrow.DefaultCellStyle.BackColor = Color.Red;
                        //Myrow.DefaultCellStyle.BackColor = Color.LightGreen;

                    }
                    else
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.Khaki;

                    }
                }



            }
            catch (Exception E)
            { MessageBox.Show(E.Message); }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabpage1"])//your specific tabname
            {

                if (textBox5.Text == "")
                {
                    MessageBox.Show("반출처를 입력해주세요");
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("반출날짜를 입력해주세요");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("물품을 선택해주세요");
                }
                else if (textBox9.Text == "")
                {
                    MessageBox.Show("반출자를 입력해주세요");
                }
                else if (textBox11.Text == "")
                {
                    MessageBox.Show("매출 처를 입력해주세요");
                }
                else
                {
                    string[] num = textBox4.Text.Split(';');
                    int count = 0;
                    foreach (string no in num)
                    {
                        SqlConnection CON = new SqlConnection(DBCON.DBCON);
                        CON.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = CON;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "update Product_sell set outdate = @outdate , to_location = @to_location, out_user = @out_user, customer = @customer where no = @no ";
                        cmd.Parameters.Add("@outdate", SqlDbType.NVarChar, 50).Value = textBox6.Text;
                        cmd.Parameters.Add("@to_location", SqlDbType.NVarChar, 50).Value = textBox5.Text;
                        cmd.Parameters.Add("@out_user", SqlDbType.NVarChar, 50).Value = textBox9.Text;
                        cmd.Parameters.Add("@customer", SqlDbType.NVarChar, 50).Value = textBox11.Text;
                        cmd.Parameters.Add("@no", SqlDbType.NVarChar, 4000).Value = no;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        cmd = null;
                        CON.Close();
                        count++;
                    }
                    count--;
                    MessageBox.Show(textBox4.Text + " 물품이" + textBox5.Text + " 로 " + textBox6.Text + " 시간에 반출되었습니다" + "   총 : " + count);
                }


                Form2_Load(this, null);


                textBox5.Text = "";
                textBox6.Text = "";
                textBox9.Text = "";
                textBox11.Text = "";
                textBox4.Text = "";
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabpage2"])//your specific tabname
            {
                if (textBox5.Text == "")
                {
                    MessageBox.Show("반출처를 입력해주세요");
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("반출날짜를 입력해주세요");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("물품을 선택해주세요");
                }
                else if (textBox9.Text == "")
                {
                    MessageBox.Show("반출자를 입력해주세요");
                }
                else
                {
                    string[] num = textBox4.Text.Split(';');
                    foreach (string no in num)
                    {
                        SqlConnection CON = new SqlConnection(DBCON.DBCON);
                        CON.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = CON;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "update Product_mine set outdate = @outdate , to_location = @to_location, out_user = @customer, customer = @customer where no = @no ";
                        cmd.Parameters.Add("@outdate", SqlDbType.NVarChar, 50).Value = textBox6.Text;
                        cmd.Parameters.Add("@to_location", SqlDbType.NVarChar, 50).Value = textBox5.Text;
                        cmd.Parameters.Add("@out_user", SqlDbType.NVarChar, 50).Value = textBox9.Text;
                        cmd.Parameters.Add("@customer", SqlDbType.NVarChar, 50).Value = textBox11.Text;
                        cmd.Parameters.Add("@no", SqlDbType.NVarChar, 4000).Value = no;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        cmd = null;
                        CON.Close();

                    }
                    MessageBox.Show(textBox5.Text + " 로 " + textBox6.Text + " 시간에 반출되었습니다");
                }


                Form2_Load(this, null);


                textBox5.Text = "";
                textBox6.Text = "";
                textBox9.Text = "";
                textBox11.Text = "";
                textBox4.Text = "";
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabpage3"])//your specific tabname
            {
                if (textBox5.Text == "")
                {
                    MessageBox.Show("반출처를 입력해주세요");
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("반출날짜를 입력해주세요");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("물품을 선택해주세요");
                }
                else if (textBox9.Text == "")
                {
                    MessageBox.Show("반출자를 입력해주세요");
                }
                else if (textBox11.Text == "")
                {
                    MessageBox.Show("매출 처를 입력해주세요");
                }
                else
                {
                    string[] num = textBox4.Text.Split(';');
                    foreach (string no in num)
                    {
                        SqlConnection CON = new SqlConnection(DBCON.DBCON);
                        CON.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = CON;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "update Product_demo set outdate = @outdate , to_location = @to_location, out_user = @customer, customer = @customer where no = @no ";
                        cmd.Parameters.Add("@outdate", SqlDbType.NVarChar, 50).Value = textBox6.Text;
                        cmd.Parameters.Add("@to_location", SqlDbType.NVarChar, 50).Value = textBox5.Text;
                        cmd.Parameters.Add("@out_user", SqlDbType.NVarChar, 50).Value = textBox9.Text;
                        cmd.Parameters.Add("@customer", SqlDbType.NVarChar, 50).Value = textBox11.Text;
                        cmd.Parameters.Add("@no", SqlDbType.NVarChar, 4000).Value = no;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        cmd = null;
                        CON.Close();

                    }
                    MessageBox.Show(textBox5.Text + " 로 " + textBox6.Text + " 시간에 반출되었습니다");
                }


                Form2_Load(this, null);


                textBox5.Text = "";
                textBox6.Text = "";
                textBox9.Text = "";
                textBox11.Text = "";
                textBox4.Text = "";
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabpage4"])//your specific tabname
            {
                if (textBox5.Text == "")
                {
                    MessageBox.Show("반출처를 입력해주세요");
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("반출날짜를 입력해주세요");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("물품을 선택해주세요");
                }
                else if (textBox9.Text == "")
                {
                    MessageBox.Show("반출자를 입력해주세요");
                }
                else if (textBox11.Text == "")
                {
                    MessageBox.Show("매출 처를 입력해주세요");
                }
                else
                {
                    string[] num = textBox4.Text.Split(';');
                    foreach (string no in num)
                    {
                        SqlConnection CON = new SqlConnection(DBCON.DBCON);
                        CON.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = CON;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "update Product_rma set outdate = @outdate , to_location = @to_location, out_user = @customer, customer = @customer where no = @no ";
                        cmd.Parameters.Add("@outdate", SqlDbType.NVarChar, 50).Value = textBox6.Text;
                        cmd.Parameters.Add("@to_location", SqlDbType.NVarChar, 50).Value = textBox5.Text;
                        cmd.Parameters.Add("@out_user", SqlDbType.NVarChar, 50).Value = textBox9.Text;
                        cmd.Parameters.Add("@customer", SqlDbType.NVarChar, 50).Value = textBox11.Text;
                        cmd.Parameters.Add("@no", SqlDbType.NVarChar, 4000).Value = no;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        cmd = null;
                        CON.Close();

                    }
                    MessageBox.Show(textBox5.Text + " 로 " + textBox6.Text + " 시간에 반출되었습니다");
                }


                Form2_Load(this, null);


                textBox5.Text = "";
                textBox6.Text = "";
                textBox9.Text = "";
                textBox11.Text = "";
                textBox4.Text = "";
            }



        }

        //체크박스 클릭시 이벤트
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0];

            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            DataGridViewRow dr = dataGridView1.SelectedRows[0];

                            if (textBox4.Text == "")
                            {
                                textBox4.Text = dr.Cells[1].Value.ToString() + ";";
                            }
                            else
                            {
                                textBox4.Text = textBox4.Text.Replace(dr.Cells[1].Value.ToString() + ";", "");
                            }
                        }
                    }
                    break;
                case "False":
                    ch1.Value = true;
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            DataGridViewRow dr = dataGridView1.SelectedRows[0];

                            if (textBox4.Text == "")
                            {
                                textBox4.Text = dr.Cells[1].Value.ToString() + ";";
                            }
                            else
                            {
                                textBox4.Text += dr.Cells[1].Value.ToString() + ";";
                            }
                        }
                    }
                    break;
            }

            //MessageBox.Show(ch1.Value.ToString());
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0];

            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            DataGridViewRow dr = dataGridView2.SelectedRows[0];

                            if (textBox4.Text == "")
                            {
                                textBox4.Text = dr.Cells[1].Value.ToString() + ";";
                            }
                            else
                            {
                                textBox4.Text = textBox4.Text.Replace(dr.Cells[1].Value.ToString() + ";", "");
                            }
                        }
                    }
                    break;
                case "False":
                    ch1.Value = true;
                    foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            DataGridViewRow dr = dataGridView2.SelectedRows[0];

                            if (textBox4.Text == "")
                            {
                                textBox4.Text = dr.Cells[1].Value.ToString() + ";";
                            }
                            else
                            {
                                textBox4.Text += dr.Cells[1].Value.ToString() + ";";
                            }
                        }
                    }
                    break;
            }
            //MessageBox.Show(ch1.Value.ToString());
        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[0];

            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    foreach (DataGridViewRow row in dataGridView3.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            DataGridViewRow dr = dataGridView3.SelectedRows[0];

                            if (textBox4.Text == "")
                            {
                                textBox4.Text = dr.Cells[1].Value.ToString() + ";";
                            }
                            else
                            {
                                textBox4.Text = textBox4.Text.Replace(dr.Cells[1].Value.ToString() + ";", "");
                            }
                        }
                    }
                    break;
                case "False":
                    ch1.Value = true;
                    foreach (DataGridViewRow row in dataGridView3.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            DataGridViewRow dr = dataGridView3.SelectedRows[0];

                            if (textBox4.Text == "")
                            {
                                textBox4.Text = dr.Cells[1].Value.ToString() + ";";
                            }
                            else
                            {
                                textBox4.Text += dr.Cells[1].Value.ToString() + ";";
                            }
                        }
                    }
                    break;
            }
            //MessageBox.Show(ch1.Value.ToString());
        }
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dataGridView4.Rows[dataGridView3.CurrentRow.Index].Cells[0];

            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    foreach (DataGridViewRow row in dataGridView4.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            DataGridViewRow dr = dataGridView4.SelectedRows[0];

                            if (textBox4.Text == "")
                            {
                                textBox4.Text = dr.Cells[1].Value.ToString() + ";";
                            }
                            else
                            {
                                textBox4.Text = textBox4.Text.Replace(dr.Cells[1].Value.ToString() + ";", "");
                            }
                        }
                    }
                    break;
                case "False":
                    ch1.Value = true;
                    foreach (DataGridViewRow row in dataGridView4.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            DataGridViewRow dr = dataGridView4.SelectedRows[0];

                            if (textBox4.Text == "")
                            {
                                textBox4.Text = dr.Cells[1].Value.ToString() + ";";
                            }
                            else
                            {
                                textBox4.Text += dr.Cells[1].Value.ToString() + ";";
                            }
                        }
                    }
                    break;
            }
            //MessageBox.Show(ch1.Value.ToString());
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.TodayDate = monthCalendar1.SelectionStart;
            textBox6.Text = monthCalendar1.SelectionStart.ToShortDateString() + " " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabpage1"])//your specific tabname
                {
                    dataGridView1.Columns.Clear();
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    checkColumn.Name = "X";
                    checkColumn.HeaderText = "";
                    //checkColumn.ReadOnly = false;
                    dataGridView1.Columns.Add(checkColumn);


                    SqlConnection CON = new SqlConnection(DBCON.DBCON);
                    string SQL = "";
                    //if (comboBox1.Text == "제품 명")
                    //{
                    //    //outdate is null
                    //    SQL = "select  no,product,serial,indate, from_purchaser,from_location,outdate,to_location,  customer, out_user from Product_sell where   product like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "제품 키")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate, from_purchaser,from_location,outdate,to_location, customer,  out_user from Product_sell where   serial like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "반출 처")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate, from_purchaser,from_location,outdate,to_location, customer, out_user from Product_sell where   to_location like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "반입 처")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate, from_purchaser,from_location,outdate,to_location, customer, out_user from Product_sell where   from_location like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "반출 자")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate, from_purchaser,from_location,outdate,to_location, customer, out_user from Product_sell where   out_user like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "매출 처")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate, from_purchaser,from_location,outdate,to_location, customer, out_user from Product_sell where   customer like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    SQL = "select no,product,serial,indate, from_purchaser,from_location,outdate,to_location, customer, out_user from Product_sell where  " +
                        "product like  '%" + textBox7.Text + "%' " +
                        "or serial like '%" + textBox7.Text + "%'" +
                        "or to_location like '%" + textBox7.Text + "%'" +
                        "or from_location like '%" + textBox7.Text + "%'" +
                        "or out_user like '%" + textBox7.Text + "%'" +
                        "or customer like '%" + textBox7.Text + "%'" +
                        "order by no desc";

                    SqlDataAdapter ADT = new SqlDataAdapter(SQL, CON);
                    //ADT.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(ADT);
                    //ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= 1 and tempno <= 9999 and outdate is null");
                    //ADT.SelectCommand.Parameters.AddWithValue("@search", " ");
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    ADT.Fill(table);
                    bindingSource1.DataSource = table;

                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.DataSource = bindingSource1;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                    //checkColumn.Width = 20;

                    dataGridView1.Columns["no"].ReadOnly = true;
                    dataGridView1.Columns["no"].HeaderText = "번호";
                    dataGridView1.Columns["product"].ReadOnly = true;
                    dataGridView1.Columns["product"].HeaderText = "상품";
                    dataGridView1.Columns["serial"].ReadOnly = true;
                    dataGridView1.Columns["serial"].HeaderText = "시리얼";
                    dataGridView1.Columns["indate"].ReadOnly = true;
                    dataGridView1.Columns["indate"].HeaderText = "반입 일";
                    dataGridView1.Columns["from_purchaser"].ReadOnly = true;
                    dataGridView1.Columns["from_purchaser"].HeaderText = "매입 처";
                    dataGridView1.Columns["from_location"].ReadOnly = true;
                    dataGridView1.Columns["from_location"].HeaderText = "반입 처";
                    dataGridView1.Columns["outdate"].ReadOnly = true;
                    dataGridView1.Columns["outdate"].HeaderText = "반출 일";
                    dataGridView1.Columns["to_location"].ReadOnly = true;
                    dataGridView1.Columns["to_location"].HeaderText = "반출 처";
                    dataGridView1.Columns["customer"].ReadOnly = true;
                    dataGridView1.Columns["customer"].HeaderText = "매출 처";
                    dataGridView1.Columns["out_user"].ReadOnly = true;
                    dataGridView1.Columns["out_user"].HeaderText = "반출 자";


                    dataGridView1.Columns["no"].Visible = false;


                    groupBox5.Text = "재고 목록 : " + dataGridView1.RowCount.ToString();

                    foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                    {            //Here 2 cell is target value and 1 cell is Volume
                                 //MessageBox.Show(Myrow.Cells[4].Value.ToString());
                        if (Myrow.Cells[7].Value.ToString() == "")// Or your condition 
                        {

                            //Myrow.DefaultCellStyle.BackColor = Color.Red;
                            //Myrow.DefaultCellStyle.BackColor = Color.LightGreen;

                        }
                        else
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.Khaki;


                        }
                    }

                }
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabpage2"])//your specific tabname
                {
                    dataGridView2.Columns.Clear();
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    checkColumn.Name = "X";
                    checkColumn.HeaderText = "";
                    checkColumn.ReadOnly = false;
                    dataGridView2.Columns.Add(checkColumn);


                    SqlConnection CON = new SqlConnection(DBCON.DBCON);
                    string SQL = "";
                    //if (comboBox1.Text == "제품 명")
                    //{
                    //    //outdate is null
                    //    SQL = "select  no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_mine where   product like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "제품 키")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_mine where   serial like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "반출 처")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_mine where   to_location like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "반입 처")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_mine where   from_location like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "반출 자")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from Product_mine where   out_user like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "매출 처")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from Product_mine where   customer like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    SQL = "select no,product,serial,indate, from_location,outdate,to_location, customer, out_user from Product_mine where  " +
                        "product like  '%" + textBox7.Text + "%' " +
                        "or serial like '%" + textBox7.Text + "%'" +
                        "or to_location like '%" + textBox7.Text + "%'" +
                        "or from_location like '%" + textBox7.Text + "%'" +
                        "or out_user like '%" + textBox7.Text + "%'" +
                        "or customer like '%" + textBox7.Text + "%'" +
                        "order by no desc";

                    SqlDataAdapter ADT = new SqlDataAdapter(SQL, CON);
                    //ADT.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(ADT);
                    //ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= 1 and tempno <= 9999 and outdate is null");
                    //ADT.SelectCommand.Parameters.AddWithValue("@search", " ");
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    ADT.Fill(table);
                    bindingSource2.DataSource = table;

                    dataGridView2.AllowUserToAddRows = false;
                    dataGridView2.DataSource = bindingSource2;
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                    //checkColumn.Width = 20;

                    dataGridView2.Columns["no"].ReadOnly = true;
                    dataGridView2.Columns["no"].HeaderText = "번호";
                    dataGridView2.Columns["product"].ReadOnly = true;
                    dataGridView2.Columns["product"].HeaderText = "상품";
                    dataGridView2.Columns["serial"].ReadOnly = true;
                    dataGridView2.Columns["serial"].HeaderText = "시리얼";
                    dataGridView2.Columns["indate"].ReadOnly = true;
                    dataGridView2.Columns["indate"].HeaderText = "반입 일";
                    dataGridView2.Columns["from_location"].ReadOnly = true;
                    dataGridView2.Columns["from_location"].HeaderText = "반입 처";
                    dataGridView2.Columns["outdate"].ReadOnly = true;
                    dataGridView2.Columns["outdate"].HeaderText = "반출 일";
                    dataGridView2.Columns["to_location"].ReadOnly = true;
                    dataGridView2.Columns["to_location"].HeaderText = "반출 처";
                    dataGridView2.Columns["customer"].ReadOnly = true;
                    dataGridView2.Columns["customer"].HeaderText = "매출 처";
                    dataGridView2.Columns["out_user"].ReadOnly = true;
                    dataGridView2.Columns["out_user"].HeaderText = "반출 자";

                    dataGridView2.Columns["no"].Visible = false;


                    groupBox5.Text = "재고 목록 : " + dataGridView2.RowCount.ToString();

                    foreach (DataGridViewRow Myrow in dataGridView2.Rows)
                    {            //Here 2 cell is target value and 1 cell is Volume
                                 //MessageBox.Show(Myrow.Cells[4].Value.ToString());
                        if (Myrow.Cells[7].Value.ToString() == "")// Or your condition 
                        {

                            //Myrow.DefaultCellStyle.BackColor = Color.Red;
                            //Myrow.DefaultCellStyle.BackColor = Color.LightGreen;

                        }
                        else
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.Khaki;


                        }
                    }
                }
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabpage3"])//your specific tabname
                {
                    dataGridView3.Columns.Clear();
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    checkColumn.Name = "X";
                    checkColumn.HeaderText = "";
                    checkColumn.ReadOnly = false;
                    dataGridView3.Columns.Add(checkColumn);


                    SqlConnection CON = new SqlConnection(DBCON.DBCON);
                    string SQL = "";
                    //if (comboBox1.Text == "제품 명")
                    //{
                    //    //outdate is null
                    //    SQL = "select  no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_demo where   product like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "제품 키")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_demo where   serial like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "반출 처")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_demo where   to_location like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "반입 처")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_demo where   from_location like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "반출 자")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from Product_demo where   out_user like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "매출 처")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from Product_demo where   customer like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    SQL = "select no,product,serial,indate, from_location,outdate,to_location, customer, out_user from Product_demo where  " +
                        "product like  '%" + textBox7.Text + "%' " +
                        "or serial like '%" + textBox7.Text + "%'" +
                        "or to_location like '%" + textBox7.Text + "%'" +
                        "or from_location like '%" + textBox7.Text + "%'" +
                        "or out_user like '%" + textBox7.Text + "%'" +
                        "or customer like '%" + textBox7.Text + "%'" +
                        "order by no desc";

                    SqlDataAdapter ADT = new SqlDataAdapter(SQL, CON);
                    //ADT.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(ADT);
                    //ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= 1 and tempno <= 9999 and outdate is null");
                    //ADT.SelectCommand.Parameters.AddWithValue("@search", " ");
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    ADT.Fill(table);
                    bindingSource3.DataSource = table;

                    dataGridView3.AllowUserToAddRows = false;
                    dataGridView3.DataSource = bindingSource3;
                    dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //dataGridView3.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                    //checkColumn.Width = 20;

                    dataGridView3.Columns["no"].ReadOnly = true;
                    dataGridView3.Columns["no"].HeaderText = "번호";
                    dataGridView3.Columns["product"].ReadOnly = true;
                    dataGridView3.Columns["product"].HeaderText = "상품";
                    dataGridView3.Columns["serial"].ReadOnly = true;
                    dataGridView3.Columns["serial"].HeaderText = "시리얼";
                    dataGridView3.Columns["indate"].ReadOnly = true;
                    dataGridView3.Columns["indate"].HeaderText = "반입 일";
                    dataGridView3.Columns["from_location"].ReadOnly = true;
                    dataGridView3.Columns["from_location"].HeaderText = "반입 처";
                    dataGridView3.Columns["outdate"].ReadOnly = true;
                    dataGridView3.Columns["outdate"].HeaderText = "반출 일";
                    dataGridView3.Columns["to_location"].ReadOnly = true;
                    dataGridView3.Columns["to_location"].HeaderText = "반출 처";
                    dataGridView3.Columns["customer"].ReadOnly = true;
                    dataGridView3.Columns["customer"].HeaderText = "매출 처";
                    dataGridView3.Columns["out_user"].ReadOnly = true;
                    dataGridView3.Columns["out_user"].HeaderText = "반출 자";

                    dataGridView3.Columns["no"].Visible = false;


                    groupBox5.Text = "재고 목록 : " + dataGridView3.RowCount.ToString();

                    foreach (DataGridViewRow Myrow in dataGridView3.Rows)
                    {            //Here 2 cell is target value and 1 cell is Volume
                                 //MessageBox.Show(Myrow.Cells[4].Value.ToString());
                        if (Myrow.Cells[7].Value.ToString() == "")// Or your condition 
                        {

                            //Myrow.DefaultCellStyle.BackColor = Color.Red;
                            //Myrow.DefaultCellStyle.BackColor = Color.LightGreen;

                        }
                        else
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.Khaki;


                        }
                    }
                }
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabpage4"])//your specific tabname
                {
                    dataGridView4.Columns.Clear();
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    checkColumn.Name = "X";
                    checkColumn.HeaderText = "";
                    checkColumn.ReadOnly = false;
                    dataGridView4.Columns.Add(checkColumn);


                    SqlConnection CON = new SqlConnection(DBCON.DBCON);
                    string SQL = "";
                    //if (comboBox1.Text == "제품 명")
                    //{
                    //    //outdate is null
                    //    SQL = "select  no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_rma where   product like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "제품 키")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_rma where   serial like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "반출 처")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_rma where   to_location like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "반입 처")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_rma where   from_location like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "반출 자")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from Product_rma where   out_user like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    //if (comboBox1.Text == "매출 처")
                    //{
                    //    //outdate is null
                    //    SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from Product_rma where   customer like  '%" + textBox7.Text + "%' order by no desc";
                    //}
                    SQL = "select no,product,serial,indate, from_purchaser,from_location,outdate,to_location, customer, out_user from Product_rma where  " +
                        "product like  '%" + textBox7.Text + "%' " +
                        "or serial like '%" + textBox7.Text + "%'" +
                        "or to_location like '%" + textBox7.Text + "%'" +
                        "or from_location like '%" + textBox7.Text + "%'" +
                        "or out_user like '%" + textBox7.Text + "%'" +
                        "or customer like '%" + textBox7.Text + "%'" +
                        "order by no desc";

                    SqlDataAdapter ADT = new SqlDataAdapter(SQL, CON);
                    //ADT.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(ADT);
                    //ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= 1 and tempno <= 9999 and outdate is null");
                    //ADT.SelectCommand.Parameters.AddWithValue("@search", " ");
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    ADT.Fill(table);
                    bindingSource4.DataSource = table;

                    dataGridView4.AllowUserToAddRows = false;
                    dataGridView4.DataSource = bindingSource4;
                    dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //dataGridView3.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                    //checkColumn.Width = 20;

                    dataGridView4.Columns["no"].ReadOnly = true;
                    dataGridView4.Columns["no"].HeaderText = "번호";
                    dataGridView4.Columns["product"].ReadOnly = true;
                    dataGridView4.Columns["product"].HeaderText = "상품";
                    dataGridView4.Columns["serial"].ReadOnly = true;
                    dataGridView4.Columns["serial"].HeaderText = "시리얼";
                    dataGridView4.Columns["indate"].ReadOnly = true;
                    dataGridView4.Columns["indate"].HeaderText = "반입 일";
                    dataGridView4.Columns["from_location"].ReadOnly = true;
                    dataGridView4.Columns["from_location"].HeaderText = "반입 처";
                    dataGridView4.Columns["outdate"].ReadOnly = true;
                    dataGridView4.Columns["outdate"].HeaderText = "반출 일";
                    dataGridView4.Columns["to_location"].ReadOnly = true;
                    dataGridView4.Columns["to_location"].HeaderText = "반출 처";
                    dataGridView4.Columns["to_location"].ReadOnly = true;
                    dataGridView4.Columns["to_location"].HeaderText = "매출 처";
                    dataGridView4.Columns["out_user"].ReadOnly = true;
                    dataGridView4.Columns["out_user"].HeaderText = "반출 자";

                    dataGridView4.Columns["no"].Visible = false;


                    groupBox5.Text = "재고 목록 : " + dataGridView4.RowCount.ToString();

                    foreach (DataGridViewRow Myrow in dataGridView4.Rows)
                    {            //Here 2 cell is target value and 1 cell is Volume
                                 //MessageBox.Show(Myrow.Cells[4].Value.ToString());
                        if (Myrow.Cells[7].Value.ToString() == "")// Or your condition 
                        {

                            //Myrow.DefaultCellStyle.BackColor = Color.Red;
                            //Myrow.DefaultCellStyle.BackColor = Color.LightGreen;

                        }
                        else
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.Khaki;


                        }
                    }
                }

            }
            catch
            {

            }

        }



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabpage1"])//your specific tabname
                {
                    dataGridView1.Columns.Clear();
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    textBox4.Text = "";
                    checkColumn.Name = "X";
                    //checkColumn.HeaderText = "";
                    checkColumn.ReadOnly = false;
                    dataGridView1.Columns.Add(checkColumn);


                    SqlConnection CON = new SqlConnection(DBCON.DBCON);
                    string SQL = "";
                    if (comboBox1.Text == "제품 명")
                    {
                        //outdate is null
                        SQL = "select  no,product,serial,indate, from_purchaser,from_location,outdate,to_location, customer, out_user from Product_sell where   product like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "제품 키")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate, from_purchaser,from_location,outdate,to_location, customer, out_user from Product_sell where   serial like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "반출 처")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate, from_purchaser,from_location,outdate,to_location, customer, out_user from Product_sell where   to_location like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "반입 처")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate, from_purchaser,from_location,outdate,to_location, customer, out_user  from Product_sell where   from_location like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "반출 자")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate, from_purchaser,from_location,outdate,to_location, customer, out_user  from Product_sell where   out_user like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "매출 처")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate, from_purchaser,from_location,outdate,to_location, customer, out_user  from Product_sell where   customer like  '%" + textBox7.Text + "%' order by no desc";
                    }

                    SqlDataAdapter ADT = new SqlDataAdapter(SQL, CON);
                    //ADT.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(ADT);
                    //ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= 1 and tempno <= 9999 and outdate is null");
                    //ADT.SelectCommand.Parameters.AddWithValue("@search", " ");
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    ADT.Fill(table);
                    bindingSource1.DataSource = table;

                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.DataSource = bindingSource1;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                    ////checkColumn.Width = 20;

                    dataGridView1.Columns["no"].ReadOnly = true;
                    dataGridView1.Columns["no"].HeaderText = "번호";
                    dataGridView1.Columns["product"].ReadOnly = true;
                    dataGridView1.Columns["product"].HeaderText = "상품";
                    dataGridView1.Columns["serial"].ReadOnly = true;
                    dataGridView1.Columns["serial"].HeaderText = "시리얼";
                    dataGridView1.Columns["indate"].ReadOnly = true;
                    dataGridView1.Columns["indate"].HeaderText = "반입 일";
                    dataGridView1.Columns["from_purchaser"].ReadOnly = true;
                    dataGridView1.Columns["from_purchaser"].HeaderText = "매입 처";
                    dataGridView1.Columns["from_location"].ReadOnly = true;
                    dataGridView1.Columns["from_location"].HeaderText = "반입 처";
                    dataGridView1.Columns["outdate"].ReadOnly = true;
                    dataGridView1.Columns["outdate"].HeaderText = "반출 일";
                    dataGridView1.Columns["to_location"].ReadOnly = true;
                    dataGridView1.Columns["to_location"].HeaderText = "반출 처";
                    dataGridView1.Columns["customer"].ReadOnly = true;
                    dataGridView1.Columns["customer"].HeaderText = "매출 처";
                    dataGridView1.Columns["out_user"].ReadOnly = true;
                    dataGridView1.Columns["out_user"].HeaderText = "반출 자";

                    dataGridView1.Columns["no"].Visible = false;


                    groupBox5.Text = "재고 목록 : " + dataGridView1.RowCount.ToString();

                    foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                    {            //Here 2 cell is target value and 1 cell is Volume
                                 //MessageBox.Show(Myrow.Cells[4].Value.ToString());
                        if (Myrow.Cells[7].Value.ToString() == "")// Or your condition 
                        {

                            //Myrow.DefaultCellStyle.BackColor = Color.Red;
                            //Myrow.DefaultCellStyle.BackColor = Color.LightGreen;

                        }
                        else
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.Khaki;


                        }
                    }
                }
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabpage2"])//your specific tabname
                {
                    dataGridView2.Columns.Clear();
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    textBox4.Text = "";
                    checkColumn.Name = "X";
                    checkColumn.HeaderText = "";
                    checkColumn.ReadOnly = false;
                    dataGridView2.Columns.Add(checkColumn);


                    SqlConnection CON = new SqlConnection(DBCON.DBCON);
                    string SQL = "";
                    if (comboBox1.Text == "제품 명")
                    {
                        //outdate is null
                        SQL = "select  no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_mine where   product like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "제품 키")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_mine where   serial like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "반출 처")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_mine where   to_location like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "반입 처")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_mine where   from_location like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "반출 자")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from Product_mine where   out_user like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "매출 처")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from Product_mine where   customer like  '%" + textBox7.Text + "%' order by no desc";
                    }

                    SqlDataAdapter ADT = new SqlDataAdapter(SQL, CON);
                    //ADT.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(ADT);
                    //ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= 1 and tempno <= 9999 and outdate is null");
                    //ADT.SelectCommand.Parameters.AddWithValue("@search", " ");
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    ADT.Fill(table);
                    bindingSource2.DataSource = table;

                    dataGridView2.AllowUserToAddRows = false;
                    dataGridView2.DataSource = bindingSource2;
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                    ////checkColumn.Width = 20;

                    dataGridView2.Columns["no"].ReadOnly = true;
                    dataGridView2.Columns["no"].HeaderText = "번호";
                    dataGridView2.Columns["product"].ReadOnly = true;
                    dataGridView2.Columns["product"].HeaderText = "상품";
                    dataGridView2.Columns["serial"].ReadOnly = true;
                    dataGridView2.Columns["serial"].HeaderText = "시리얼";
                    dataGridView2.Columns["indate"].ReadOnly = true;
                    dataGridView2.Columns["indate"].HeaderText = "반입 일";
                    dataGridView2.Columns["from_location"].ReadOnly = true;
                    dataGridView2.Columns["from_location"].HeaderText = "반입 처";
                    dataGridView2.Columns["outdate"].ReadOnly = true;
                    dataGridView2.Columns["outdate"].HeaderText = "반출 일";
                    dataGridView2.Columns["to_location"].ReadOnly = true;
                    dataGridView2.Columns["to_location"].HeaderText = "반출 처";
                    dataGridView2.Columns["customer"].ReadOnly = true;
                    dataGridView2.Columns["customer"].HeaderText = "매출 처";
                    dataGridView2.Columns["out_user"].ReadOnly = true;
                    dataGridView2.Columns["out_user"].HeaderText = "반출 자";

                    dataGridView2.Columns["no"].Visible = false;


                    groupBox5.Text = "재고 목록 : " + dataGridView2.RowCount.ToString();

                    foreach (DataGridViewRow Myrow in dataGridView2.Rows)
                    {            //Here 2 cell is target value and 1 cell is Volume
                                 //MessageBox.Show(Myrow.Cells[4].Value.ToString());
                        if (Myrow.Cells[7].Value.ToString() == "")// Or your condition 
                        {

                            //Myrow.DefaultCellStyle.BackColor = Color.Red;
                            //Myrow.DefaultCellStyle.BackColor = Color.LightGreen;

                        }
                        else
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.Khaki;


                        }
                    }
                }
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabpage3"])//your specific tabname
                {
                    dataGridView3.Columns.Clear();
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    textBox4.Text = "";
                    checkColumn.Name = "X";
                    checkColumn.HeaderText = "";
                    checkColumn.ReadOnly = false;
                    dataGridView3.Columns.Add(checkColumn);


                    SqlConnection CON = new SqlConnection(DBCON.DBCON);
                    string SQL = "";
                    if (comboBox1.Text == "제품 명")
                    {
                        //outdate is null
                        SQL = "select  no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_demo where   product like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "제품 키")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_demo where   serial like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "반출 처")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_demo where   to_location like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "반입 처")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_demo where   from_location like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "반출 자")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from Product_demo where   out_user like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "매출 처")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from Product_demo where   customer like  '%" + textBox7.Text + "%' order by no desc";
                    }

                    SqlDataAdapter ADT = new SqlDataAdapter(SQL, CON);
                    //ADT.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(ADT);
                    //ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= 1 and tempno <= 9999 and outdate is null");
                    //ADT.SelectCommand.Parameters.AddWithValue("@search", " ");
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    ADT.Fill(table);
                    bindingSource3.DataSource = table;

                    dataGridView3.AllowUserToAddRows = false;
                    dataGridView3.DataSource = bindingSource3;
                    dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //dataGridView3.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                    ////checkColumn.Width = 20;

                    dataGridView3.Columns["no"].ReadOnly = true;
                    dataGridView3.Columns["no"].HeaderText = "번호";
                    dataGridView3.Columns["product"].ReadOnly = true;
                    dataGridView3.Columns["product"].HeaderText = "상품";
                    dataGridView3.Columns["serial"].ReadOnly = true;
                    dataGridView3.Columns["serial"].HeaderText = "시리얼";
                    dataGridView3.Columns["indate"].ReadOnly = true;
                    dataGridView3.Columns["indate"].HeaderText = "반입 일";
                    dataGridView3.Columns["from_location"].ReadOnly = true;
                    dataGridView3.Columns["from_location"].HeaderText = "반입 처";
                    dataGridView3.Columns["outdate"].ReadOnly = true;
                    dataGridView3.Columns["outdate"].HeaderText = "반출 일";
                    dataGridView3.Columns["to_location"].ReadOnly = true;
                    dataGridView3.Columns["to_location"].HeaderText = "반출 처";
                    dataGridView3.Columns["customer"].ReadOnly = true;
                    dataGridView3.Columns["customer"].HeaderText = "매출 처";
                    dataGridView3.Columns["out_user"].ReadOnly = true;
                    dataGridView3.Columns["out_user"].HeaderText = "반출 자";

                    dataGridView3.Columns["no"].Visible = false;


                    groupBox5.Text = "재고 목록 : " + dataGridView3.RowCount.ToString();

                    foreach (DataGridViewRow Myrow in dataGridView3.Rows)
                    {            //Here 2 cell is target value and 1 cell is Volume
                                 //MessageBox.Show(Myrow.Cells[4].Value.ToString());
                        if (Myrow.Cells[7].Value.ToString() == "")// Or your condition 
                        {

                            //Myrow.DefaultCellStyle.BackColor = Color.Red;
                            //Myrow.DefaultCellStyle.BackColor = Color.LightGreen;

                        }
                        else
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.Khaki;


                        }
                    }
                }
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabpage4"])//your specific tabname
                {
                    dataGridView4.Columns.Clear();
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    textBox4.Text = "";
                    checkColumn.Name = "X";
                    checkColumn.HeaderText = "";
                    checkColumn.ReadOnly = false;
                    dataGridView4.Columns.Add(checkColumn);


                    SqlConnection CON = new SqlConnection(DBCON.DBCON);
                    string SQL = "";
                    if (comboBox1.Text == "제품 명")
                    {
                        //outdate is null
                        SQL = "select  no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_rma where   product like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "제품 키")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_rma where   serial like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "반출 처")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_rma where   to_location like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "반입 처")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from product_rma where   from_location like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "반출 자")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from Product_rma where   out_user like  '%" + textBox7.Text + "%' order by no desc";
                    }
                    if (comboBox1.Text == "매출 처")
                    {
                        //outdate is null
                        SQL = "select no,product,serial,indate,from_location,outdate,to_location, customer, out_user from Product_rma where   customer like  '%" + textBox7.Text + "%' order by no desc";
                    }

                    SqlDataAdapter ADT = new SqlDataAdapter(SQL, CON);
                    //ADT.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(ADT);
                    //ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= 1 and tempno <= 9999 and outdate is null");
                    //ADT.SelectCommand.Parameters.AddWithValue("@search", " ");
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    ADT.Fill(table);
                    bindingSource4.DataSource = table;

                    dataGridView4.AllowUserToAddRows = false;
                    dataGridView4.DataSource = bindingSource4;
                    dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //dataGridView3.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                    ////checkColumn.Width = 20;

                    dataGridView4.Columns["no"].ReadOnly = true;
                    dataGridView4.Columns["no"].HeaderText = "번호";
                    dataGridView4.Columns["product"].ReadOnly = true;
                    dataGridView4.Columns["product"].HeaderText = "상품";
                    dataGridView4.Columns["serial"].ReadOnly = true;
                    dataGridView4.Columns["serial"].HeaderText = "시리얼";
                    dataGridView4.Columns["indate"].ReadOnly = true;
                    dataGridView4.Columns["indate"].HeaderText = "반입 일";
                    dataGridView4.Columns["from_location"].ReadOnly = true;
                    dataGridView4.Columns["from_location"].HeaderText = "반입 처";
                    dataGridView4.Columns["outdate"].ReadOnly = true;
                    dataGridView4.Columns["outdate"].HeaderText = "반출 일";
                    dataGridView4.Columns["to_location"].ReadOnly = true;
                    dataGridView4.Columns["to_location"].HeaderText = "반출 처";
                    dataGridView4.Columns["customer"].ReadOnly = true;
                    dataGridView4.Columns["customer"].HeaderText = "매출 처";
                    dataGridView4.Columns["out_user"].ReadOnly = true;
                    dataGridView4.Columns["out_user"].HeaderText = "반출 자";

                    dataGridView4.Columns["no"].Visible = false;


                    groupBox5.Text = "재고 목록 : " + dataGridView4.RowCount.ToString();

                    foreach (DataGridViewRow Myrow in dataGridView4.Rows)
                    {            //Here 2 cell is target value and 1 cell is Volume
                                 //MessageBox.Show(Myrow.Cells[4].Value.ToString());
                        if (Myrow.Cells[7].Value.ToString() == "")// Or your condition 
                        {

                            //Myrow.DefaultCellStyle.BackColor = Color.Red;
                            //Myrow.DefaultCellStyle.BackColor = Color.LightGreen;

                        }
                        else
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.Khaki;


                        }
                    }
                }

            }
            catch
            {

            }
        }
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dataGridView1.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                         //MessageBox.Show(Myrow.Cells[4].Value.ToString());
                if (Myrow.Cells[7].Value.ToString() == "")// Or your condition 
                {

                    //Myrow.DefaultCellStyle.BackColor = Color.Red;
                    //Myrow.DefaultCellStyle.BackColor = Color.LightGreen;

                }
                else
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Khaki;

                }
            }
        }

        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dataGridView2.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                         //MessageBox.Show(Myrow.Cells[4].Value.ToString());
                if (Myrow.Cells[7].Value.ToString() == "")// Or your condition 
                {

                    //Myrow.DefaultCellStyle.BackColor = Color.Red;
                    //Myrow.DefaultCellStyle.BackColor = Color.LightGreen;

                }
                else
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Khaki;

                }
            }
        }

        private void dataGridView3_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dataGridView3.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                         //MessageBox.Show(Myrow.Cells[4].Value.ToString());
                if (Myrow.Cells[7].Value.ToString() == "")// Or your condition 
                {

                    //Myrow.DefaultCellStyle.BackColor = Color.Red;
                    //Myrow.DefaultCellStyle.BackColor = Color.LightGreen;

                }
                else
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Khaki;

                }
            }

        }
        private void dataGridView4_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dataGridView4.Rows[dataGridView4.CurrentRow.Index].Cells[0];

            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    foreach (DataGridViewRow row in dataGridView4.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            DataGridViewRow dr = dataGridView4.SelectedRows[0];

                            if (textBox4.Text == "")
                            {
                                textBox4.Text = dr.Cells[1].Value.ToString() + ";";
                            }
                            else
                            {
                                textBox4.Text = textBox4.Text.Replace(dr.Cells[1].Value.ToString() + ";", "");
                            }
                        }
                    }
                    break;
                case "False":
                    ch1.Value = true;
                    foreach (DataGridViewRow row in dataGridView4.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            DataGridViewRow dr = dataGridView4.SelectedRows[0];

                            if (textBox4.Text == "")
                            {
                                textBox4.Text = dr.Cells[1].Value.ToString() + ";";
                            }
                            else
                            {
                                textBox4.Text += dr.Cells[1].Value.ToString() + ";";
                            }
                        }
                    }
                    break;
            }
            //MessageBox.Show(ch1.Value.ToString());
        }

        private void dataGridView4_ColumnHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dataGridView4.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                         //MessageBox.Show(Myrow.Cells[4].Value.ToString());
                if (Myrow.Cells[7].Value.ToString() == "")// Or your condition 
                {

                    //Myrow.DefaultCellStyle.BackColor = Color.Red;
                    //Myrow.DefaultCellStyle.BackColor = Color.LightGreen;

                }
                else
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Khaki;

                }
            }
        }
        private void gvSheetListCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tabControl1.TabPages["tabpage1"])//your specific tabname
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (((CheckBox)sender).Checked == true)
                    {
                        r.Cells["X"].Value = ((CheckBox)sender).Checked;
                        textBox4.Text += r.Cells[1].Value.ToString() + ";";
                    }
                    else if (((CheckBox)sender).Checked != true)
                    {
                        r.Cells["X"].Value = ((CheckBox)sender).Checked;
                        textBox4.Text = "";
                    }
                }

                try
                {
                    int iSelRow = 0;
                    iSelRow = dataGridView1.SelectedCells[0].RowIndex;
                    if (iSelRow == dataGridView1.Rows.Count - 1) return;
                    dataGridView1.CurrentCell = dataGridView1.Rows[iSelRow + 1].Cells[0];
                    foreach (DataGridViewCell c in this.dataGridView1.SelectedCells)
                    {
                        c.Selected = false;
                    }
                }
                catch (Exception)
                {

                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabpage2"])//your specific tabname
            {
                foreach (DataGridViewRow r in dataGridView2.Rows)
                {
                    if (((CheckBox)sender).Checked == true)
                    {
                        r.Cells["X"].Value = ((CheckBox)sender).Checked;
                        textBox4.Text += r.Cells[1].Value.ToString() + ";";
                    }
                    else if (((CheckBox)sender).Checked != true)
                    {
                        r.Cells["X"].Value = ((CheckBox)sender).Checked;
                        textBox4.Text = "";
                    }
                }

                try
                {
                    int iSelRow = 0;
                    iSelRow = dataGridView2.SelectedCells[0].RowIndex;
                    if (iSelRow == dataGridView2.Rows.Count - 1) return;
                    dataGridView2.CurrentCell = dataGridView2.Rows[iSelRow + 1].Cells[0];
                    foreach (DataGridViewCell c in this.dataGridView2.SelectedCells)
                    {
                        c.Selected = false;
                    }
                }
                catch (Exception)
                {

                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabpage3"])//your specific tabname
            {
                foreach (DataGridViewRow r in dataGridView3.Rows)
                {
                    if (((CheckBox)sender).Checked == true)
                    {
                        r.Cells["X"].Value = ((CheckBox)sender).Checked;
                        textBox4.Text += r.Cells[1].Value.ToString() + ";";
                    }
                    else if (((CheckBox)sender).Checked != true)
                    {
                        r.Cells["X"].Value = ((CheckBox)sender).Checked;
                        textBox4.Text = "";
                    }
                }
                try
                {
                    int iSelRow = 0;
                    iSelRow = dataGridView3.SelectedCells[0].RowIndex;
                    if (iSelRow == dataGridView3.Rows.Count - 1) return;
                    dataGridView3.CurrentCell = dataGridView3.Rows[iSelRow + 1].Cells[0];
                }
                catch (Exception)
                {

                }

                foreach (DataGridViewCell c in this.dataGridView3.SelectedCells)
                {
                    c.Selected = false;
                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabpage4"])//your specific tabname
            {
                foreach (DataGridViewRow r in dataGridView4.Rows)
                {
                    if (((CheckBox)sender).Checked == true)
                    {
                        r.Cells["X"].Value = ((CheckBox)sender).Checked;
                        textBox4.Text += r.Cells[1].Value.ToString() + ";";
                    }
                    else if (((CheckBox)sender).Checked != true)
                    {
                        r.Cells["X"].Value = ((CheckBox)sender).Checked;
                        textBox4.Text = "";
                    }
                }
                try
                {
                    int iSelRow = 0;
                    iSelRow = dataGridView4.SelectedCells[0].RowIndex;
                    if (iSelRow == dataGridView4.Rows.Count - 1) return;
                    dataGridView4.CurrentCell = dataGridView4.Rows[iSelRow + 1].Cells[0];
                    foreach (DataGridViewCell c in this.dataGridView4.SelectedCells)
                    {
                        c.Selected = false;
                    }
                }
                catch (Exception)
                {

                }
            }
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex == -1)
            {
                e.PaintBackground(e.ClipBounds, false);
                Point pt = e.CellBounds.Location;  // where you want the bitmap in the cell
                int nChkBoxWidth = 15; int nChkBoxHeight = 15;
                int offsetx = 0;
                int offsety = 0;
                if (offsetx != null)
                {

                }
                else
                {
                    offsetx = (e.CellBounds.Width - nChkBoxWidth) / 2;
                    offsety = (e.CellBounds.Height - nChkBoxHeight) / 2;
                }
                pt.X += 16; pt.Y += 3;

                CheckBox cb = new CheckBox();
                cb.Size = new Size(nChkBoxWidth, nChkBoxHeight);
                cb.Location = pt;
                cb.CheckedChanged += new EventHandler(gvSheetListCheckBox_CheckedChanged);
                ((DataGridView)sender).Controls.Remove(cb);
                ((DataGridView)sender).Controls.Add(cb);
                e.Handled = true;
            }
        }


        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex == -1)
            {
                e.PaintBackground(e.ClipBounds, false);
                Point pt = e.CellBounds.Location;  // where you want the bitmap in the cell
                int nChkBoxWidth = 15; int nChkBoxHeight = 15; int offsetx = (e.CellBounds.Width - nChkBoxWidth) / 2; int offsety = (e.CellBounds.Height - nChkBoxHeight) / 2;
                pt.X += 33; pt.Y += 3;
                CheckBox cb = new CheckBox();
                cb.Size = new Size(nChkBoxWidth, nChkBoxHeight);
                cb.Location = pt;
                cb.CheckedChanged += new EventHandler(gvSheetListCheckBox_CheckedChanged);
                ((DataGridView)sender).Controls.Remove(cb);
                ((DataGridView)sender).Controls.Add(cb);

                e.Handled = true;
            }
        }



        private void dataGridView3_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex == -1)
            {
                e.PaintBackground(e.ClipBounds, false);
                Point pt = e.CellBounds.Location;  // where you want the bitmap in the cell
                int nChkBoxWidth = 15; int nChkBoxHeight = 15; int offsetx = (e.CellBounds.Width - nChkBoxWidth) / 2; int offsety = (e.CellBounds.Height - nChkBoxHeight) / 2;
                pt.X += 33; pt.Y += 3;
                CheckBox cb = new CheckBox();
                cb.Size = new Size(nChkBoxWidth, nChkBoxHeight);
                cb.Location = pt;
                cb.CheckedChanged += new EventHandler(gvSheetListCheckBox_CheckedChanged);
                ((DataGridView)sender).Controls.Remove(cb);
                ((DataGridView)sender).Controls.Add(cb);

                e.Handled = true;
            }
        }

        private void dataGridView4_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex == -1)
            {
                e.PaintBackground(e.ClipBounds, false);
                Point pt = e.CellBounds.Location;  // where you want the bitmap in the cell
                int nChkBoxWidth = 15; int nChkBoxHeight = 15; int offsetx = (e.CellBounds.Width - nChkBoxWidth) / 2; int offsety = (e.CellBounds.Height - nChkBoxHeight) / 2;
                pt.X += 33; pt.Y += 3;
                CheckBox cb = new CheckBox();
                cb.Size = new Size(nChkBoxWidth, nChkBoxHeight);
                cb.Location = pt;
                cb.CheckedChanged += new EventHandler(gvSheetListCheckBox_CheckedChanged);
                ((DataGridView)sender).Controls.Remove(cb);
                ((DataGridView)sender).Controls.Add(cb);

                e.Handled = true;
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.TodayDate = monthCalendar1.SelectionStart;
            textBox6.Text = monthCalendar1.SelectionStart.ToShortDateString() + " " + DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
