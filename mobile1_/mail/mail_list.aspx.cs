using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using OpenPop.Pop3;
using OpenPop.Mime;
using SmtPop;
using System.Text;
using System.Xml;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Web.Services;

namespace mobile1.mail
{
    public partial class mail_list : System.Web.UI.Page
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Search.Attributes.Add("onkeypress", "button_click(this,'')");

           
            
            if (!Page.IsPostBack)
            {
                DropDownList1.SelectedValue = Request["dropdown"];
                Search.Text = Request["Search"];
            }
            
            
            UISET();
            HiddenField2.Value = Request.Cookies["ID"].Value;
       


        }

    

        public class Customer2
        {
            public string id { get; set; }
           
        }
        [WebMethod]
        public static string getlist(string user_id)
        {
            
            SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
            //SmtPop.POP3Client pop = new SmtPop.POP3Client();
            //pop.Open("gw.sungsimit.co.kr", 110, "jjflysky@sungsimit.co.kr", "dnjsvltm1!");
            //// Get message list from POP server
            //SmtPop.POPMessageId[] messages = pop.GetMailList();

   
            string SQL = "select top 1 id from email_list where user_id = '" + user_id + "' order by id desc";
            int end = 0;
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                end = Convert.ToInt32(row["id"]);
            }
            //int numChk = 0;
            //bool isNum = int.TryParse(end.ToString(), out numChk);
            //if (!isNum)
            //{
            //    end = 0; //숫자가 아님
            //}
            //else
            //{
            //    //숫자
            //    //숫자일 경우 numChk 의 값은 101 이 된다.
            //}

                Pop3Client objPOP3Client = new Pop3Client();
                objPOP3Client.Connect("gw.sungsimit.co.kr", 110, false); //서버접속
                objPOP3Client.Authenticate("jjflysky@sungsimit.co.kr", "dnjsvltm1!", AuthenticationMethod.UsernameAndPassword); //서버인증
                var messageCount = objPOP3Client.GetMessageCount(); //받은메일의 메시지 개수
                var uids = objPOP3Client.GetMessageUids();
                for (var i = messageCount - 1; i >= 0; i--)
                {
                    if(Convert.ToInt32(uids[i]) > end)
                    {
                        var messageBody = "";
                        var attach = "";
                        var opensubject = "";
                        var fromAddress = "";
                        var fromname = "";
                        var cc = "";
                        DateTime date = DateTime.Now;
                        try
                        {
                            List<Message> allMessages = new List<Message>(messageCount);
                            var message = objPOP3Client.GetMessage(i+1);

                            messageBody = String.Empty;
                            var plainText = message.FindFirstPlainTextVersion();
                            if (plainText == null)
                            {
                                var html = message.FindFirstHtmlVersion();
                                messageBody = html.GetBodyAsText();
                            }
                            else
                            {
                                messageBody = plainText.GetBodyAsText();
                            }
                        //Label2.Text = messageBody;
                            fromname = message.Headers.From.DisplayName;
                            opensubject = message.Headers.Subject;
                            fromAddress = message.Headers.From.Address;
                            var cccount = message.Headers.Cc.Count();
                            if (cccount != 0)
                            {
                                for (var j = cccount - 1; j >= 0; j--)
                                {
                                //Console.WriteLine("subject : " + message.Headers.Cc[j]);
                                cc += message.Headers.Cc[j] + "|";
                                }
                            }
                            date = Convert.ToDateTime(message.Headers.Date);
                            var attachFile = message.FindAllAttachments();
                            foreach (var currentAttachFile in attachFile)
                            {
                                string strFile = "D:\\mobile\\Mail_attach\\" + currentAttachFile.FileName;
                                FileInfo fileInfo = new FileInfo(strFile);
                                if (fileInfo.Exists)
                                {

                                }
                                else
                                {
                                    var attachFileInfo = new FileInfo(@"D:\mobile\Mail_attach\\" + currentAttachFile.FileName);
                                    currentAttachFile.Save(attachFileInfo);
                                }
                                //Label4.Text += "<a href='" + "http://192.168.0.190:86/Mail_attach/" + currentAttachFile.FileName + "'>" + currentAttachFile.FileName + "</a>" + "   ";
                                attach += currentAttachFile.FileName + "|";
                            }
                        }
                        catch
                        {

                        }

                        DB.Open();
                        SqlCommand cmd = new SqlCommand("add_email", DB);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fromname", fromname);
                        cmd.Parameters.AddWithValue("@fromadress", fromAddress);
                        cmd.Parameters.AddWithValue("@cc", cc);
                        cmd.Parameters.AddWithValue("@subject", opensubject);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@id", uids[i]);
                        cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.Parameters.AddWithValue("@body", messageBody);
                        cmd.Parameters.AddWithValue("@attach", attach);
                        //cmd.Parameters.AddWithValue("@user_id", Request.Cookies["ID"].Value);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        cmd = null;
                        DB.Close();
                    }
                    
                }
                    
                //foreach (SmtPop.POPMessageId id in messages.Reverse())
                //{
               
                //}
            

            //pop.Quit();

            return "1";

         
        }
        private void UISET()
        {
            TBLSET();
        }
        private void TBLSET()
        {
            TableHeaderRow TR;
            TableHeaderCell TD;

            TR = new TableHeaderRow();

            //TR.BackColor = System.Drawing.Color.White;

            TD = new TableHeaderCell();
            TD.Width = 40;
            TD.Text = "NO";
            //TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "순번";
            TD.Attributes["style"] = "text-align : center";
            //TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "보낸 사람";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "파일";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "제목";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "받은날짜";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);



            TBLLIST.Rows.Add(TR);


            TBLLOAD();
        }
        private void PAGEADD(int pagecount, int nowpage)
        {
            
            StringBuilder SB = new StringBuilder();

            SB.Append("<ul class='pagination pagination-sm no-margin'>");
            SB.Append("<li>" + "<a href='mail_list.aspx?nowpage=" + 1 + "'>" + "<span aria-hidden='true'> &laquo;</span>" + "</a>" + "<li>");
            if (pagecount == 0)
            {
                SB.Append("<li> " + "<a href='mail_list.aspx?nowpage=" + 1 + "'>" + 1 + "</a>" + " <li>");
            }
            int nowlist = 0;
            if (nowpage > 5)
            {
                nowlist = nowpage - 3;
            }
            if (nowpage < 6)
            {
                nowlist = 1;
            }
            for (int i = nowlist; i < pagecount; i++)
            {
                if (nowlist + 6 == i)
                {
                    break;
                }
                if (i == nowpage)
                {
                    SB.Append("<li class='page-item active'> " + "<a href='mail_list.aspx?nowpage=" + i + "'>" + i + "</a>" + " <li>");
                }
                else
                {
                    SB.Append("<li> " + "<a href='mail_list.aspx?nowpage=" + i + "'>" + i + "</a>" + " <li>");
                }
            }

            SB.Append("<li>" + "<a href='mail_list.aspx?nowpage=" + (pagecount - 1) + "'>" + "<span aria-hidden='true'> &raquo;</span>" + "</a>" + "<li>");
            SB.Append("</ul>");



            Label2.Text = SB.ToString();
            Label1.Text = SB.ToString();
        }
        string SQL = "";
        private void TBLLOAD()
        {
            int nowpage = Convert.ToInt32(Request["nowpage"]);
            if (nowpage == 0)
            {
                nowpage = 1;
            }

            //string SQL2 = "select count(*) as count from email_list where user_id = '" + Request.Cookies["ID"].Value + "'";
            string SQL2 = "";
            if (Request.QueryString["search"] != null && DropDownList1.SelectedValue == "1")
            {
                 SQL2 = "select count(*) as count from email_list where user_id = '" + Request.Cookies["ID"].Value + "' and fromname like '%" + Search.Text + "%'";
            }
            else
            {
                //ADT.SelectCommand.Parameters.AddWithValue("@search", "where user_id  = '" + Request.Cookies["ID"].Value + "' and fromadress like '%" + Search.Text + "%'");
            }

            if (Request.QueryString["search"] != null && DropDownList1.SelectedValue == "2")
            {
                 SQL2 = "select count(*) as count from email_list where user_id = '" + Request.Cookies["ID"].Value + "' and subject like '%" + Search.Text + "%'";
                
            }
            else
            {
                //ADT.SelectCommand.Parameters.AddWithValue("@search", "where user_id  = '"+ Request.Cookies["ID"].Value +"' and subject like '%" + Search.Text + "%'");
            }
            if (Request.QueryString["search"] == null || DropDownList1.SelectedValue == "0")
            {
                SQL2 = "select count(*) as count from email_list where user_id = '" + Request.Cookies["ID"].Value + "' and subject like '%" + Search.Text + "%'";
            }





            //if (DropDownList1.SelectedValue == "4")
            //{
            //    SQL2 = "select count(distinct serverip) as count from service where serverip like '%" + Search.Text + "%'";

            //}
            //if (DropDownList1.SelectedValue == "5")
            //{
            //    SQL2 = "select count(distinct serverip) as count from service where category like '%" + Search.Text + "%'";

            //}
            DB.Close();
            DB.Open();
            SqlCommand comm = new SqlCommand(SQL2, DB);
            Int32 count = (Int32)comm.ExecuteScalar();

            DB.Close();
            //int pagenum = Convert.ToInt32(DropDownList2.SelectedValue);
            int pagenum = 10;
            int pagecount = count / pagenum + 1;

            if (count / pagenum > 0)
            {
                pagecount++;
            }


            int start = ((nowpage - 1) * pagenum) + 1;
            int end = nowpage * pagenum;
            PAGEADD(pagecount, nowpage);

            SqlDataAdapter ADT = new SqlDataAdapter("mail_list", DB);
            ADT.SelectCommand.CommandType = CommandType.StoredProcedure;

            //if (DropDownList1.SelectedValue == "1")
            //{
            //    SQL = "select * from Service where os like '%" + Search.Text + "%' order by no desc";
            //}
            //else if (DropDownList1.SelectedValue == "2")
            //{
            //    SQL = "select * from Service where status like '%" + Search.Text + "%' order by no desc";
            //}
            //else if (DropDownList1.SelectedValue == "3")
            //{
            //    SQL = "select * from Service where name like '%" + Search.Text + "%' order by no desc";
            //}
            //else if (DropDownList1.SelectedValue == "4")
            //{
            //    ADT.SelectCommand.Parameters.AddWithValue("@search", "where no like '%" + Search.Text + "%'");
            //    ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end);
            //}
            //else if (DropDownList1.SelectedValue == "5")
            //{
            //    if (Search.Text == "null")
            //    {
            //        ADT.SelectCommand.Parameters.AddWithValue("@search", "where category is null");
            //    }
            //    else
            //    {
            //        ADT.SelectCommand.Parameters.AddWithValue("@search", "where category like '%" + Search.Text + "%'");
            //    }
            //    ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end);
            //}
            //else
            //{
            //    ADT.SelectCommand.Parameters.AddWithValue("@search", " ");
            //    ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end);
            //    ADT.SelectCommand.Parameters.AddWithValue("@user_id", Request.Cookies["ID"].Value);
            //}

       
            if (Request.QueryString["search"] != null && DropDownList1.SelectedValue == "1")
            {
                ADT.SelectCommand.Parameters.AddWithValue("@search", "where user_id  = '" + Request.Cookies["ID"].Value + "' and fromname like '%" + Search.Text + "%'");
            }
            else
            {
                //ADT.SelectCommand.Parameters.AddWithValue("@search", "where user_id  = '" + Request.Cookies["ID"].Value + "' and fromadress like '%" + Search.Text + "%'");
            }
            
            if (Request.QueryString["search"] != null && DropDownList1.SelectedValue == "2")
            {
                ADT.SelectCommand.Parameters.AddWithValue("@search", "where user_id  = '" + Request.Cookies["ID"].Value + "' and subject like '%"+ Search.Text +"%'");
            }
            else    
            {
                //ADT.SelectCommand.Parameters.AddWithValue("@search", "where user_id  = '"+ Request.Cookies["ID"].Value +"' and subject like '%" + Search.Text + "%'");
            }
            if (Request.QueryString["search"] == null || DropDownList1.SelectedValue == "0")
            {
                ADT.SelectCommand.Parameters.AddWithValue("@search", "where user_id  = '" + Request.Cookies["ID"].Value + "' and subject like '%" + Search.Text + "%'");
            }
                
            ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end);
            ADT.SelectCommand.Parameters.AddWithValue("@user_id", Request.Cookies["ID"].Value);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                TBLADD(row["subject"].ToString(), row["fromname"].ToString(), row["date"].ToString(), row["no"].ToString() ,row["view_flag"].ToString(),row["attach"].ToString());

            }

        }
        long a = 1;
        private void TBLADD(string title, string from, string time, string id, string view_flag, string attache)
        {
            TableRow TR;
            TableCell TD;
            DateTime date = Convert.ToDateTime(time.ToString());

            TR = new TableRow();
            TR.Font.Size = 10;
            if(Convert.ToInt32(view_flag) == 0)
            { 
                TR.Font.Bold = true;
            }
           
            
            TD = new TableCell();
            TD.Width = 30;
            TD.Text = from.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;cursor:pointer;";
            //TD.Attributes.Add("Onclick", "go('" + date.ToString("yyyyMMddHHmmss") + "')");
            TD.Attributes.Add("Onclick", "go('" + id + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 30;
            if(attache.ToString() == "")
            {

            }
            else
            {
                TD.Text = "<i class='fa fa-file-o' ></i>";
            }
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;cursor:pointer;";
            TD.Attributes.Add("Onclick", "go('" + id + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 200;
            TD.Height = 30;
            try
            {
                TD.Text = title.Substring(0, 20) + "...";
            }
            catch
            {
                TD.Text = title.ToString();
            }
            
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;cursor:pointer;";
            TD.Attributes.Add("Onclick", "go('" + id + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 60;
            TD.Text = date.ToString("MM-dd (ddd)");
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;cursor:pointer;";
            //TD.Attributes.Add("Onclick", "go('" + id + "')");
            TR.Cells.Add(TD);



            a++;
            TBLLIST.Rows.Add(TR);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
            if (Request.QueryString["nowpage"] != null)
            {
                Response.Redirect("mail_view.aspx?no=" + HiddenField1.Value + "&nowpage=" + Request["nowpage"].ToString()+"&flag=list_view");
            }
            else
            {
                Response.Redirect("mail_view.aspx?no=" + HiddenField1.Value + "&flag=list_view");
            }



        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("mail_write.aspx");
        }
        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("mail_list.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("mail_list.aspx?nowpage=" + 1 + "&search=" + Search.Text +"&dropdown=" + DropDownList1.SelectedValue);
        }
    }
}
    
