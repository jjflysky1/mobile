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

namespace mobile1.Work
{
    public partial class Work : System.Web.UI.Page
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            bool ismobile = false;
            int screenwidth = Request.Browser.ScreenPixelsWidth; //Always returns 640 ?
            if (Request.Browser.IsMobileDevice == true) { ismobile = true; } //Doesn't detect mobile device ?

            if (ismobile)
            {
                //Show controls for mobile
                //excelbutton.Visible = false;
            }
            else
            {
                //Show controls for computer
                //excelbutton.Visible = true;
            }

            if (DropDownList3.SelectedValue == "기타")
            {
                TextBox4.Visible = true;
            }
            else
            {
                TextBox4.Visible = false;
            }

            if (!Page.IsPostBack)
            {
                if (DropDownList3.SelectedValue == "기타")
                {
                    TextBox4.Visible = true;
                }
                else
                {
                    TextBox4.Visible = false;
                }


                Search.Text = Request["search"];
              
              
                DropDownList1.SelectedValue = Request["type"];
                startdate.Text = Request["startdate"];
                enddate.Text = Request["enddate"];
                HiddenField4.Value = Request["HiddenField4"];
            
                DropDownList2.SelectedValue = Request["type2"];
                if (enddate.Text == "")
                {
                    //startdate.Text = DateTime.Now.AddDays(-365).ToString("yyyy-MM-dd");
                }
                else
                {

                }
                if (enddate.Text == "")
                {
                    enddate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                }
                else
                {

                }
            }
            else
            {

            }

            UISET();
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
            TD.Text = "번호";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "순번";
            TD.Attributes["style"] = "text-align : center";
            //TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "고객사";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "제품번호";
            TD.Attributes["style"] = "text-align : center";
            //TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 40;
            TD.Text = "고객사 담당자";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "등록 날짜";
            //TD.Font.Underline = true;
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; ";
            TD.Attributes.Add("Onclick", "go3('indate')");
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "담당 엔지니어";
            //TD.Font.Underline = true;
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            TD.Attributes.Add("Onclick", "go3('outdate')");
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "이력 수정자";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            TR.Cells.Add(TD);


            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "구분";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "작업 시간";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "이력 상세";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            TR.Cells.Add(TD);


            TBLLIST.Rows.Add(TR);


            TBLLOAD();
        }
        private void PAGEADD(int pagecount, int nowpage)
        {
            StringBuilder SB = new StringBuilder();

            SB.Append("<ul class='pagination pagination-sm no-margin'>");
            SB.Append("<li>" + "<a href='work.aspx?nowpage=" + 1 + " &startdate=" + startdate.Text + "&enddate=" + enddate.Text + "&search=" + Request["search"] + "&type=" + Request["type"] + "&insort="+ Request["insort"] +"&outsort="+ Request["outsort"] +"'>" + "<span aria-hidden='true'> &laquo;</span>" + "</a>" + "<li>");
            if (pagecount == 0)
            {
                SB.Append("<li> " + "<a href='work.aspx?nowpage=" + 1 + " &startdate=" + startdate.Text + "&enddate=" + enddate.Text + "&search=" + Request["search"] + "&type=" + Request["type"] + "&insort=" + Request["insort"] + "&outsort=" + Request["outsort"] + "' >" + 1 + "</a>" + " <li>");
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
            for (int i = nowlist; i <= pagecount-1; i++)
            {
                if (nowlist + 6 == i)
                {
                    break;
                }
                if (i == nowpage)
                {
                    SB.Append("<li class='page-item active'> " + "<a href='work.aspx?nowpage=" + i + " &startdate=" + startdate.Text + "&enddate=" + enddate.Text + " &search=" + Request["search"] + "&type=" + Request["type"] + "&sort=" + Request["sort"] + "&insort=" + Request["insort"] + "&outsort=" + Request["outsort"] + " '>" + i + "</a>" + " <li>");
                }
                else
                {
                    SB.Append("<li> " + "<a href='work.aspx?nowpage=" + i + " &startdate=" + startdate.Text + "&enddate=" + enddate.Text + "&search=" + Request["search"] + "&type=" + Request["type"] + "&sort="+ Request["sort"] + "&insort=" + Request["insort"] + "&outsort=" + Request["outsort"] + "'>" + i + "</a>" + " <li>");
                }
            }

            SB.Append("<li>" + "<a href='work.aspx?nowpage=" + (pagecount - 1) + " &startdate=" + startdate.Text + "&enddate=" + enddate.Text + "&search=" + Request["search"] + "&type=" + Request["type"] + "&insort=" + Request["insort"] + "&outsort=" + Request["outsort"] + "'>" + "<span aria-hidden='true'> &raquo;</span>" + "</a>" + "<li>");
            SB.Append("</ul>");



            Label2.Text = SB.ToString();
        }
        string SQL = "";
        
        private void TBLLOAD()
        {    
            //count
            SQL = "select count(company_name) as count from Customer_company ";
            int count2 = 0;
            SqlDataAdapter ADT7 = new SqlDataAdapter(SQL, DB);
            DataSet DBSET7 = new DataSet();
            ADT7.Fill(DBSET7, "BD");
            foreach (DataRow row in DBSET7.Tables["BD"].Rows)
            {
                count2 = Convert.ToInt32(row["count"].ToString());
            }

            //count
            SQL = "select count(*) as count from work ";
            int count3 = 0;
            SqlDataAdapter ADT8 = new SqlDataAdapter(SQL, DB);
            DataSet DBSET8 = new DataSet();
            ADT8.Fill(DBSET8, "BD");
            foreach (DataRow row in DBSET8.Tables["BD"].Rows)
            {
                count3 = Convert.ToInt32(row["count"].ToString());
            }


            int nowpage = Convert.ToInt32(Request["nowpage"]);
            if (nowpage == 0)
            {
                nowpage = 1;
            }
            string SQL2 = "";
            if (DropDownList1.SelectedValue == "1")
            {
                SQL2 = "select count(*) as count from work where Customer_company ='" + Search.Text + "'";
            }
            else if(DropDownList1.SelectedValue == "2")
            {
                SQL2 = "select count(*) as count from work where engineer ='" + Search.Text + "'";
            }
            else if (DropDownList1.SelectedValue == "3")
            {
                SQL2 = "select count(*) as count from work where category ='" + Search.Text + "'";
            }
            else
            {
                 SQL2 = "select count(*) as count from work";
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

            SqlDataAdapter ADT = new SqlDataAdapter("work_sp", DB);
            ADT.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (DropDownList1.SelectedValue == "1")
            {
                ADT.SelectCommand.Parameters.AddWithValue("@search", "where Customer_company like '%" + Search.Text + "%' and  CONVERT(CHAR(10), date, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "'");
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                ADT.SelectCommand.Parameters.AddWithValue("@search", "where engineer like '%" + Search.Text + "%' and  CONVERT(CHAR(10), date, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "'");
            }
            else if (DropDownList1.SelectedValue == "3")
            {
                ADT.SelectCommand.Parameters.AddWithValue("@search", "where category like '%" + Search.Text + "%' and  CONVERT(CHAR(10), date, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "'");
            }
            else
            {
                ADT.SelectCommand.Parameters.AddWithValue("@search", " where  CONVERT(CHAR(10), date, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by no desc");
            }
            ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end);
            startno.Value = start.ToString();
            endno.Value = end.ToString();
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                TBLADD(row["Customer_company"].ToString(), row["Customer_person"].ToString(), row["engineer"].ToString(),
                        row["date"].ToString(), row["history"].ToString(), row["create_user"].ToString(), row["no"].ToString(), row["tempno"].ToString(),
                        row["modi_user"].ToString(), row["category"].ToString(),row["Customer_request"].ToString(),row["start_time"].ToString(),
                        row["end_time"].ToString(),count3);
                count3--;
            }

       


            string company_name = "";
            SQL = "select distinct * from customer_company order by no desc";
            SqlDataAdapter ADT6 = new SqlDataAdapter(SQL, DB);
            DataSet DBSET6 = new DataSet();
            ADT6.Fill(DBSET6, "BD");
            foreach (DataRow row in DBSET6.Tables["BD"].Rows)
            {
                company_name = row["company_name"].ToString();
                
                if (DropDownList3.Items.Count <= Convert.ToInt32(count2 + 1))
                {
                    DropDownList3.Items.Add(company_name.ToString());
                }
                //DropDownList3.SelectedIndexChanged += work2;
            }
            DropDownList3.Items.Add("기타");


        }
        //protected void work2(object sender, EventArgs e)
        //{
        //    from.Text = DropDownList2.SelectedValue;
        //}
        long a = 1;
        private void TBLADD(string Customer_company, string Customer_person, string engineer, string date, string history, string create_user,
            string no, string tempno, string modi_user, string category, string Customer_request, string start_time, string end_time, int count)
        {
            TableRow TR;
            TableCell TD;


            TR = new TableRow();
            TR.Font.Size = 10;
            
            TD = new TableCell();
            TD.Width = 10;
            TD.Text = count.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 60;
            TD.Text = Customer_company.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
            TR.Cells.Add(TD);


            TD = new TableCell();
            TD.Width = 40;
            TD.Text = Customer_person.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
            TR.Cells.Add(TD);

            DateTime date1 = Convert.ToDateTime(date.ToString());
            TD = new TableCell();
            TD.Width = 60;
            TD.Text = date1.ToString("yy-MM-dd (ddd) HH:mm");
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
            TR.Cells.Add(TD);


            TD = new TableCell();
            TD.Width = 40;
            TD.Text = create_user.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 40;
            TD.Text = modi_user.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
            TR.Cells.Add(TD);

            if(category.ToString() == "장애처리")
            {
                TD = new TableCell();
                TD.Width = 40;
                TD.Text = category.ToString();
                TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer; background-color:lightseagreen;";
                TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
                TR.Cells.Add(TD);
            }
            else if(category.ToString() =="기술지원")
            {
                TD = new TableCell();
                TD.Width = 40;
                TD.Text = category.ToString();
                TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer; background-color:coral;";
                TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
                TR.Cells.Add(TD);
            }
            else if(category.ToString() =="정기점검")
            {
                TD = new TableCell();
                TD.Width = 40;
                TD.Text = category.ToString();
                TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer; background-color:khaki;";
                TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
                TR.Cells.Add(TD);
            }
            else if (category.ToString() == "장비설치")
            {
                TD = new TableCell();
                TD.Width = 40;
                TD.Text = category.ToString();
                TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer; background-color:gold;";
                TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
                TR.Cells.Add(TD);
            }
            else
            {
                TD = new TableCell();
                TD.Width = 40;
                TD.Text = category.ToString();
                TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer; ";
                TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
                TR.Cells.Add(TD);
            }

            TD = new TableCell();
            TD.Width = 40;
            TD.Text = start_time.ToString() + " ~ " + end_time.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer; ";
            TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
            TR.Cells.Add(TD);


            TD = new TableCell();
            TD.Width = 10;
            TD.Text = "상세";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Font.Underline = true;
            TD.Attributes.Add("Onclick", "view('" + tempno.ToString() + "')");
            TR.Cells.Add(TD);

            a++;
            TBLLIST.Rows.Add(TR);
            TBLADD2(tempno, history,create_user, modi_user, Customer_request);

        }
        private void TBLADD2(string tempno, string history, string create_user, string modi_user , string Customer_request)
        {
            TableRow TR;
            TableCell TD;

            TR = new TableRow();
            TR.Font.Size = 10;
            TR.ID = tempno;
            TR.Attributes["class"] = "";
            TR.Attributes["style"] = "display:none;  border:0px;";


            history = history.Replace("\r\n", "<br>");
            Customer_request = Customer_request.Replace("\r\n", "<br>");

            TD = new TableCell();
            TD.Text = "<b>내  용 :</b> " + history +"<br>" +
                      "<b>고객요청사항 :</b> " + Customer_request;


            TD.ColumnSpan = 9;
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer";
            TR.Cells.Add(TD);


            TBLLIST.Rows.Add(TR);
        }


        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("notice.aspx?nowpage=" + 1 + "&search=" + Search.Text + "&type1=" + DropDownList1.SelectedValue + "&type2=" + DropDownList2.SelectedValue);
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
          

            string SQL = "select * from user_ba where id = '" + Request.Cookies["ID"].Value + "'";
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            string name = "";
            string pwd = "";
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                name = row["name"].ToString();
                pwd = row["pwd"].ToString();
            }

            DB.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DB;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into work (Customer_company,Customer_person,engineer,date,history,create_user) " +
                "select @Customer_company, @Customer_person , @engineer , getdate() ,@history ,@create_user";
            if(TextBox4.Visible == true)
            {
                cmd.Parameters.Add("@Customer_company", SqlDbType.NVarChar, 100).Value = TextBox4.Text;
            }
            else
            {
                cmd.Parameters.Add("@Customer_company", SqlDbType.NVarChar, 100).Value = DropDownList3.SelectedValue;
            }
            cmd.Parameters.Add("@Customer_person", SqlDbType.NVarChar, 100).Value = TextBox2.Text;
            cmd.Parameters.Add("@engineer", SqlDbType.NVarChar, 100).Value = name;
            cmd.Parameters.Add("@history", SqlDbType.NVarChar, 100).Value = TextBox3.Text;
            cmd.Parameters.Add("@create_user", SqlDbType.NVarChar, 100).Value = name;
            cmd.ExecuteNonQuery();
            DB.Close();
            cmd.Dispose();
            cmd = null;

            Response.Redirect("work.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(Request.QueryString["nowpage"] == null)
            {
                Response.Redirect("Work_detail.aspx?no=" + HiddenField1.Value + "&flag=" + HiddenField2.Value+"&search="+ Request["search"]  + "&type="+ Request["type"]);
            }
            else
            {
                Response.Redirect("Work_detail.aspx?no=" + HiddenField1.Value + "&flag=" + HiddenField2.Value + "&nowpage=" + Request["nowpage"].ToString()+ "&search=" + Request["search"] + "&type=" + Request["type"]);
            }
            
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("work.aspx");
        }

        protected void Unnamed_ServerClick1(object sender, EventArgs e)
        {

            int nowpage = Convert.ToInt32(Request["nowpage"]);
            if (nowpage == 0)
            {
                nowpage = 1;
            }

            string SQL2 = "select count(*) as count from work where  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' ";

            if (DropDownList1.SelectedValue == "3")
            {
                SQL2 = "select count(*) as count from work where to_location like '%" + Search.Text + "%' and CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' ";
            }
            if (DropDownList1.SelectedValue == "4")
            {
                SQL2 = "select count(*) as count from work where product like '%" + Search.Text + "%' and CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' ";

            }
            if (DropDownList1.SelectedValue == "5")
            {
                SQL2 = "select count(*) as count from work where serial like '%" + Search.Text + "%' and CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' ";

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

            SqlDataAdapter ADT = new SqlDataAdapter("work_sp", DB);
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
                if (Search.Text == "null")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where to_location is null");
                }
                else if (Request.QueryString["insort"] == "insort")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where outdate is null and product like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");

                }
                else if (Request.QueryString["outsort"] == "outsort")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where outdate is not null and product like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");

                }
                else
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where to_location like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");
                }
                ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end * pagecount);
            }
            else if (DropDownList1.SelectedValue == "4")
            {
                if (Search.Text == "null")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where product is null");
                }
                else if (Request.QueryString["insort"] == "insort")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where outdate is null and product like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");

                }
                else if (Request.QueryString["outsort"] == "outsort")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where outdate is not null and product like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");

                }
                else
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where product like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");
                }
                ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end * pagecount);

            }
            else if (DropDownList1.SelectedValue == "5")
            {
                if (Search.Text == "null")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where serial is null");
                }
                else if (Request.QueryString["insort"] == "insort")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where outdate is null and product like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");

                }
                else if (Request.QueryString["outsort"] == "outsort")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where outdate is not null and product like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");

                }
                else
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where serial like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");
                }
                ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end * pagecount);
            }
            else
            {
                if (Request.QueryString["sort"] == "outdate")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", " where  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by outdate desc");
                    
                }
                else if (Request.QueryString["insort"] == "insort")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where outdate is null and product like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");

                }
                else if (Request.QueryString["outsort"] == "outsort")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where outdate is not null and product like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");

                }
                else
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", " where  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");
                }
                ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end * pagecount);
            }
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");

            HttpResponse objResponse = HttpContext.Current.Response;

            objResponse.ClearContent();
            objResponse.ClearHeaders();
            objResponse.ContentType = "application/vnd.msexcel";
            objResponse.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode(System.DateTime.Now.ToString("yyyy-MM-dd") + "리스트") + ".csv");
            objResponse.Charset = "euc-kr";
            objResponse.ContentEncoding = Encoding.GetEncoding(949);
            string sep = "";


            sep = ",";
            Response.Write("번호");
            Response.Write(sep + "상품 명");
            Response.Write(sep + "상품 코드");
            Response.Write(sep + "입고 처");
            Response.Write(sep + "입고 시간");
            Response.Write(sep + "반출 처");
            Response.Write(sep + "반출 시간");
            Response.Write(sep + "반출 자");
            Response.Write(sep + "수량");
            sep = "\n";
            Response.Write(sep);

            int a = 1;
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                sep = ",";
                Response.Write(a);
                Response.Write(sep + row["product"].ToString());
                Response.Write(sep + row["serial"].ToString());
                Response.Write(sep + row["from_location"].ToString());
                Response.Write(sep + row["indate"].ToString());
                Response.Write(sep + row["to_location"].ToString());
                Response.Write(sep + row["outdate"].ToString());
                Response.Write(sep + row["out_user"].ToString());
                Response.Write(sep + row["qty"].ToString());

                sep = "\n";
                Response.Write(sep);
                a++;
            }



            Response.End();
            objResponse.Flush();
            objResponse.Close();
            objResponse.End();


            //StringBuilder sb = new StringBuilder();

            //IEnumerable<string> columnNames = DBSET.Tables["BD"].Columns.Cast<DataColumn>().
            //                                  Select(column => column.ColumnName);
            //sb.AppendLine(string.Join(",", columnNames));

            //foreach (DataRow row in DBSET.Tables["BD"].Rows)
            //{
            //    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
            //    sb.AppendLine(string.Join(",", fields));
            //}

            //string body = Encoding.GetEncoding("EUC-KR").GetString(Encoding.GetEncoding("ISO-8859-1").GetBytes(sb.ToString()));

            //File.WriteAllText(@"C:\\mobile\\Mail_attach\\" + System.DateTime.Now.ToString("yyyy-MM-dd") + "리스트" + ".csv", body);




            //WebClient webClient = new WebClient();
            //webClient.DownloadFile("http://27.117.167.22:86/Mail_attach/" + System.DateTime.Now.ToString("yyyy-MM-dd") + "리스트.csv",
            //    @"C:\test\" + System.DateTime.Now.ToString("yyyy-MM-dd") + "리스트.csv");
            //Response.Redirect();
            ////webClient.DownloadFile("http://27.117.167.22:86/Mail_attach/2019-03-13리스트.csv", System.DateTime.Now.ToString("yyyy-MM-dd") + "리스트.csv");

        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            if (HiddenField4.Value == "" || HiddenField4.Value == "0")
            {
                Response.Redirect("work.aspx?sort=" + HiddenField1.Value + "&insort=" + Request["insort"] + "&outsort=" + Request["outsort"] + "&HiddenField4=1");
            }
            else
            {
                Response.Redirect("work.aspx?sort=" + HiddenField1.Value + "&insort=" + Request["insort"] + "&outsort=" + Request["outsort"] + "&HiddenField4=0");
            }
            
        }

        protected void Button1_ServerClick(object sender, EventArgs e)
        {

        }

        protected void Button5_ServerClick(object sender, EventArgs e)
        {
          

            Response.Redirect("work.aspx?nowpage=" + 1 + "&search=" + Search.Text + "&type=" + DropDownList1.SelectedValue + "&type2=" + DropDownList2.SelectedValue 
                + "&insort=insort");
            
        }

        protected void Button6_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("work.aspx?nowpage=" + 1 + "&search=" + Search.Text + "&type=" + DropDownList1.SelectedValue + "&type2=" + DropDownList2.SelectedValue
              + "&outsort=outsort");
        }

        protected void Button3_Click2(object sender, EventArgs e)
        {
            
                Response.Redirect("work.aspx?nowpage=" + 1 + "&search=" + Search.Text + "&type=" + DropDownList1.SelectedValue + "&startdate=" + startdate.Text + "&enddate=" + enddate.Text);
            
        }
    }
}

