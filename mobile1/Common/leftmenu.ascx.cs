using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace mobile1.Common
{
    public partial class leftmenu : System.Web.UI.UserControl
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                string SQL = "select * from user_ba where id = '" + Request.Cookies["ID"].Value + "'";
                SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
                DataSet DBSET = new DataSet();
                ADT.Fill(DBSET, "BD");
                string pwd = "";
                foreach (DataRow row in DBSET.Tables["BD"].Rows)
                {
                    Label111.Text = row["name"].ToString();
                    pwd = row["pwd"].ToString();
                }

                if (Request.Cookies["ID"].Value == "jjflysky" || Request.Cookies["ID"].Value == "maria58" || Request.Cookies["ID"].Value == "kwak0001" || Request.Cookies["ID"].Value == "khj3322")
                {
                    insa.Visible = true;
                }
                else
                {
                    insa.Visible = false;
                }

            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }
        }
    }
}