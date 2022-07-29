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

namespace mobile1.mail
{
    public partial class mail_list_get : System.Web.UI.Page
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            UISET();
            
        
        }
        private void mail_thread()
        {
            SmtPop.POP3Client pop = new SmtPop.POP3Client();
            pop.Open("gw.sungsimit.co.kr", 110, "jjflysky@sungsimit.co.kr", "dnjsvltm1!");

            // Get message list from POP server
            SmtPop.POPMessageId[] messages = pop.GetMailList();

            int nowpage = Convert.ToInt32(Request["nowpage"]);
            if (nowpage == 0)
            {
                nowpage = 1;
            }
            int pagenum = 10;
            int pagecount = messages.Count() / pagenum + 1;

            //int start = ((nowpage - 1) * pagenum) + 1;
            int end = messages.Count() - ((nowpage - 1) * pagenum);
            int start = end - 10;
            int a = start;
            PAGEADD(pagecount, nowpage);
            if (messages != null)
            {
                // Walk attachment list
                foreach (SmtPop.POPMessageId id in messages.Reverse())
                {
                    //if (id.Id > start && id.Id <= end)
                    //{
                    SmtPop.POPReader reader = pop.GetMailReader(id);
                    SmtPop.MimeMessage msg = new SmtPop.MimeMessage();

                    // Read message
                    msg.Read(reader);

                    String from = "";
                    if (msg.AddressFrom != null)
                    {
                        from = msg.AddressFrom[0].Name;
                        Console.WriteLine("from: " + from);
                    }
                    String subject = "";
                    if (msg.Subject != null)
                    {
                        subject = msg.Subject;
                        //Console.WriteLine("subject: " + subject);
                    }

                    //TBLADD(subject, from, msg.Headers["Date"].ToString(), id.Id);


                    DB.Open();
                    SqlCommand cmd = new SqlCommand("add_email", DB);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fromadress", from);
                    cmd.Parameters.AddWithValue("@subject", subject);
                    cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(msg.Headers["Date"].ToString()));
                    cmd.Parameters.AddWithValue("@id", id.Id);
                    cmd.Parameters.AddWithValue("@user_id", Request.Cookies["ID"].Value);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cmd = null;
                    DB.Close();



                    //}
                }
            }

            pop.Quit();
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
            for (int i = nowlist; i <= pagecount; i++)
            {
                if (nowlist + 10 == i)
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
        }
        string SQL = "";
        private void TBLLOAD()
        {
            int nowpage = Convert.ToInt32(Request["nowpage"]);
            if (nowpage == 0)
            {
                nowpage = 1;
            }

            string SQL2 = "select count(*) as count from email_list where user_id = '" + Request.Cookies["ID"].Value + "'";

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

            if (DropDownList1.SelectedValue == "1")
            {
                SQL = "select * from Service where os like '%" + Search.Text + "%' order by no desc";
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                SQL = "select * from Service where status like '%" + Search.Text + "%' order by no desc";
            }
            else if (DropDownList1.SelectedValue == "3")
            {
                SQL = "select * from Service where name like '%" + Search.Text + "%' order by no desc";
            }
            else if (DropDownList1.SelectedValue == "4")
            {
                ADT.SelectCommand.Parameters.AddWithValue("@search", "where no like '%" + Search.Text + "%'");
                ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end);

            }
            else if (DropDownList1.SelectedValue == "5")
            {
                if (Search.Text == "null")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where category is null");
                }
                else
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where category like '%" + Search.Text + "%'");
                }
                ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end);
            }
            else
            {
                ADT.SelectCommand.Parameters.AddWithValue("@search", " ");
                ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end);
                ADT.SelectCommand.Parameters.AddWithValue("@user_id", Request.Cookies["ID"].Value);
            }
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                TBLADD(row["subject"].ToString(), row["fromadress"].ToString(), row["date"].ToString(), row["id"].ToString());

            }

        }
        long a = 1;
        private void TBLADD(string title, string from, string time, string id)
        {
            TableRow TR;
            TableCell TD;
            DateTime date = Convert.ToDateTime(time.ToString());

            TR = new TableRow();
            TR.Font.Size = 11;

            TD = new TableCell();
            TD.Width = 10;
            TD.Text = a.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            //TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 60;
            TD.Text = from.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;cursor:pointer;";
            //TD.Attributes.Add("Onclick", "go('" + date.ToString("yyyyMMddHHmmss") + "')");
            TD.Attributes.Add("Onclick", "go('" + id + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 60;
            TD.Text = title.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;cursor:pointer;";
            TD.Attributes.Add("Onclick", "go('" + id + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 60;
            TD.Text = date.ToString("MM-dd (ddd)");
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;cursor:pointer;";
            TD.Attributes.Add("Onclick", "go('" + id + "')");
            TR.Cells.Add(TD);



            a++;
            TBLLIST.Rows.Add(TR);

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Service_list.aspx?nowpage=" + 1 + "&search=" + Search.Text + "&type=" + DropDownList1.SelectedValue);
        }
    }
}