using OpenPop.Mime;
using OpenPop.Pop3;
using SmtPop;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mobile1.mail
{
    public partial class mail_view : System.Web.UI.Page
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int no = Convert.ToInt32(Request["no"]);
                if(Request["flag"] == "list_view")
                {
                    call(no);
                }
                if (Request["flag"] == "send_view")
                {
                    call2(no);
                    Button3.Visible = false;
                    Button4.Visible = false;
                    Button5.Visible = false;
                    Button6.Visible = false;
                }


                
            }
            catch
            {
                Response.Redirect("/Default.aspx");
            }
            
            
        }
        string SQL = "";
        protected void call(int no)
        {
            SQL = "select  subject, fromadress,cc,attach,user_id,CONVERT(datetime, date) as date,REPLACE(body, CHAR(13)+CHAR(10), '<br>') AS body , b.serverip  from email_list a , site_config b where no = '" + no +"'";
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            string attachefile = "";
            string user_id = "";
            int count = 0;
            string serverip = "";
            DateTime date = DateTime.Now;
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                Label2.Text = row["body"].ToString();
                Label3.Text = row["subject"].ToString();
                Label6.Text = row["fromadress"].ToString();
                Label5.Text = row["cc"].ToString();
                attachefile = row["attach"].ToString();
                user_id = row["user_id"].ToString();
                date = Convert.ToDateTime(row["date"].ToString());
                serverip = row["serverip"].ToString();
                Label4.Text = row["date"].ToString();
                
            }
            string[] attachefile2 = attachefile.Split('|');
            
            Label[] label = new Label[attachefile2.Length - 1];
            for (int i = 0; i < attachefile2.Length-1; i++)
            {
                label[i] = new Label();
                label[i].Text ="● " + "<a href='" + "http://"+ serverip +"/Mail_attach/" + user_id + "\\" + date.ToString("yyyy") + "\\" + date.ToString("MM") + "\\" +  attachefile2[i] + "'>" + attachefile2[i].ToString()  + "</a><br>" + "   ";
                //label[i].Text = attachefile2[i].ToString() + " | ";
                div1.Controls.Add(label[i]);
            }
            
            
            //Label4.Text += "<a href='" + "http://192.168.0.190:86/Mail_attach/" + user_id + "\\" + date.ToString("yyyy") + "\\" + date.ToString("MM") + "\\" + attachefile + "'>" + attachefile + "</a>" + "   ";
            //"D:\\mobile\\Mail_attach\\" + user_id + "\\" + date.ToString("yyyy") + "\\" + date.ToString("MM") + "\\";
            DB.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DB;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update email_list set view_flag = '1' where no = @id";
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = no;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            DB.Close();

            try
            {
                //Pop3Client objPOP3Client = new Pop3Client();
                //objPOP3Client.Connect("gw.sungsimit.co.kr", 110, false); //서버접속
                //objPOP3Client.Authenticate("jjflysky@sungsimit.co.kr", "dnjsvltm1!", AuthenticationMethod.UsernameAndPassword); //서버인증

                //var messageCount = objPOP3Client.GetMessageCount(); //받은메일의 메시지 개수

                //List<Message> allMessages = new List<Message>(messageCount);
                //var message = objPOP3Client.GetMessage(no);
                //var attachFile = message.FindAllAttachments();
                //foreach (var currentAttachFile in attachFile)
                //{
                //    //Console.Write("currentAttachFile : " + currentAttachFile.FileName + "<br />");
                //    string strFile = "D:\\mobile\\Mail_attach\\" + currentAttachFile.FileName;
                //    FileInfo fileInfo = new FileInfo(strFile);
                //    if (fileInfo.Exists)
                //    {

                //    }
                //    else
                //    {
                //        //var attachFileInfo = new FileInfo(@"C:\mobile\Mail_attach\\" + currentAttachFile.FileName);
                //        //currentAttachFile.Save(attachFileInfo);
                //        //string filePath = Path.Combine(@"D:\mobile\Mail_attach\\", currentAttachFile.FileName);
                //        //FileStream Stream = new FileStream(filePath, FileMode.Create);
                //        //BinaryWriter BinaryStream = new BinaryWriter(Stream);
                //        //BinaryStream.Write(currentAttachFile.Body);
                //        //Stream.Close();
                //        //BinaryStream.Close();
                //    }
                //    Label4.Text += "<a href='" + "http://192.168.0.190:86/Mail_attach/" + currentAttachFile.FileName + "'>" + currentAttachFile.FileName + "</a>" + "   ";
                //}
            }
            catch
            {

            }



        }
        protected void call2(int no)
        {
            SQL = "select  subject,  [to],cc,attache,user_id,CONVERT(datetime, date) as date,REPLACE(body, CHAR(13)+CHAR(10), '<br>') AS body , b.serverip  from mail_send_list a , site_config b where no = '" + no + "'";
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            string attachefile = "";
            string user_id = "";
            int count = 0;
            string serverip = "";
            DateTime date = DateTime.Now;
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                Label2.Text = row["body"].ToString();
                Label3.Text = row["subject"].ToString();
                Label6.Text = row["to"].ToString();
                Label5.Text = row["cc"].ToString();
                attachefile = row["attache"].ToString();
                user_id = row["user_id"].ToString();
                date = Convert.ToDateTime(row["date"].ToString());
                serverip = row["serverip"].ToString();
                Label4.Text = row["date"].ToString();

            }
            string[] attachefile2 = attachefile.Split('|');

            Label[] label = new Label[attachefile2.Length - 1];
            for (int i = 0; i < attachefile2.Length - 1; i++)
            {
                label[i] = new Label();
                label[i].Text = "● " + "<a href='" + "http://" + serverip + "/Mail_attach/" + user_id + "\\" + date.ToString("yyyy") + "\\" + date.ToString("MM") + "\\" + attachefile2[i] + "'>" + attachefile2[i].ToString() + "</a><br>" + "   ";
                //label[i].Text = attachefile2[i].ToString() + " | ";
                div1.Controls.Add(label[i]);
            }


            //Label4.Text += "<a href='" + "http://192.168.0.190:86/Mail_attach/" + user_id + "\\" + date.ToString("yyyy") + "\\" + date.ToString("MM") + "\\" + attachefile + "'>" + attachefile + "</a>" + "   ";
            //"D:\\mobile\\Mail_attach\\" + user_id + "\\" + date.ToString("yyyy") + "\\" + date.ToString("MM") + "\\";
            DB.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DB;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update mail_send_list set view_flag = '1' where no = @id";
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = no;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            DB.Close();

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["ID"].Value == HiddenField1.Value)
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
            else if (HiddenField1.Value.Length == 0)
            {
                try
                {
                    //DB.Open();
                    //SqlCommand cmd = new SqlCommand();
                    //cmd.Connection = DB;
                    //cmd.CommandType = System.Data.CommandType.Text;
                    //cmd.CommandText = "insert into notice ( title,body,create_date,writer) " +
                    //    "select @title, @body , getdate() ,@writer ";
                    //cmd.Parameters.Add("@title", SqlDbType.NVarChar, 100).Value = TextBox2.Text;
                    //cmd.Parameters.Add("@body", SqlDbType.NVarChar, 100).Value = TextBox1.Text;
                    //cmd.Parameters.Add("@writer", SqlDbType.NVarChar, 100).Value = Request.Cookies["ID"].Value;
                    //cmd.ExecuteNonQuery();
                    //DB.Close();
                    //cmd.Dispose();
                    //cmd = null;

                    //FCM.FCMSEND fcmsend = new FCM.FCMSEND();
                    //fcmsend.send("공지가 등록되었습니다", TextBox1.Text);

                    //Response.Redirect("notice.aspx");
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

            if (Request["flag"] == "list_view")
            {
                if (Request.QueryString["nowpage"] != null)
                {
                    Response.Redirect("mail_list.aspx?nowpage=" + Request["nowpage"].ToString());
                }
                else
                {
                    Response.Redirect("mail_list.aspx");
                }
            }
            if (Request["flag"] == "send_view")
            {
                if (Request.QueryString["nowpage"] != null)
                {
                    Response.Redirect("send_mail_list.aspx?nowpage=" + Request["nowpage"].ToString());
                }
                else
                {
                    Response.Redirect("send_mail_list.aspx");
                }
            }


       
            
            
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            DB.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DB;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "delete from email_list where no = @no";
            cmd.Parameters.Add("@no", SqlDbType.NVarChar, 50).Value = Request["no"];
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            DB.Close();
            DB.Dispose();
            Label1.Text = "<script>alert('삭제되었습니다,.');</script>";
            Response.Redirect("mail_list.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("mail_write.aspx?re=" + Request["no"]);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("mail_write.aspx?reall=" + Request["no"]);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("mail_write.aspx?no=" + Request["no"]);
        }
    }
}