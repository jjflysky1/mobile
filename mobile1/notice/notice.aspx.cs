using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI.WebControls;

namespace mobile1.notice
{
    public partial class notice : System.Web.UI.Page
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            UISET();
        }
        private void UISET()
        {
            TBLSET();
        }
        private void PAGEADD(int pagecount, int nowpage)
        {
            StringBuilder SB = new StringBuilder();

            SB.Append("<ul class='pagination pagination-sm no-margin'>");
            SB.Append("<li>" + "<a href='notice.aspx?nowpage=" + 1 + "'>" + "<span aria-hidden='true'> &laquo;</span>" + "</a>" + "<li>");
            if (pagecount == 0)
            {
                SB.Append("<li> " + "<a href='notice.aspx?nowpage=" + 1 + "&search=" + Search.Text + "&type1=" + DropDownList1.SelectedValue + "&type2=" + DropDownList2.SelectedValue + "'>" + 1 + "</a>" + " <li>");
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
                if (nowlist + 6 == i)
                {
                    break;
                }
                if (i == nowpage)
                {
                    SB.Append("<li class='page-item active'> " + "<a href='notice.aspx?nowpage=" + i + "&search=" + Search.Text + "&type1=" + DropDownList1.SelectedValue + "&type2=" + DropDownList2.SelectedValue + "'>" + i + "</a>" + " <li>");
                }
                else
                {
                    SB.Append("<li> " + "<a href='notice.aspx?nowpage=" + i + "&search=" + Search.Text + "&type1=" + DropDownList1.SelectedValue + "&type2=" + DropDownList2.SelectedValue + "'>" + i + "</a>" + " <li>");
                }
            }

            SB.Append("<li>" + "<a href='notice.aspx?nowpage=" + (pagecount - 1) + "'>" + "<span aria-hidden='true'> &raquo;</span>" + "</a>" + "<li>");
            SB.Append("</ul>");



            Label2.Text = SB.ToString();
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
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "제목";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "내용";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "글쓴이";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "날짜";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "삭제";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);


            TBLLIST.Rows.Add(TR);


            TBLLOAD();
        }
        string SQL = "";
        private void TBLLOAD()
        {
            int nowpage = Convert.ToInt32(Request["nowpage"]);
            if (nowpage == 0)
            {
                nowpage = 1;
            }

            string SQL2 = "select count(*) as count from notice ";

            if (DropDownList1.SelectedValue == "4")
            {
                SQL2 = "select count(distinct serverip) as count from service where serverip like '%" + Search.Text + "%'";

            }
            if (DropDownList1.SelectedValue == "5")
            {
                SQL2 = "select count(distinct serverip) as count from service where category like '%" + Search.Text + "%'";

            }
            DB.Close();
            DB.Open();
            SqlCommand comm = new SqlCommand(SQL2, DB);
            Int32 count = (Int32)comm.ExecuteScalar();

            DB.Close();
            int pagenum = Convert.ToInt32(DropDownList2.SelectedValue);
            int pagecount = count / pagenum + 1;

            if (count / pagenum > 0)
            {
                pagecount++;
            }


            int start = ((nowpage - 1) * pagenum) + 1;
            int end = nowpage * pagenum;
            PAGEADD(pagecount, nowpage);

            SqlDataAdapter ADT = new SqlDataAdapter("notice_list", DB);
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
            }
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                TBLADD(row["title"].ToString(), row["body"].ToString(), row["create_date"].ToString(),
                     row["writer"].ToString(), row["no"].ToString());

            }
        }
        long a = 1;
        private void TBLADD(string title, string body, string create_date, string writer, string no)
        {
            TableRow TR;
            TableCell TD;


            TR = new TableRow();
            TR.Font.Size = 10;

            TD = new TableCell();
            TD.Width = 10;
            TD.Text = a.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;cursor:pointer;";
            TD.Attributes.Add("Onclick", "go('" + no.ToString() + "', '" + writer.ToString() + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 60;
            TD.Text = title.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;cursor:pointer;";
            TD.Attributes.Add("Onclick", "go('" + no.ToString() + "', '" + writer.ToString() + "')");
            TR.Cells.Add(TD);



            TD = new TableCell();
            TD.Width = 60;
            if (body.Length > 10)
            {
                TD.Text = body.Substring(0, 10) + ".....";
            }
            else
            {
                TD.Text = body.ToString();
            }
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;cursor:pointer;";
            TD.Attributes.Add("Onclick", "go('" + no.ToString() + "', '" + writer.ToString() + "')");
            TR.Cells.Add(TD);


            TD = new TableCell();
            TD.Width = 60;
            TD.Text = writer.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;cursor:pointer;";
            TD.Attributes.Add("Onclick", "go('" + no.ToString() + "', '" + writer.ToString() + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 60;
            TD.Text = create_date.ToString().Substring(0, 10);
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;cursor:pointer;";
            TD.Attributes.Add("Onclick", "go('" + no.ToString() + "', '" + writer.ToString() + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 60;
            TD.Text = "<asp:button type='button' class='btn btn- btn-middle'  runat='server'><span class='glyphicon glyphicon-remove-circle'></span> 삭제</button>";
            TD.Attributes["style"] = "text-align : center;  vertical-align:middle;";
            TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "')");
            TR.Cells.Add(TD);

            a++;
            TBLLIST.Rows.Add(TR);

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("notice.aspx?nowpage=" + 1 + "&search=" + Search.Text + "&type1=" + DropDownList1.SelectedValue + "");
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("notice.aspx?nowpage=" + 1 + "&search=" + Search.Text + "&type1=" + DropDownList1.SelectedValue + "&type2=" + DropDownList2.SelectedValue);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("notice_writer.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("notice_writer.aspx?no=" + HiddenField1.Value + "&writer=" + HiddenField2.Value);
        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            //serverKey - Key from Firebase cloud messaging server  
            tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAukYEuxs:APA91bERLOVuHKqXeBN-G4wh23FgskupNJDDYxRxgMQA1LfgUx0cN7Z93Yukv3il7Rgfyi7xuvJxl-Bb0AjneX69OMRuqTqm8rUs9P7Pqt0Asmt3S68LjwGfwq5m9E5T7mwzwETIuVAe"));
            //Sender Id - From firebase project setting  
            tRequest.Headers.Add(string.Format("Sender: id={0}", "800038632219"));
            tRequest.ContentType = "application/json";
            var payload = new
            {
                to = "cJsJTF0t6JQ:APA91bE5z-3Oh3leR-XwGWHcm-4Z1mIwB4K_xdd6H7YONHdXXcY_Xfkwg4BNB82csDBMBG145oE0B1qE2NOKCJFiLGBnZ4SzwcL7sL-n6zoOGArZmNWlaM5A-_RvOBgxfOsDcKxIXnfM",
                priority = "high",
                content_available = true,
                notification = new
                {
                    title = "공지가",
                    body = "등록",
                    badge = 1
                },
            };

            string postbody = JsonConvert.SerializeObject(payload).ToString();
            Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
            tRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                //result.Response = sResponseFromServer;
                            }
                    }
                }
            }

            //string res = SendNotification("cJsJTF0t6JQ:APA91bE5z-3Oh3leR-XwGWHcm-4Z1mIwB4K_xdd6H7YONHdXXcY_Xfkwg4BNB82csDBMBG145oE0B1qE2NOKCJFiLGBnZ4SzwcL7sL-n6zoOGArZmNWlaM5A-_RvOBgxfOsDcKxIXnfM", "134134134");
        }
        public string SendNotification(string deviceId, string message)
        {
            string SERVER_API_KEY = "AAAAukYEuxs:APA91bERLOVuHKqXeBN-G4wh23FgskupNJDDYxRxgMQA1LfgUx0cN7Z93Yukv3il7Rgfyi7xuvJxl-Bb0AjneX69OMRuqTqm8rUs9P7Pqt0Asmt3S68LjwGfwq5m9E5T7mwzwETIuVAe";

            var value = message;
            string resultStr = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            request.Method = "POST";
            request.ContentType = "application/json;charset=utf-8;";
            request.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));

            var postData =
            new
            {
                data = new
                {
                    title = "공지가",
                    body = message,
                },

                // FCM allows 1000 connections in parallel.
                to = deviceId
            };

            //Linq to json
            string contentMsg = JsonConvert.SerializeObject(postData);
            Debug.WriteLine("contentMsg = " + contentMsg);

            Byte[] byteArray = Encoding.UTF8.GetBytes(contentMsg);
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            try
            {
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                resultStr = reader.ReadToEnd();
                Debug.WriteLine("response: " + resultStr);
                reader.Close();
                responseStream.Close();
                response.Close();
            }
            catch (Exception e)
            {
                resultStr = "";
                Debug.WriteLine(e.Message);
            }

            return resultStr;

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            int nowpage = Convert.ToInt32(Request["nowpage"]);
            DB.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DB;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update notice set  flag = '0',  modiuser = '" + Request.Cookies["ID"].Value + "' where no = @no";
            cmd.Parameters.Add("@no", SqlDbType.NVarChar, 100).Value = HiddenField3.Value;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            DB.Close();

            Response.Redirect("notice.aspx?nowpage=" + nowpage);
        }
    }
}
