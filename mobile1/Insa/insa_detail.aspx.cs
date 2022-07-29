using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mobile1.Insa
{
    public partial class insa_detail : System.Web.UI.Page
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        DataSet DBSET = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            string number = Request["no"];
            Label3.Text = DateTime.Now.ToString("yyyy년 MM월") + " 인사고과";
            HiddenField2.Value = Request["dropdownlist1"];
            HiddenField3.Value = Request["startdate"];
            

            month_1.Value = TextBox1.Text;
            month_2.Value = TextBox2.Text;
            half_1.Value = TextBox4.Text;
            half_2.Value = TextBox5.Text;
            year_1.Value = TextBox6.Text;
            year_2.Value = TextBox7.Text;

            RadioButtonList1.Enabled = false;


            if (startdate.Text == "")
            {
                startdate.Text = DateTime.Now.ToString("yyyy년MM월");
            }

            if (Request.QueryString["dropdownlist1"] != null)
            {
                //string[] date = Request["startdate"].ToString().Split('-');
                //Label3.Text = date[0]+"년"+ date[1] + "월" + " 인사고과";
                Label3.Text = Request["dropdownlist1"] + " 인사고과";
                startdate.Text = Request["dropdownlist1"];
            }

            if (IsPostBack == true)
            {
                name.Value = Label2.Text;
                dept_name.Value = Label1.Text;
                //DropDownList1.Items.Clear();
            }



            string month = "";
            string SQL1 = "select date, left(CONVERT(varchar(30), GETDATE(),107),2) as month from insa_report where id_no = '"+ Request["no"] +"'  order by date desc";
            SqlDataAdapter ADT1 = new SqlDataAdapter(SQL1, DB);
            DataSet DBSET1 = new DataSet();
            ADT1.Fill(DBSET1, "BD");
            foreach (DataRow row in DBSET1.Tables["BD"].Rows)
            {
                DropDownList1.Items.Add(row["date"].ToString());
                month = row["month"].ToString();
            }

            //분기 돈
            string SQL10 = "";
            if (Request.QueryString["dropdownlist1"] != null)
            {
                SQL10 = "select top 3 * from insa_report where id_no = '" + Request["no"] + "' and date <= '" + Request["dropdownlist1"].ToString() + "' order by date desc";
            }
            else
            {
                 SQL10 = "select top 3 * from insa_report where id_no = '" + Request["no"] + "' and date <= '" + DateTime.Now.ToString("yyyy년MM월") + "' order by date desc";
            }
            
            SqlDataAdapter ADT10 = new SqlDataAdapter(SQL10, DB);
            DataSet DBSET10 = new DataSet();
            ADT10.Fill(DBSET10, "BD");
            int half_1_temp = 0;
            int half_2_temp = 0;
            foreach (DataRow row in DBSET10.Tables["BD"].Rows)
            {
                //달성율
                half_2_temp +=  Convert.ToInt32(row["month_2"]);
                half_1_temp += Convert.ToInt32(row["month_1"]);

            }

            //년 돈
            string SQL11 = "select * from insa_report where id_no = '" + Request["no"] + "' and date like '%" + DateTime.Now.ToString("yyyy") + "%' order by date desc";
            SqlDataAdapter ADT11 = new SqlDataAdapter(SQL11, DB);
            DataSet DBSET11 = new DataSet();
            ADT11.Fill(DBSET11, "BD");
            int year_2_temp = 0;
            int year_1_temp = 0;
            foreach (DataRow row in DBSET11.Tables["BD"].Rows)
            {
                //달성율
                year_2_temp += Convert.ToInt32(row["month_2"]);
                year_1_temp += Convert.ToInt32(row["month_1"]);
            }


            ///있는지 확인
            //string SQL2 = "select * from insa_report where left(CONVERT(varchar(30), create_date, 107),2) = '"+ month +"'";
            string SQL2 = "";
            if (HiddenField2.Value == "")
            {
                //SQL2 = "select * from insa_report where id_no = '" + Request["no"] + "' and left(CONVERT(varchar(30), create_date, 107),2) = '" + DateTime.Now.ToString("MM") + "'";
                SQL2 = "select * from insa_report where id_no = '" + Request["no"] + "' and date = '" + DateTime.Now.ToString("yyyy년MM월") + "'";
                
            }
            else
            {
                 SQL2 = "select * from insa_report where id_no = '" + Request["no"] + "' and date = '" + HiddenField2.Value + "'";
            }
            SqlDataAdapter ADT2 = new SqlDataAdapter(SQL2, DB);
            DataSet DBSET2 = new DataSet();
            ADT2.Fill(DBSET2, "BD");
            foreach (DataRow row in DBSET2.Tables["BD"].Rows)
            {
                RadioButtonList1.SelectedValue = row["Q1"].ToString();
                RadioButtonList2.SelectedValue = row["Q2"].ToString();
                RadioButtonList3.SelectedValue = row["Q3"].ToString();
                RadioButtonList4.SelectedValue = row["Q4"].ToString();
                RadioButtonList5.SelectedValue = row["Q5"].ToString();

                //월
                TextBox1.Text = row["month_1"].ToString();
                TextBox2.Text = row["month_2"].ToString();
                //분기
                //TextBox4.Text = row["half_1"].ToString();
                TextBox4.Text = half_1_temp.ToString();
                TextBox5.Text = half_2_temp.ToString();
                //연
                TextBox6.Text = year_1_temp.ToString();
                TextBox7.Text = year_2_temp.ToString();

                try
                {
                    double a = ((Convert.ToDouble(row["month_2"]) / Convert.ToDouble(row["month_1"])) * 100);
                    //월
                    Label6.Text = "퍼센테이지 : " + ((Convert.ToDouble(row["month_2"]) / Convert.ToDouble(row["month_1"])) * 100).ToString("#.##") + "%";
                    //Label6.Text = a.ToString();
                    //분기
                    Label7.Text = "퍼센테이지 : " + ((Convert.ToDouble(half_2_temp) / Convert.ToDouble(half_1_temp)) * 100).ToString("#.##") + "%";
                    //연
                    Label8.Text = "퍼센테이지 : " + ((Convert.ToDouble(year_2_temp) / Convert.ToDouble(year_1_temp)) * 100).ToString("#.##") + "%";

                    if(a >= 95)
                    {
                        RadioButtonList1.SelectedValue = "20";
                    }
                    else if(a >= 90)
                    {
                        RadioButtonList1.SelectedValue = "18";
                    }
                    else if (a >= 85)
                    {
                        RadioButtonList1.SelectedValue = "16";
                    }
                    else if (a >= 80)
                    {
                        RadioButtonList1.SelectedValue = "14";
                    }
                    else if (a >= 75)
                    {
                        RadioButtonList1.SelectedValue = "12";
                    }
                    else if (a >= 70)
                    {
                        RadioButtonList1.SelectedValue = "10";
                    }
                    else if (a >= 65)
                    {
                        RadioButtonList1.SelectedValue = "8";
                    }
                    else if (a >= 60)
                    {
                        RadioButtonList1.SelectedValue = "6";
                    }
                    else if (a >= 55)
                    {
                        RadioButtonList1.SelectedValue = "4";
                    }
                    else if (a >= 50)
                    {
                        RadioButtonList1.SelectedValue = "2";
                    }
                    else
                    {
                        RadioButtonList1.SelectedValue = "2";
                    }
                }
                catch(Exception ex)
                {
                    Response.Write(ex.ToString());
                    Response.End();
                }
                    
                Label5.Text = row["TOTAL"].ToString();
              
                TextBox3.Text = row["memo"].ToString();

                Label3.Text = row["date"].ToString() + " 인사고과";
            }
        
          



            string SQL3 = "select a.* , b.*, c.* from user_ba a, dept_ba b , duty_ba c where a.no = '" + number + "'" +
            " and a.dept_code = b.dept_code and a.duty = c.duty_code";
            SqlDataAdapter ADT3 = new SqlDataAdapter(SQL3, DB);
            ADT3.Fill(DBSET, "BD");
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
   
                Label2.Text = row["name"].ToString();
                Label1.Text = row["dept_name"].ToString();
                Label4.Text = row["duty_name"].ToString();
            }

            if(Label5.Text == "")
            {
                theDiv.Visible = false;
            }
            
        }
        protected void work(object sender, EventArgs e)
        {
            HiddenField2.Value = DropDownList1.SelectedValue;
        }
        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            HiddenField2.Value = DropDownList1.SelectedValue;
            Response.Redirect("insa_detail.aspx?no=" + Request["no"] + "&dropdownlist1=" + HiddenField2.Value);
        }

        protected void startdate_TextChanged(object sender, EventArgs e)
        {

            string[] date = Request["startdate"].ToString().Split('-');

            HiddenField2.Value = date[0] + "년" + date[1] + "월";
            Response.Redirect("insa_detail.aspx?no=" + Request["no"] + "&dropdownlist1=" + HiddenField2.Value);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../mail/mail_write.aspx?email=" + HiddenField1.Value);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

          
                Response.Redirect("insa_list.aspx");
          
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            try
            {
                double a = ((Convert.ToDouble(month_2.Value) / Convert.ToDouble(month_1.Value)) * 100);
                if (a >= 95)
                {
                    RadioButtonList1.SelectedValue = "20";
                }
                else if (a >= 90)
                {
                    RadioButtonList1.SelectedValue = "18";
                }
                else if (a >= 85)
                {
                    RadioButtonList1.SelectedValue = "16";
                }
                else if (a >= 80)
                {
                    RadioButtonList1.SelectedValue = "14";
                }
                else if (a >= 75)
                {
                    RadioButtonList1.SelectedValue = "12";
                }
                else if (a >= 70)
                {
                    RadioButtonList1.SelectedValue = "10";
                }
                else if (a >= 65)
                {
                    RadioButtonList1.SelectedValue = "8";
                }
                else if (a >= 60)
                {
                    RadioButtonList1.SelectedValue = "6";
                }
                else if (a >= 55)
                {
                    RadioButtonList1.SelectedValue = "4";
                }
                else if (a >= 50)
                {
                    RadioButtonList1.SelectedValue = "2";
                }
                else
                {
                    RadioButtonList1.SelectedValue = "2";
                }
           
                


                string date = "";
                if (Request.QueryString["dropdownlist1"] != null)
                {
                    date = Request["dropdownlist1"];
                }
                else
                {
                    date = DateTime.Now.ToString("yyyy년MM월");
                }
                int count = 0;
                string SQL1 = "select count(*) as count from insa_report where id_no = '" + Request["no"] + "' and date = '"+ date +"'";
                SqlDataAdapter ADT1 = new SqlDataAdapter(SQL1, DB);
                DataSet DBSET1 = new DataSet();
                ADT1.Fill(DBSET1, "BD");
                foreach (DataRow row in DBSET1.Tables["BD"].Rows)
                {
                    count = Convert.ToInt32(row["count"]);
                }

                if(count == 0)
                {
                    DB.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DB;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "insert into insa_report(id_no, name,dept_name,date,Q1,Q2,Q3,Q4,Q5,TOTAL, memo, month_1,month_2,half_1,half_2,year_1,year_2)" +
                    " values(@id_no, @name,@dept_name,@date,@Q1,@Q2,@Q3,@Q4,@Q5,@TOTAL, @memo, @month_1, @month_2, @half_1, @half_2, @year_1, @year_2)";
                    cmd.Parameters.Add("@id_no", SqlDbType.Int).Value = Request["no"];
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name.Value;
                    cmd.Parameters.Add("@dept_name", SqlDbType.NVarChar, 100).Value = dept_name.Value;
                    if (Request.QueryString["dropdownlist1"] != null)
                    {
                        cmd.Parameters.Add("@date", SqlDbType.NVarChar, 100).Value = Request["dropdownlist1"];
                    }
                    else
                    {
                        cmd.Parameters.Add("@date", SqlDbType.NVarChar, 100).Value = DateTime.Now.ToString("yyyy년MM월");
                    }
                    string a1 = "0";
                    string a2 = "0";
                    string a3 = "0";
                    string a4 = "0";
                    string a5 = "0";
                    if (RadioButtonList1.SelectedItem != null)
                    {
                        a1 = RadioButtonList1.SelectedValue;
                    }
                    if (RadioButtonList2.SelectedItem != null)
                    {
                        a2 = RadioButtonList2.SelectedValue;
                    }
                    if (RadioButtonList3.SelectedItem != null)
                    {
                        a3 = RadioButtonList3.SelectedValue;
                    }
                    if (RadioButtonList4.SelectedItem != null)
                    {
                        a4 = RadioButtonList4.SelectedValue;
                    }
                    if (RadioButtonList5.SelectedItem != null)
                    {
                        a5 = RadioButtonList5.SelectedValue;
                    }
                    cmd.Parameters.Add("@Q1", SqlDbType.Int).Value = a1;
                    cmd.Parameters.Add("@Q2", SqlDbType.Int).Value = a2;
                    cmd.Parameters.Add("@Q3", SqlDbType.Int).Value = a3;
                    cmd.Parameters.Add("@Q4", SqlDbType.Int).Value = a4;
                    cmd.Parameters.Add("@Q5", SqlDbType.Int).Value = a5;
                    cmd.Parameters.Add("@TOTAL", SqlDbType.Int).Value = Convert.ToInt32(a1) + Convert.ToInt32(a2) + Convert.ToInt32(a3) + Convert.ToInt32(a4) + Convert.ToInt32(a5);
                    cmd.Parameters.Add("@memo", SqlDbType.NVarChar, 1000).Value = TextBox3.Text;
                    cmd.Parameters.Add("@month_1", SqlDbType.Int).Value = Convert.ToInt32(month_1.Value);
                    cmd.Parameters.Add("@month_2", SqlDbType.Int).Value = Convert.ToInt32(month_2.Value);
                    cmd.Parameters.Add("@half_1", SqlDbType.Int).Value = Convert.ToInt32(half_1.Value);
                    cmd.Parameters.Add("@half_2", SqlDbType.Int).Value = Convert.ToInt32(half_2.Value);
                    cmd.Parameters.Add("@year_1", SqlDbType.Int).Value = Convert.ToInt32(year_1.Value);
                    cmd.Parameters.Add("@year_2", SqlDbType.Int).Value = Convert.ToInt32(year_2.Value);
                    cmd.ExecuteNonQuery();
                    DB.Close();
                    cmd.Dispose();
                    cmd = null;

                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                     "alert",
                     "alert('등록 되었습니다.');window.location ='insa_detail.aspx?no=" + Request["no"] + "&dropdownlist1="+ date +"';",
                     true);
                }
                else
                {
                    DB.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DB;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "update insa_report set Q1 = @Q1 , Q2 = @Q2 , Q3 = @Q3 , Q4 = @Q4 , Q5 = @Q5 , TOTAL = @TOTAL, memo = @memo, " +
                        "month_1 = @month_1, month_2 = @month_2 , half_1 = @half_1, half_2 = @half_2 , year_1 = @year_1 , year_2 = @year_2" +
                    " where id_no = @id_no and date = @date and name = @name";
                    cmd.Parameters.Add("@id_no", SqlDbType.Int).Value = Request["no"];
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name.Value;
                    cmd.Parameters.Add("@dept_name", SqlDbType.NVarChar, 100).Value = dept_name.Value;
                    if (Request.QueryString["dropdownlist1"] != null)
                    {
                        cmd.Parameters.Add("@date", SqlDbType.NVarChar, 100).Value = Request["dropdownlist1"];
                    }
                    else
                    {
                        cmd.Parameters.Add("@date", SqlDbType.NVarChar, 100).Value = DateTime.Now.ToString("yyyy년MM월");
                    }
                    //string a1 = "0";
                    string a2 = "0";
                    string a3 = "0";
                    string a4 = "0";
                    string a5 = "0";
                    if (RadioButtonList1.SelectedItem != null)
                    {
                        //a1 = RadioButtonList1.SelectedValue;
                      
                    }
                    if (RadioButtonList2.SelectedItem != null)
                    {
                        a2 = RadioButtonList2.SelectedValue;
                    }
                    if (RadioButtonList3.SelectedItem != null)
                    {
                        a3 = RadioButtonList3.SelectedValue;
                    }
                    if (RadioButtonList4.SelectedItem != null)
                    {
                        a4 = RadioButtonList4.SelectedValue;
                    }
                    if (RadioButtonList5.SelectedItem != null)
                    {
                        a5 = RadioButtonList5.SelectedValue;
                    }
                    cmd.Parameters.Add("@Q1", SqlDbType.Int).Value = RadioButtonList1.SelectedValue;
                    cmd.Parameters.Add("@Q2", SqlDbType.Int).Value = a2;
                    cmd.Parameters.Add("@Q3", SqlDbType.Int).Value = a3;
                    cmd.Parameters.Add("@Q4", SqlDbType.Int).Value = a4;
                    cmd.Parameters.Add("@Q5", SqlDbType.Int).Value = a5;
                    cmd.Parameters.Add("@TOTAL", SqlDbType.Int).Value = Convert.ToInt32(RadioButtonList1.SelectedValue) + Convert.ToInt32(a2) + Convert.ToInt32(a3) + Convert.ToInt32(a4) + Convert.ToInt32(a5);
                    cmd.Parameters.Add("@memo", SqlDbType.NVarChar, 1000).Value = TextBox3.Text;
                    cmd.Parameters.Add("@month_1", SqlDbType.Int).Value = month_1.Value;
                    cmd.Parameters.Add("@month_2", SqlDbType.Int).Value = month_2.Value;
                    cmd.Parameters.Add("@half_1", SqlDbType.Int).Value = half_1.Value;
                    cmd.Parameters.Add("@half_2", SqlDbType.Int).Value = half_2.Value;
                    cmd.Parameters.Add("@year_1", SqlDbType.Int).Value = year_1.Value;
                    cmd.Parameters.Add("@year_2", SqlDbType.Int).Value = year_2.Value;
                    cmd.ExecuteNonQuery();
                    DB.Close();
                    cmd.Dispose();
                    cmd = null;

                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                     "alert",
                     "alert('수정 되었습니다.');window.location ='insa_detail.aspx?no=" + Request["no"] + "&dropdownlist1=" + date + "';",
                     true);
                }


                    
                    //Response.Redirect("myinfo.aspx");
             
            }
            catch(Exception ex)
            {
                //if (RadioButtonList1.SelectedItem == null)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(),
                //    "alert",
                //    "alert('1번 항목이 비었습니다.');",
                //    true);
                //}
                //else if(RadioButtonList2.SelectedItem == null)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(),
                //    "alert",
                //    "alert('2번 항목이 비었습니다.');",
                //    true);
                //}
                //else if (RadioButtonList3.SelectedItem == null)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(),
                //    "alert",
                //    "alert('3번 항목이 비었습니다.');",
                //    true);
                //}
                //else if (RadioButtonList4.SelectedItem == null)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(),
                //    "alert",
                //    "alert('4번 항목이 비었습니다.');",
                //    true);
                //}
                //else if (RadioButtonList5.SelectedItem == null)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(),
                //    "alert",
                //    "alert('5번 항목이 비었습니다.');",
                //    true);
                //}
                //else
                //{
                //    Response.Write(ex.ToString());
                //    Response.End();
                //   // ScriptManager.RegisterStartupScript(this, this.GetType(),
                //   //"alert",
                //   //"alert('오류.');",
                //   //true);
                //}

                Response.Write(ex.ToString());
                Response.End();


            }



            //Response.Redirect("myinfo.aspx");


        }

        //protected void Button3_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("insa_detail.aspx?no=" + Request["no"]);
        //}

     
    }
}