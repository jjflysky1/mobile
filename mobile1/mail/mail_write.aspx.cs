using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mobile1.mail
{
    public partial class mail_write : System.Web.UI.Page
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);

        string attafchfile = "";
        string[] tempfile = { };


        protected void Page_Load(object sender, EventArgs e)
        {
            person();
            if (IsPostBack == true)
            {

                //HiddenField2.Value = areabody.InnerHtml;
                //areabody.InnerHtml = areabody.InnerHtml;
                title.Value = subject.Text;
            }
            else
            {
                if (Request.QueryString["email"] != null)
                {
                    to.Text = Request["email"].ToString();
                }

                if (Request.QueryString["no"] != null)
                {
                    //전달
                    get();
                    FileUpload1_div.Visible = false;
                }

                if (Request.QueryString["re"] != null)
                {
                    //회신
                    reget();
                    FileUpload1_div.Visible = false;
                }

                if (Request.QueryString["reall"] != null)
                {
                    //전체회신
                    regetall();
                    FileUpload1_div.Visible = false;
                }
            }


        }
        public void person()
        {
            int count = 0;
            String SQL2 = "select count(*)+1 as count from user_v";

            SqlDataAdapter ADT1 = new SqlDataAdapter(SQL2, DB);
            DataSet DBSET1 = new DataSet();
            ADT1.Fill(DBSET1, "BD1");
            foreach (DataRow row in DBSET1.Tables["BD1"].Rows)
            {
                count = Convert.ToInt32(row["count"].ToString());
            }

            //DropDownList1.Items.Add(new ListItem("선택", ""));
            string SQL = "select count(*) as count,  name,duty_name,email from user_v where name <> '관리자' group by name,duty_name,email,duty order by duty asc ";
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                if (DropDownList1.Items.Count < Convert.ToInt32(count))
                {
                    DropDownList1.Items.Add(new ListItem(row["name"].ToString() + " " + row["duty_name"].ToString(), row["email"].ToString()));
                }
            }

            //if (DropDownList1.Items.Count < Convert.ToInt32(count))
            //{
            //    DropDownList1.Items.Add(portname.ToString());
            //}
            DropDownList1.SelectedIndexChanged += work;
        }
        protected void work(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "선택")
            {

            }
            else
            {
                if (to.Text.Length == 0)
                {
                    to.Text = DropDownList1.SelectedValue;
                }
                else
                {
                    to.Text += "," + DropDownList1.SelectedValue;
                }
            }

        }

        public void get()
        {

            string SQL = "select  DATEPART(yy,date) as yy , left(date, 2) as mm, subject,attach,body from email_list where no = '" + Request["no"] + "'";
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                area.Text = Environment.NewLine + "-----Original Message-----" + Environment.NewLine + row["body"].ToString();

                try
                {
                    areabody.InnerHtml = area.Text;
                }
                catch
                {

                }


                subject.Text = "FW: " + row["subject"].ToString();
                attafchfile = row["attach"].ToString();
                yy.Value = row["yy"].ToString();
                mm.Value = row["mm"].ToString();
            }

            tempfile = attafchfile.Split('|');
            TextBox1.Text = tempfile.Length.ToString();
            for (int i = 0; i < tempfile.Length - 1; i++)
            {
                Label3.Text += tempfile[i] + ",";
            }
            //attafchfile = "D:\\mobile\\Mail_attach\\" + Request.Cookies["ID"].Value + "\\" + yy + "\\" + mm + "\\" + tempfile;
        }
        public void reget()
        {
            string SQL = "select   DATEPART(yy,date) as  yy , left(date, 2) as  mm, subject,attach,body,fromadress from email_list where no = '" + Request["re"] + "'";
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                area.Text = Environment.NewLine + "-----Original Message-----" + Environment.NewLine + row["body"].ToString();
                try
                {
                    areabody.InnerHtml = area.Text;
                }
                catch
                {

                }


                subject.Text = "FW: " + row["subject"].ToString();
                to.Text = row["fromadress"].ToString();

                attafchfile = row["attach"].ToString();
                yy.Value = row["yy"].ToString();
                mm.Value = row["mm"].ToString();
            }
            tempfile = attafchfile.Split('|');
            TextBox1.Text = tempfile.Length.ToString();
            for (int i = 0; i < tempfile.Length - 1; i++)
            {
                Label3.Text += tempfile[i] + ",";
            }
            //attafchfile = "D:\\mobile\\Mail_attach\\" + Request.Cookies["ID"].Value + "\\" + yy + "\\" + mm + "\\" + tempfile;
        }
        public void regetall()
        {

            string SQL = "select  DATEPART(yy,date) as  yy , left(date, 2) as  mm, subject,attach,body,fromadress,cc from email_list where no = '" + Request["reall"] + "'";
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                area.Text = Environment.NewLine + "-----Original Message-----" + Environment.NewLine + row["body"].ToString();

                try
                {
                    areabody.InnerHtml = area.Text;
                }
                catch
                {

                }


                subject.Text = "FW: " + row["subject"].ToString();
                to.Text = row["fromadress"].ToString();
                cc.Text = row["cc"].ToString().Replace("|", ",");
                attafchfile = row["attach"].ToString();
                yy.Value = row["yy"].ToString();
                mm.Value = row["mm"].ToString();
            }
            tempfile = attafchfile.Split('|');
            TextBox1.Text = tempfile.Length.ToString();
            for (int i = 0; i < tempfile.Length - 1; i++)
            {
                Label3.Text += tempfile[i] + ",";
            }
            //attafchfile = "D:\\mobile\\Mail_attach\\" + Request.Cookies["ID"].Value + "\\" + yy + "\\" + mm + "\\" + tempfile;
        }
        protected void Button3_Click(object sender, EventArgs e)
        {


            if (to.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                     "alert",
                     "alert('메일주소를 입력해주세요');window.location ='" + HttpContext.Current.Request.Url.AbsoluteUri + "';",
                     true);
                //Response.Write("<script>alert('메일주소를 입력해주세요');</script>");

                //Response.Redirect(Request.UrlReferrer.ToString());

                //ScriptManager.RegisterStartupScript(this, this.GetType(),
                //     "alert",
                //     "alert('"+ HiddenField2.Value + "');window.location ='" + HttpContext.Current.Request.Url.AbsoluteUri + "';",
                //     true);
            }

            HiddenField2.Value = HiddenField2.Value.Replace(Environment.NewLine, "<br>");
            try
            {
                string SQL = "";
                string serverip = "";
                SQL = "select * from site_config a , user_ba b where id = '" + Request.Cookies["ID"].Value + "'";
                SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
                DataSet DBSET = new DataSet();
                ADT.Fill(DBSET, "BD");
                foreach (DataRow row in DBSET.Tables["BD"].Rows)
                {
                    if (row["email"].ToString() != "")
                    {

                        MailMessage MAIL = new MailMessage();
                        SmtpClient SMTPMAIL = new SmtpClient(row["mailserverip"].ToString());
                        MAIL.From = new MailAddress(row["email"].ToString());
                        SMTPMAIL.Port = 25;
                        //MAIL.To.Add(Recever.Text.ToString());


                        MAIL.To.Add(to.Text);


                        if (cc.Text.ToString() != "")
                        {
                            MAIL.CC.Add(cc.Text.ToString());
                        }
                        MAIL.Subject = title.Value;
                        MAIL.Body = HiddenField2.Value;
                        //MAIL.BodyEncoding = System.Text.Encoding.UTF8;
                        //MAIL.SubjectEncoding = System.Text.Encoding.UTF8;
                        MAIL.IsBodyHtml = true;
                        TextBox1.Text = tempfile.Length.ToString();
                        int num = Convert.ToInt32(TextBox1.Text);
                        if (num > 1)
                        {
                            serverip = row["serverip"].ToString();
                            int count = Convert.ToInt32(TextBox1.Text);
                            string[] file = Label3.Text.Split(',');
                            for (int i = 0; i < file.Length - 1; i++)
                            {
                                //Response.Write(file[i]);
                                //Response.End();
                                //Label3.Text += tempfile[i] + " ";
                                //attafchfile = "C:\\mobile\\Mail_attach\\jjflysky\\2019\\04\\4층후.jpg";
                                attafchfile = "D:\\mobile\\Mail_attach\\" + Request.Cookies["ID"].Value + "\\" + yy.Value + "\\" + mm.Value + "\\" + file[i];

                                MAIL.Attachments.Add(new Attachment(attafchfile));
                            }
                        }
                        if (FileUpload1.HasFile)
                        {
                            string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                            Attachment myAttachment = new Attachment(FileUpload1.FileContent, fileName);
                            MAIL.Attachments.Add(myAttachment);
                        }

                        //HttpPostedFile postedFile = Request.Files["file"];

                        //Check if File is available.
                        //if (postedFile != null && postedFile.ContentLength > 0)
                        //{
                        //    //Save the File.
                        //    //string filePath = Server.MapPath("~/Uploads/") + Path.GetFileName(postedFile.FileName);
                        //    //postedFile.SaveAs(filePath);
                        //    //lblMessage.Visible = true;
                        //    FileInfo f = new FileInfo(postedFile.FileName);
                        //    string fullname = f.FullName;

                        //    Response.Write(fullname);
                        //    Response.End();
                        //    //MAIL.Attachments.Add(new Attachment(postedFile.FileName));
                        //}









                        SMTPMAIL.Send(MAIL);

                        DB.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = DB;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "insert into  mail_send_list([to],cc,[subject],body,attache,user_id) values(@to,@cc,@subject,@body,@attache,@user_id)";
                        cmd.Parameters.Add("@to", SqlDbType.NVarChar, 50).Value = to.Text;
                        cmd.Parameters.Add("@cc", SqlDbType.NVarChar, 50).Value = cc.Text;
                        cmd.Parameters.Add("@subject", SqlDbType.NVarChar, 50).Value = title.Value;
                        cmd.Parameters.Add("@body", SqlDbType.NVarChar, 4000).Value = HiddenField2.Value;
                        cmd.Parameters.Add("@attache", SqlDbType.NVarChar, 50).Value = Label3.Text;
                        cmd.Parameters.Add("@user_id", SqlDbType.NVarChar, 50).Value = Request.Cookies["ID"].Value;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        cmd = null;
                        DB.Close();
                        DB.Dispose();



                        Label1.Text = "<script>alert('전송되었습니다.');</script>";


                        Response.Redirect("mail_list.aspx");


                    }

                }
            }
            catch (Exception)
            {
                Response.Write(e.ToString());
                Response.End();
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("mail_list.aspx");
        }
    }
}