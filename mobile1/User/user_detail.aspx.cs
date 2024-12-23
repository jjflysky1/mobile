using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace mobile1.User
{
    public partial class user_detail : System.Web.UI.Page
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        DataSet DBSET = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["id"] != null)
            {
                string SQL3 = "select * from user_v where id = '" + Request["id"] + "'";
                SqlDataAdapter ADT3 = new SqlDataAdapter(SQL3, DB);
                ADT3.Fill(DBSET, "BD");
                foreach (DataRow row in DBSET.Tables["BD"].Rows)
                {
                    Label4.Text = row["companyname"].ToString();
                    Label5.Text = row["dept_name"].ToString();
                    Label6.Text = row["name"].ToString();
                    Label7.Text = row["duty_name"].ToString();
                    Label8.Text = row["email"].ToString();
                    if (row["tel"].ToString() == "")
                    {
                        Label9.Text = "없음";
                    }
                    else
                    {
                        Label9.Text = row["tel"].ToString();
                    }
                    Label10.Text = "<a href='tel:" + row["phone"].ToString() + "'>" + row["phone"].ToString() + "</a>";
                    //Label10.Attributes.Add("Onclick", "go('" + row["email"].ToString() + "')");
                    //Label10.Attributes["style"] = "cursor:pointer;";
                    Label8.Attributes.Add("Onclick", "go('" + row["email"].ToString() + "')");
                    Label8.Attributes["style"] = "cursor:pointer;";

                }

            }
            else
            {

                info.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../mail/mail_write.aspx?email=" + HiddenField1.Value);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("user_list.aspx");
        }
    }
}