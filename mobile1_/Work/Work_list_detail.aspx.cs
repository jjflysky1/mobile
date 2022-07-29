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
    public partial class Work_list_detail : System.Web.UI.Page
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        DataSet DBSET = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (IsPostBack == true)
            {
              
                HiddenField2.Value = Label3.Text;
                HiddenField3.Value = TextBox1.Text;
                HiddenField4.Value = TextBox2.Text;
                HiddenField5.Value = TextBox3.Text;
                HiddenField6.Value = TextBox4.Text;
                HiddenField7.Value = TextBox5.Text;
                HiddenField8.Value = TextBox6.Text;
                HiddenField9.Value = TextBox7.Text;
                HiddenField10.Value = TextBox8.Text;
                HiddenField11.Value = TextBox9.Text;
                HiddenField12.Value = TextBox10.Text;
                HiddenField13.Value = TextBox11.Text;
                HiddenField14.Value = TextBox12.Text;
                HiddenField16.Value = TextBox13.Text;
                HiddenField15.Value = CheckBox1.Checked.ToString();
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

        
            try
            {
                string SQL3 = "select * from maintenance where no = '" + Request["no"] + "' ";
                SqlDataAdapter ADT3 = new SqlDataAdapter(SQL3, DB);
                ADT3.Fill(DBSET, "BD");
                foreach (DataRow row in DBSET.Tables["BD"].Rows)
                {

                    Label3.Text = row["company_name"].ToString();
                    TextBox1.Text = row["contract"].ToString();
                    TextBox2.Text = row["item"].ToString();
                    TextBox3.Text = row["company_person"].ToString();
                    TextBox4.Text = row["company_contact"].ToString();
                    TextBox5.Text = row["company_email"].ToString();
                    TextBox6.Text = row["adress"].ToString();
                    TextBox7.Text = row["sales"].ToString();
                    TextBox8.Text = row["mother_company"].ToString();
                    TextBox9.Text = row["mother_person"].ToString();
                    TextBox10.Text = row["mother_contact"].ToString();
                    TextBox11.Text = row["mother_email"].ToString();
                    TextBox12.Text = row["schedule"].ToString();
                    TextBox13.Text = row["engineer"].ToString();
                    if (row["main_check"].ToString() == "1")
                    {
                        CheckBox1.Checked = true;
                    }
                    else
                    {
                        CheckBox1.Checked = false;
                    }
                    
                    
                    




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
                Response.Redirect("Work_list.aspx?search=" + Request["search"] + "&type=" + Request["type"]);
            }
            else
            {
                Response.Redirect("Work_list.aspx?nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
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
            if(HiddenField15.Value == "True")
            {
                HiddenField15.Value = "1";
            }
            else
            {
                HiddenField15.Value = "0";
            }
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
            cmd.CommandText = "update maintenance set contract = '" + HiddenField3.Value + "' , item = '" + HiddenField4.Value + "'" +
                ", company_person = '" + HiddenField5.Value + "', company_contact = '" + HiddenField6.Value + "' , company_email ='" + HiddenField7.Value +"'" +
                ", adress = '" + HiddenField8.Value + "', sales = '" + HiddenField9.Value + "', mother_company = '" + HiddenField10.Value + "'" +
                ", mother_person = '" + HiddenField11.Value + "', mother_contact = '" + HiddenField12.Value + "', mother_email = '" + HiddenField13.Value + "'" +
                ", schedule = '" + HiddenField14.Value + "', main_check = '" + HiddenField15.Value + "', engineer = '" + HiddenField16.Value + "', modi_user = '" + name + "' where no = " + Request["no"];
            cmd.ExecuteNonQuery();
            DB.Close();
            cmd.Dispose();
            cmd = null;

            //Response.Redirect("Sell.aspx?nowpage="+Request["nowpage"].ToString());
            if (Request.QueryString["nowpage"] == null)
            {
                Response.Redirect("work_list.aspx?search=" + Request["search"] + "&type=" + Request["type"]);
            }
            else
            {
                Response.Redirect("work_list.aspx?nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
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