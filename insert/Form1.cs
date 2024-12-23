﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace insert
{

    public partial class Form1 : Form
    {
        DBCON.Class1 DBCON = new DBCON.Class1();
        public Form1()
        {
            InitializeComponent();

            //this.monthCalendar1.ShowToday = false;

            //comboBox1.Items.Add("제품 명");


        }

        private void Form1_Load(object sender, EventArgs e)
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
            //checkColumn.Name = "X";
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
        private void button1_Click(object sender, EventArgs e)
        {
            string txt1 = "";
            foreach (Control c in groupBox1.Controls)
            {
                if (c.Text != "")
                {
                    //MessageBox.Show(c.Name);
                    txt1 += c.Text + ",";
                }

            }
            string txt2 = "";
            foreach (Control c in groupBox2.Controls)
            {
                if (c.Text != "")
                {
                    //MessageBox.Show(c.Text);
                    txt2 += c.Text + ",";
                }

            }
            try
            {
                if (textBox33.Text == "")
                {
                    MessageBox.Show("입고처를 입력해주세요");
                }
                else if (textBox32.Text == "")
                {
                    MessageBox.Show("상품명을 입력해주세요");
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("상품명을 입력해주세요");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("날짜를 골라주세요");
                }
                else
                {
                    string[] gu1 = textBox1.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    string[] gu2 = textBox2.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    //string[] gu3 = textBox32.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < gu2.Length; i++)
                    {
                        //MessageBox.Show(gu3[i].ToString());   
                        //MessageBox.Show(gu1[0].ToString() + " " + gu2[i].ToString());
                        SqlConnection CON = new SqlConnection(DBCON.DBCON);
                        CON.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = CON;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "insert into Product_sell(product,serial,indate,qty,from_location, from_purchaser) " +
                            "select @product,@serial,@date,'1',@from_location, @from_purchaser";
                        cmd.Parameters.Add("@product", SqlDbType.NVarChar, 50).Value = gu1[0].ToString();
                        cmd.Parameters.Add("@serial", SqlDbType.NVarChar, 50).Value = gu2[i].ToString();
                        cmd.Parameters.Add("@date", SqlDbType.NVarChar, 50).Value = monthCalendar1.SelectionStart.ToShortDateString() + " " + DateTime.Now.ToString("HH:mm:ss");
                        cmd.Parameters.Add("@from_location", SqlDbType.NVarChar, 4000).Value = textBox33.Text;
                        cmd.Parameters.Add("@from_purchaser", SqlDbType.NVarChar, 4000).Value = textBox32.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        cmd = null;
                        CON.Close();
                        CON.Dispose();
                    }

                    MessageBox.Show("등록이 완료되었습니다.");
                    foreach (Control c in groupBox1.Controls)
                    {
                        if (c.Text != "")
                        {
                            c.Text = "";
                        }

                    }

                    foreach (Control c in groupBox2.Controls)
                    {
                        if (c.Text != "")
                        {
                            c.Text = "";
                        }

                    }

                    textBox33.Text = "";
                    textBox32.Text = "";
                    textBox3.Text = "";
                    textBox1.Text = "";
                }

            }
            catch (Exception)
            {
                //MessageBox.Show(E.Message);
            }


            Form1_Load(this, null);


        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.TodayDate = monthCalendar1.SelectionStart;
            textBox3.Text = monthCalendar1.SelectionStart.ToShortDateString() + " " + DateTime.Now.ToString("HH:mm:ss");
        }



        private void button3_Click(object sender, EventArgs e)
        {
            string txt1 = "";
            foreach (Control c in groupBox1.Controls)
            {
                if (c.Text != "")
                {
                    //MessageBox.Show(c.Name);
                    txt1 += c.Text + ",";
                }

            }
            string txt2 = "";
            foreach (Control c in groupBox2.Controls)
            {
                if (c.Text != "")
                {
                    //MessageBox.Show(c.Text);
                    txt2 += c.Text + ",";
                }

            }
            try
            {
                if (textBox33.Text == "")
                {
                    MessageBox.Show("입고처를 입력해주세요");
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("상품명을 입력해주세요");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("날짜를 골라주세요");
                }
                else
                {
                    string[] gu1 = textBox1.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    string[] gu2 = textBox2.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    //string[] gu3 = textBox32.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < gu2.Length; i++)
                    {
                        //MessageBox.Show(gu3[i].ToString());   
                        //MessageBox.Show(gu1[0].ToString() + " " + gu2[i].ToString());
                        SqlConnection CON = new SqlConnection(DBCON.DBCON);
                        CON.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = CON;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "insert into Product_mine(product,serial,indate,qty,from_location) " +
                            "select @product,@serial,@date,'1',@from_location";
                        cmd.Parameters.Add("@product", SqlDbType.NVarChar, 50).Value = gu1[0].ToString();
                        cmd.Parameters.Add("@serial", SqlDbType.NVarChar, 50).Value = gu2[i].ToString();
                        cmd.Parameters.Add("@date", SqlDbType.NVarChar, 50).Value = monthCalendar1.SelectionStart.ToShortDateString() + " " + DateTime.Now.ToString("HH:mm:ss");
                        cmd.Parameters.Add("@from_location", SqlDbType.NVarChar, 4000).Value = textBox33.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        cmd = null;
                        CON.Close();
                        CON.Dispose();
                    }

                    MessageBox.Show("등록이 완료되었습니다.");
                    foreach (Control c in groupBox1.Controls)
                    {
                        if (c.Text != "")
                        {
                            c.Text = "";
                        }

                    }

                    foreach (Control c in groupBox2.Controls)
                    {
                        if (c.Text != "")
                        {
                            c.Text = "";
                        }

                    }

                    textBox33.Text = "";
                    textBox3.Text = "";
                }

            }
            catch (Exception)
            {
                //MessageBox.Show(E.Message);
            }


            Form1_Load(this, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string txt1 = "";
            foreach (Control c in groupBox1.Controls)
            {
                if (c.Text != "")
                {
                    //MessageBox.Show(c.Name);
                    txt1 += c.Text + ",";
                }

            }
            string txt2 = "";
            foreach (Control c in groupBox2.Controls)
            {
                if (c.Text != "")
                {
                    //MessageBox.Show(c.Text);
                    txt2 += c.Text + ",";
                }

            }
            try
            {
                if (textBox33.Text == "")
                {
                    MessageBox.Show("입고처를 입력해주세요");
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("상품명을 입력해주세요");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("날짜를 골라주세요");
                }
                else
                {
                    string[] gu1 = textBox1.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    string[] gu2 = textBox2.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    //string[] gu3 = textBox32.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < gu2.Length; i++)
                    {
                        //MessageBox.Show(gu3[i].ToString());   
                        //MessageBox.Show(gu1[0].ToString() + " " + gu2[i].ToString());
                        SqlConnection CON = new SqlConnection(DBCON.DBCON);
                        CON.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = CON;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "insert into Product_demo(product,serial,indate,qty,from_location) " +
                            "select @product,@serial,@date,'1',@from_location";
                        cmd.Parameters.Add("@product", SqlDbType.NVarChar, 50).Value = gu1[0].ToString();
                        cmd.Parameters.Add("@serial", SqlDbType.NVarChar, 50).Value = gu2[i].ToString();
                        cmd.Parameters.Add("@date", SqlDbType.NVarChar, 50).Value = monthCalendar1.SelectionStart.ToShortDateString() + " " + DateTime.Now.ToString("HH:mm:ss");
                        cmd.Parameters.Add("@from_location", SqlDbType.NVarChar, 4000).Value = textBox33.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        cmd = null;
                        CON.Close();
                        CON.Dispose();
                    }

                    MessageBox.Show("등록이 완료되었습니다.");
                    foreach (Control c in groupBox1.Controls)
                    {
                        if (c.Text != "")
                        {
                            c.Text = "";
                        }

                    }

                    foreach (Control c in groupBox2.Controls)
                    {
                        if (c.Text != "")
                        {
                            c.Text = "";
                        }

                    }

                    textBox33.Text = "";
                    textBox3.Text = "";
                }

            }
            catch (Exception)
            {
                //MessageBox.Show(E.Message);
            }


            Form1_Load(this, null);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {




        }





        private void button5_Click(object sender, EventArgs e)
        {
            string txt1 = "";
            foreach (Control c in groupBox1.Controls)
            {
                if (c.Text != "")
                {
                    //MessageBox.Show(c.Name);
                    txt1 += c.Text + ",";
                }

            }
            string txt2 = "";
            foreach (Control c in groupBox2.Controls)
            {
                if (c.Text != "")
                {
                    //MessageBox.Show(c.Text);
                    txt2 += c.Text + ",";
                }

            }
            try
            {
                if (textBox33.Text == "")
                {
                    MessageBox.Show("입고처를 입력해주세요");
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("상품명을 입력해주세요");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("날짜를 골라주세요");
                }
                else
                {
                    string[] gu1 = textBox1.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    string[] gu2 = textBox2.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    //string[] gu3 = textBox32.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < gu2.Length; i++)
                    {
                        //MessageBox.Show(gu3[i].ToString());   
                        //MessageBox.Show(gu1[0].ToString() + " " + gu2[i].ToString());
                        SqlConnection CON = new SqlConnection(DBCON.DBCON);
                        CON.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = CON;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "insert into Product_rma(product,serial,indate,qty,from_location) " +
                            "select @product,@serial,@date,'1',@from_location";
                        cmd.Parameters.Add("@product", SqlDbType.NVarChar, 50).Value = gu1[0].ToString();
                        cmd.Parameters.Add("@serial", SqlDbType.NVarChar, 50).Value = gu2[i].ToString();
                        cmd.Parameters.Add("@date", SqlDbType.NVarChar, 50).Value = monthCalendar1.SelectionStart.ToShortDateString() + " " + DateTime.Now.ToString("HH:mm:ss");
                        cmd.Parameters.Add("@from_location", SqlDbType.NVarChar, 4000).Value = textBox33.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        cmd = null;
                        CON.Close();
                        CON.Dispose();
                    }

                    MessageBox.Show("등록이 완료되었습니다.");
                    foreach (Control c in groupBox1.Controls)
                    {
                        if (c.Text != "")
                        {
                            c.Text = "";
                        }

                    }

                    foreach (Control c in groupBox2.Controls)
                    {
                        if (c.Text != "")
                        {
                            c.Text = "";
                        }
                    }
                    textBox33.Text = "";
                    textBox3.Text = "";
                }

            }
            catch (Exception)
            {
                //MessageBox.Show(E.Message);
            }


            Form1_Load(this, null);
        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //foreach (Process process in Process.GetProcesses())
            //{
            //    if (process.ProcessName.StartsWith("insert"))
            //    {
            //        process.Kill();
            //    }
            //}


            //Application.Exit();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
            //                                                    Color.SteelBlue,
            //                                                    Color.WhiteSmoke,
            //                                                   90F))
            //{
            //    e.Graphics.FillRectangle(brush, this.ClientRectangle);
            //}
            //DoubleBuffered = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (e.ColumnIndex == 0 && e.RowIndex == -1)
            //{
            //    e.PaintBackground(e.ClipBounds, false);
            //    Point pt = e.CellBounds.Location;  // where you want the bitmap in the cell
            //    int nChkBoxWidth = 15; int nChkBoxHeight = 15;
            //    int offsetx = 0;
            //    int offsety = 0;
            //    if (offsetx != null)
            //    {

            //    }
            //    else
            //    {
            //        offsetx = (e.CellBounds.Width - nChkBoxWidth) / 2;
            //        offsety = (e.CellBounds.Height - nChkBoxHeight) / 2;
            //    }
            //    pt.X += 16; pt.Y += 3;

            //    CheckBox cb = new CheckBox();
            //    cb.Size = new Size(nChkBoxWidth, nChkBoxHeight);
            //    cb.Location = pt;
            //    cb.CheckedChanged += new EventHandler(gvSheetListCheckBox_CheckedChanged);
            //    ((DataGridView)sender).Controls.Remove(cb);
            //    ((DataGridView)sender).Controls.Add(cb);
            //    e.Handled = true;
            //}
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
                    SQL = "select no,product,serial,indate, from_location,outdate,to_location, customer, out_user from Product_rma where  " +
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
    }
}
