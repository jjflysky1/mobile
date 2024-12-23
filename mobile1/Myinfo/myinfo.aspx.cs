using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mobile1.Myinfo
{
    public partial class myinfo : System.Web.UI.Page
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        DataSet DBSET = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (IsPostBack == true)
            {
                pwd.Value = TextBox7.Text;
                name.Value = TextBox2.Text;
                email.Value = TextBox3.Text;
                phone.Value = TextBox6.Text;
                dept_code.Value = DropDownList1.SelectedItem.Value;
                duty_code.Value = DropDownList2.SelectedItem.Value;

            }


            string SQL2 = "select * from dept_ba order by dept_code asc";
            SqlDataAdapter ADT2 = new SqlDataAdapter(SQL2, DB);
            DataSet DBSET2 = new DataSet();
            ADT2.Fill(DBSET2, "BD");
            foreach (DataRow row in DBSET2.Tables["BD"].Rows)
            {
                DropDownList1.Items.Add(new ListItem(row["dept_name"].ToString(), row["dept_code"].ToString()));
            }
            // DropDownList1.SelectedIndexChanged += work;

            string SQL1 = "select * from duty_ba  order by duty_code asc";
            SqlDataAdapter ADT1 = new SqlDataAdapter(SQL1, DB);
            DataSet DBSET1 = new DataSet();
            ADT1.Fill(DBSET1, "BD");
            foreach (DataRow row in DBSET1.Tables["BD"].Rows)
            {

                DropDownList2.Items.Add(new ListItem(row["duty_name"].ToString(), row["duty_code"].ToString()));

            }
            // DropDownList2.SelectedIndexChanged += work2;


            string SQL3 = "select a.* , b.*, c.* from user_ba a, dept_ba b , duty_ba c where a.id = '" + Request.Cookies["ID"].Value + "'" +
            " and a.dept_code = b.dept_code and a.duty = c.duty_code";
            SqlDataAdapter ADT3 = new SqlDataAdapter(SQL3, DB);
            ADT3.Fill(DBSET, "BD");
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                TextBox1.Text = row["id"].ToString();
                //TextBox7.Text = row["pwd"].ToString();
                TextBox2.Text = row["name"].ToString();
                TextBox3.Text = row["email"].ToString();
                //TextBox4.Text = row["duty_name"].ToString();
                //TextBox5.Text = row["dept_name"].ToString();
                if (row["phone"].ToString() == "")
                {
                    TextBox6.Text = "없음";
                }
                else
                {
                    TextBox6.Text = row["phone"].ToString();
                }
                DropDownList1.SelectedValue = row["dept_code"].ToString();
                DropDownList2.SelectedValue = row["duty_code"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../mail/mail_write.aspx?email=" + HiddenField1.Value);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            if (Request["flag"] == "Sell")
            {
                Response.Redirect("Sell.aspx");
            }
            else if (Request["flag"] == "Demo")
            {
                Response.Redirect("demo.aspx");
            }
            else if (Request["flag"] == "IN")
            {
                Response.Redirect("in.aspx");
            }


        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            try
            {
                if (TextBox7.Text.Length > 1)
                {
                    DB.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DB;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "update user_ba set pwd = @pwd, name=@name, email = @email, phone = @phone, dept_code = @dept_code , duty = @duty_code where id = '" + Request.Cookies["ID"].Value + "'";
                    cmd.Parameters.Add("@pwd", SqlDbType.NVarChar, 100).Value = pwd.Value;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name.Value;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = email.Value;
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar, 100).Value = phone.Value;
                    cmd.Parameters.Add("@dept_code", SqlDbType.NVarChar, 100).Value = dept_code.Value;
                    cmd.Parameters.Add("@duty_code", SqlDbType.NVarChar, 100).Value = duty_code.Value;
                    cmd.ExecuteNonQuery();
                    DB.Close();
                    cmd.Dispose();
                    cmd = null;

                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                     "alert",
                     "alert('수정되었습니다.');window.location ='myinfo.aspx';",
                     true);
                    //Response.Redirect("myinfo.aspx");
                }
                else
                {
                    DB.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DB;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "update user_ba set  name=@name, email = @email, phone = @phone, dept_code = @dept_code , duty = @duty_code where id = '" + Request.Cookies["ID"].Value + "'";
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name.Value;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = email.Value;
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar, 100).Value = phone.Value;
                    cmd.Parameters.Add("@dept_code", SqlDbType.NVarChar, 100).Value = dept_code.Value;
                    cmd.Parameters.Add("@duty_code", SqlDbType.NVarChar, 100).Value = duty_code.Value;
                    cmd.ExecuteNonQuery();
                    DB.Close();
                    cmd.Dispose();
                    cmd = null;

                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                     "alert",
                     "alert('수정되었습니다.');window.location ='myinfo.aspx';",
                     true);
                    // Response.Redirect("myinfo.aspx");
                }
            }
            catch
            {

            }



            //Response.Redirect("myinfo.aspx");


        }
    }
}