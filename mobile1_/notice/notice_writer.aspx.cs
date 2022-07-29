using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mobile1.notice
{
    public partial class notice_writer : System.Web.UI.Page
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //title2.Style.Add("display", "none");
            //bodytext1.Style.Add("display", "none");
            if (IsPostBack == true)
            {
                body.Value = TextBox1.Text;
                title.Value = TextBox2.Text;
                
            }

            string no = Request["no"];
            HiddenField1.Value = Request["writer"];
            if (Request.QueryString["no"] == null)
            {
                Label1.Text = "글 쓰기";
                Button1.Text = "저장";
                title2.Style.Add("display", "none");
                bodytext1.Style.Add("display", "none");
            }
            else
            {
                Label1.Text = "내용";
                Button1.Text = "수정";
                Button2.Text = "이전";
                Label2.Style.Add("display", "none");
                Label3.Style.Add("display", "none");
                //Button1.Style.Add("display", "none");
                //title1.Style.Add("display", "none");
                //bodytext.Style.Add("display", "none");
                call();
                
            }

        }
        string SQL = "";
        protected void call()
        {
            SQL = "select * from notice where no = "+ Request["no"];
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                //TextBox2.Text = row["title"].ToString();
                //TextBox1.Text = row["body"].ToString();
                Label2.Text = row["title"].ToString();
                Label3.Text = row["body"].ToString();
                TextBox2.Text = row["title"].ToString();
                TextBox1.Text = row["body"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string name = "";
            string SQL = "select * from user_ba where id = '" + Request.Cookies["ID"].Value + "'";
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            string pwd = "";
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                name = row["name"].ToString();
            }


            if (name == HiddenField1.Value)
            {
                if (Label1.Text == "내용")
                {
                    try
                    {
                        DB.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = DB;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "update notice set title=@title, body=@body where no = " + Request["no"];
                        cmd.Parameters.Add("@title", SqlDbType.NVarChar, 100).Value = title.Value;
                        cmd.Parameters.Add("@body", SqlDbType.NVarChar, 100).Value = body.Value;
                        cmd.Parameters.Add("@writer", SqlDbType.NVarChar, 100).Value = Request.Cookies["ID"].Value;
                        cmd.ExecuteNonQuery();
                        DB.Close();
                        cmd.Dispose();
                        cmd = null;

                        Response.Redirect("notice.aspx");
                    }
                    catch
                    {

                    }
                }
                else
                {
                   
                }
            }
            else if(HiddenField1.Value.Length == 0)
            {
                try
                {
                    string SQL2 = "select * from user_ba where id = '" + Request.Cookies["ID"].Value + "'";
                    SqlDataAdapter ADT2 = new SqlDataAdapter(SQL2, DB);
                    DataSet DBSET2 = new DataSet();
                    ADT2.Fill(DBSET2, "BD");
                    foreach (DataRow row in DBSET2.Tables["BD"].Rows)
                    {
                        name = row["name"].ToString();
                    }


                    DB.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DB;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "insert into notice ( title,body,create_date,writer) " +
                        "select @title, @body , getdate() ,@writer ";
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar, 100).Value = TextBox2.Text;
                    cmd.Parameters.Add("@body", SqlDbType.NVarChar, 100).Value = TextBox1.Text;
                    cmd.Parameters.Add("@writer", SqlDbType.NVarChar, 100).Value = name;
                    cmd.ExecuteNonQuery();
                    DB.Close();
                    cmd.Dispose();
                    cmd = null;

                    FCM.FCMSEND fcmsend = new FCM.FCMSEND();
                    fcmsend.send("공지가 등록되었습니다", TextBox1.Text);

                    Response.Redirect("notice.aspx");
                }
                catch
                {

                }
            }
            else
            {
                Response.Write("<script>alert('수정하실수 없습니다');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("notice.aspx");
        }
    }
}