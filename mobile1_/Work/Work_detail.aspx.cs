using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mobile1.Work
{
    public partial class Work_detail : System.Web.UI.Page
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        DataSet DBSET = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (IsPostBack == true)
            {
              
                HiddenField2.Value = DropDownList3.SelectedValue;
                HiddenField3.Value = TextBox4.Text;
                HiddenField4.Value = engineer.Text;
                HiddenField5.Value = Label7.Text;
                HiddenField6.Value = DropDownList2.SelectedValue;
                HiddenField7.Value = TextBox1.Text;
                HiddenField8.Value = TextBox2.Text;
            }

           
                //count
                string SQL = "";
                SQL = "select count(*) as count from work ";
                int count = 0;
                SqlDataAdapter ADT2 = new SqlDataAdapter(SQL, DB);
                DataSet DBSET2 = new DataSet();
                ADT2.Fill(DBSET2, "BD");
                foreach (DataRow row in DBSET2.Tables["BD"].Rows)
                {
                    count = Convert.ToInt32(row["count"].ToString());
                }

            string company_name = "";
            SQL = "select distinct * from customer_company order by no desc";
            SqlDataAdapter ADT6 = new SqlDataAdapter(SQL, DB);
            DataSet DBSET6 = new DataSet();
            ADT6.Fill(DBSET6, "BD");
            foreach (DataRow row in DBSET6.Tables["BD"].Rows)
            {
                company_name = row["company_name"].ToString();
                DropDownList3.Items.Add(company_name.ToString());
               
            }
            try
            {
                string SQL3 = "select * from work where no = '" + Request["no"] + "' ";
                SqlDataAdapter ADT3 = new SqlDataAdapter(SQL3, DB);
                ADT3.Fill(DBSET, "BD");
                foreach (DataRow row in DBSET.Tables["BD"].Rows)
                {

                    DropDownList3.SelectedValue = row["Customer_company"].ToString();
                    if(DropDownList3.SelectedValue == "선택")
                    {
                        TextBox3.Text = row["Customer_company"].ToString();
                        TextBox3.Visible = true;
                    }
                    else
                    {
                        TextBox3.Visible = false;
                    }
                    TextBox4.Text = row["Customer_person"].ToString();
                    engineer.Text = row["engineer"].ToString();
                    Label7.Text = row["date"].ToString();
                    Label2.Text = row["start_time"].ToString() + " ~ " + row["end_time"].ToString();
                    //if (row["category"].ToString() == "장애처리")
                    //{
                    //    DropDownList2.SelectedValue = "장애처리";
                    //}
                    //else if (row["category"].ToString() == "기술지원")
                    //{
                    //    DropDownList2.SelectedValue = "기술지원";
                    //}
                    //else if (row["category"].ToString() == "정기점검")
                    //{
                    //    DropDownList2.SelectedValue = "정기점검";
                    //}
                    DropDownList2.SelectedValue = row["category"].ToString();
                    TextBox1.Text = row["history"].ToString();
                    TextBox2.Text = row["Customer_request"].ToString().Replace("\r\n", "<br>");

                    

                }
            }
            catch
            {

            }
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../mail/mail_write.aspx?email=" + HiddenField1.Value);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["nowpage"] == null)
            {
                Response.Redirect("Work.aspx?search=" + Request["search"] + "&type=" + Request["type"]);
            }
            else
            {
                Response.Redirect("Work.aspx?nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
            }


        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
         
                string SQL = "select * from user_ba where id = '" + Request.Cookies["ID"].Value + "'";
                SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
                DataSet DBSET = new DataSet();
                ADT.Fill(DBSET, "BD");
                string name = "";
                foreach (DataRow row in DBSET.Tables["BD"].Rows)
                {
                    name = row["name"].ToString();

                }


                //DB.Open();
                //SqlCommand cmd = new SqlCommand();
                //cmd.Connection = DB;
                //cmd.CommandType = System.Data.CommandType.Text;
                //cmd.CommandText = "update product_sell set product = '" + HiddenField4.Value + "', outdate= '" + outdate.Text + " ' +  CONVERT(CHAR(8), GETDATE(), 24), out_user = '" + name + "', to_location = '" + HiddenField2.Value + "' where no = " + Request["no"];
                //cmd.ExecuteNonQuery();
                //DB.Close();
                //cmd.Dispose();
                //cmd = null;

                //Response.Redirect("Sell.aspx?nowpage="+Request["nowpage"].ToString());
                if (Request.QueryString["nowpage"] == null)
                {
                    Response.Redirect("Sell.aspx?search=" + Request["search"] + "&type=" + Request["type"]);
                }
                else
                {
                    Response.Redirect("Sell.aspx?nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
                }
              
              
            



        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string SQL = "select * from user_ba where id = '" + Request.Cookies["ID"].Value + "'";
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            string name = "";
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                name = row["name"].ToString();

            }

            DB.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DB;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update work set Customer_company = '" + HiddenField2.Value + "' , Customer_person = '" + HiddenField3.Value + "'" +
                ", engineer = '" + HiddenField4.Value + "', category = '" + HiddenField6.Value + "' , history ='" + HiddenField7.Value +"'" +
                ", Customer_request = '" + HiddenField8.Value + "', modi_user = '" + name + "' where no = " + Request["no"];
            cmd.ExecuteNonQuery();
            DB.Close();
            cmd.Dispose();
            cmd = null;

            //Response.Redirect("Sell.aspx?nowpage="+Request["nowpage"].ToString());
            if (Request.QueryString["nowpage"] == null)
            {
                Response.Redirect("work.aspx?search=" + Request["search"] + "&type=" + Request["type"]);
            }
            else
            {
                Response.Redirect("work.aspx?nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
            }

        }
        protected void work(object sender, EventArgs e)
        {
            //TextBox2.Text = DropDownList1.SelectedValue;
        }
        protected void work2(object sender, EventArgs e)
        {
            
        }
    }
}