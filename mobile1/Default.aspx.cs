using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace mobile1
{
    public partial class Default : System.Web.UI.Page
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        private String SQL = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserId"] != null)        // 쿠키가 있는지 확인해서 있으면 아이디 입력필드에 지정
                {                                                      // 체크박스는 체크상태로
                    name.Value = Request.Cookies["UserId"].Value;

                    CheckBox1.Checked = true;
                    //password.Focus();
                }
                if (Request.Cookies["Userpwd"] != null)        // 쿠키가 있는지 확인해서 있으면 아이디 입력필드에 지정
                {                                                      // 체크박스는 체크상태로
                    //password.Value = "**********";
                    txtPassword.Text = Request.Cookies["Userpwd"].Value;
                    //password.Attributes["value"] = Request.Cookies["Userpwd"].Value;
                    txtPassword.Attributes["value"] = Request.Cookies["Userpwd"].Value;
                    CheckBox1.Checked = true;
                    //password.Focus();
                }

            }

        }


        protected void LOGIN(object sender, EventArgs e)
        {

            if (CheckBox1.Checked)
            {
                HttpCookie cookie = new HttpCookie("UserId", name.Value);
                HttpCookie cookie1 = new HttpCookie("Userpwd", txtPassword.Text);
                cookie.Expires = DateTime.Now.AddDays(7);            // 7일간 쿠키저장
                cookie1.Expires = DateTime.Now.AddDays(7);            // 7일간 쿠키저장
                Response.Cookies.Add(cookie);
                Response.Cookies.Add(cookie1);
            }
            else
            {
                HttpCookie cookie = new HttpCookie("UserId", name.Value);
                HttpCookie cookie1 = new HttpCookie("Userpwd", txtPassword.Text);
                cookie.Expires = DateTime.Now.AddDays(-1);        // 쿠키 삭제
                cookie1.Expires = DateTime.Now.AddDays(-1);        // 쿠키 삭제
                Response.Cookies.Add(cookie);
                Response.Cookies.Add(cookie1);
            }

            HttpCookie COOKIE = new HttpCookie("userinfo");
            COOKIE["ID"] = name.Value;
            COOKIE["SetDate"] = DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss");
            COOKIE.Expires = DateTime.Now.AddDays(1d);
            Response.Cookies.Add(COOKIE);
            Response.Cookies["ID"].Value = name.Value;
            LOGIN_DB();

        }

        protected void LOGIN_DB()
        {

            SQL = "select * from user_ba where id = @id and pwd = @pwd and flag = 1";

            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.SelectCommand.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = name.Value;
            ADT.SelectCommand.Parameters.Add("@pwd", SqlDbType.NVarChar, 50).Value = txtPassword.Text;

            try
            {
                ADT.Fill(DBSET);
                if (DBSET.Tables[0].Rows.Count > 0)
                {
                    //HttpRequest currentRequest = HttpContext.Current.Request;
                    //string ip = currentRequest.ServerVariables["REMOTE_ADDR"];
                    DB.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DB;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "insert into login_log_list (id, time) values( @id, getdate())";
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar, 100).Value = name.Value;
                    cmd.ExecuteNonQuery();
                    DB.Close();
                    cmd.Dispose();
                    cmd = null;

                    try
                    {
                        if (Request["token"].ToString().Length > 0)
                        {
                            DB.Open();
                            SqlCommand cmd2 = new SqlCommand("add_token", DB);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@token", Request["token"].ToString());
                            cmd2.Parameters.AddWithValue("@id", name.Value);
                            cmd2.ExecuteNonQuery();
                            cmd2.Dispose();
                            cmd2 = null;
                            DB.Close();
                        }
                    }
                    catch
                    {

                    }




                    //Label1.Text = "<script>alert('환영합니다.');</script>";
                    Response.Redirect("main.aspx?id=" + name.Value);
                }
                else
                {
                    this.Label1.Text = "<script>alert('사용자 계정을 확인해 주세요');</script>";
                }
                DBSET.Clear();
            }
            catch (Exception EX)
            {
                this.Label1.Text = EX.ToString();
            }
            DBSET.Dispose();
            ADT.Dispose();

            DBSET = null;
            ADT = null;




            return;

        }
    }
}