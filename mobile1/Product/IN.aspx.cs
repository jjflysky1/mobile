using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mobile1.Product
{
    public partial class IN : System.Web.UI.Page
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
                excelbutton.Visible = false;
            }
            else
            {
                //Show controls for computer
                excelbutton.Visible = true;
            }
            if (!Page.IsPostBack)
            {

                if (Request["type"] == "3")
                {
                    Search.Text = Request["search"];
                }
                else
                {
                    Search.Text = Server.UrlEncode(Request["search"]);
                }
                DropDownList1.SelectedValue = Request["type"];
                startdate.Text = Request["startdate"];
                enddate.Text = Request["enddate"];
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
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "순번";
            TD.Attributes["style"] = "text-align : center";
            //TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "제품";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "제품번호";
            TD.Attributes["style"] = "text-align : center";
            //TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 40;
            TD.Text = "수량";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "반입 일";
            TD.Font.Underline = true;
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go3('indate')");
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "출고 일";
            TD.Font.Underline = true;
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go3('outdate')");
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "상태";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);


            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "상세";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);


            TBLLIST.Rows.Add(TR);


            TBLLOAD();
        }
        private void PAGEADD(int pagecount, int nowpage)
        {
            StringBuilder SB = new StringBuilder();

            SB.Append("<ul class='pagination pagination-sm no-margin'>");
            SB.Append("<li>" + "<a href='in.aspx?nowpage=" + 1 + " &startdate=" + startdate.Text + "&enddate=" + enddate.Text + "&search=" + Request["search"] + "&type=" + Request["type"] + "&insort=" + Request["insort"] + "&outsort=" + Request["outsort"] + "'>" + "<span aria-hidden='true'> &laquo;</span>" + "</a>" + "<li>");
            if (pagecount == 0)
            {
                SB.Append("<li> " + "<a href='in.aspx?nowpage=" + 1 + " &startdate=" + startdate.Text + "&enddate=" + enddate.Text + "&search=" + Request["search"] + "&type=" + Request["type"] + "&insort=" + Request["insort"] + "&outsort=" + Request["outsort"] + "'>" + 1 + "</a>" + " <li>");
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
            for (int i = nowlist; i <= pagecount - 1; i++)
            {
                if (nowlist + 6 == i)
                {
                    break;
                }
                if (i == nowpage)
                {
                    SB.Append("<li class='page-item active'> " + "<a href='in.aspx?nowpage=" + i + " &startdate=" + startdate.Text + "&enddate=" + enddate.Text + "&search=" + Request["search"] + "&type=" + Request["type"] + "&sort=" + Request["sort"] + "&insort=" + Request["insort"] + "&outsort=" + Request["outsort"] + "'>" + i + "</a>" + " <li>");
                }
                else
                {
                    SB.Append("<li> " + "<a href='in.aspx?nowpage=" + i + " &startdate=" + startdate.Text + "&enddate=" + enddate.Text + "&search=" + Request["search"] + "&type=" + Request["type"] + "&sort=" + Request["sort"] + "&insort=" + Request["insort"] + "&outsort=" + Request["outsort"] + "'>" + i + "</a>" + " <li>");
                }
            }

            SB.Append("<li>" + "<a href='in.aspx?nowpage=" + (pagecount - 1) + " &startdate=" + startdate.Text + "&enddate=" + enddate.Text + "&search=" + Request["search"] + "&type=" + Request["type"] + "&insort=" + Request["insort"] + "&outsort=" + Request["outsort"] + "'>" + "<span aria-hidden='true'> &raquo;</span>" + "</a>" + "<li>");
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

            string SQL2 = "select count(*) as count from product_mine where  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' ";
            if (DropDownList1.SelectedValue == "3")
            {
                SQL2 = "select count(*) as count from Product_sell where to_location like '%" + Search.Text + "%' and CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' ";
            }
            if (DropDownList1.SelectedValue == "4")
            {
                SQL2 = "select count(distinct product) as count from product_mine where product like '%" + Search.Text + "%' and CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' ";

            }
            if (DropDownList1.SelectedValue == "5")
            {
                SQL2 = "select count(distinct product) as count from product_mine where serial like '%" + Search.Text + "%' and CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' ";

            }
            if (Request.QueryString["insort"] == "insort")
            {
                SQL2 = "select count(*) as count from product_mine where outdate is null and serial like '%" + Search.Text + "%' and CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' ";

            }
            if (Request.QueryString["outsort"] == "outsort")
            {
                SQL2 = "select count(*) as count from product_mine where outdate is not null and serial like '%" + Search.Text + "%' and CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' ";

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

            SqlDataAdapter ADT = new SqlDataAdapter("product_mine_sp", DB);
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
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where outdate is null and to_location like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");

                }
                else if (Request.QueryString["outsort"] == "outsort")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where outdate is not null and to_location like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");

                }
                else
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where to_location like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");
                }
                ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end);
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
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where product like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "'");
                }
                ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end);

            }
            else if (DropDownList1.SelectedValue == "5")
            {
                if (Search.Text == "null")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where serial is null");
                }
                else if (Request.QueryString["insort"] == "insort")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where outdate is null and serial like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");

                }
                else if (Request.QueryString["outsort"] == "outsort")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where outdate is not null and serial like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");

                }
                else
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where serial like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");
                }
                ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end);
            }
            else
            {
                if (Request.QueryString["sort"] == "outdate")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", " where  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by outdate desc");

                }
                else if (Request.QueryString["insort"] == "insort")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", " where  outdate is null and CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by outdate desc");

                }
                else if (Request.QueryString["outsort"] == "outsort")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", " where  outdate is not null and CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by outdate desc");

                }
                else
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", " where  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");
                }
                ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end);
            }
            startno.Value = start.ToString();
            endno.Value = end.ToString();
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            foreach (DataRow row in DBSET.Tables["BD"].Rows) 
            {
                TBLADD(row["product"].ToString(), row["serial"].ToString(), row["indate"].ToString(),
                      row["outdate"].ToString(), row["up_user"].ToString(), row["qty"].ToString(), row["no"].ToString(), row["tempno"].ToString(),
                      row["from_location"].ToString(), row["to_location"].ToString(), row["out_user"].ToString());

            }
          

        }
        long a = 1;
        private void TBLADD(string product, string serial, string indate, string outdate, string up_user, string qty, string no, string tempno, string from_location, string to_location, string out_user)
        {
            TableRow TR;
            TableCell TD;


            TR = new TableRow();
            TR.Font.Size = 10;

            TD = new TableCell();
            TD.Width = 10;
            TD.Text = tempno.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "IN" + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 60;
            TD.Text = product.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "IN" + "')");
            TR.Cells.Add(TD);



            TD = new TableCell();
            TD.Width = 60;
            if (serial.Length > 10)
            {
                TD.Text = serial.Substring(0, 10) + ".....";
            }
            else
            {
                TD.Text = serial.ToString();
            }
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            //TR.Cells.Add(TD);


            TD = new TableCell();
            TD.Width = 40;
            TD.Text = qty.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "IN" + "')");
            TR.Cells.Add(TD);

            DateTime date = Convert.ToDateTime(indate.ToString());
            TD = new TableCell();
            TD.Width = 60;
            TD.Text = date.ToString("yy-MM-dd (ddd) HH:mm");
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "IN" + "')");
            TR.Cells.Add(TD);

            DateTime date2 = DateTime.Now;
            if (outdate.ToString().Length > 1)
            {
                date2 = Convert.ToDateTime(outdate.ToString());
            }
            TD = new TableCell();
            TD.Width = 60;
            if (outdate.ToString().Length > 1)
            {
                TD.Text = date2.ToString("yy-MM-dd (ddd) HH:mm");
            }
            else
            {
                TD.Text = outdate.ToString();
            }

            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "IN" + "')");
            TR.Cells.Add(TD);

            if (outdate.ToString().Length == 0)
            {
                TD = new TableCell();
                TD.Width = 60;
                TD.Text = "재고";
                TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer; background-color:lightseagreen; ";
                TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "IN" + "')");
                TR.Cells.Add(TD);

            }
            else
            {
                TD = new TableCell();
                TD.Width = 60;
                TD.Text = "반출";
                TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer; background-color:lightcoral;";
                TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "IN" + "')");
                TR.Cells.Add(TD);
            }

            TD = new TableCell();
            TD.Width = 10;
            TD.Text = "상세";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Font.Underline = true;
            TD.Attributes.Add("Onclick", "view('" + tempno.ToString() + "')");
            TR.Cells.Add(TD);


            a++;
            TBLLIST.Rows.Add(TR);
            TBLADD2(tempno, serial, from_location, to_location, out_user);

        }
        private void TBLADD2(string tempno, string serial, string from_location, string to_location, string out_user)
        {
            TableRow TR;
            TableCell TD;

            TR = new TableRow();
            TR.Font.Size = 10;
            TR.ID = tempno;
            TR.Attributes["class"] = "";
            TR.Attributes["style"] = "display:none;  border:0px;";



            TD = new TableCell();
            TD.Text = "<b>제품번호 :</b> " + serial + "<br>" +
                      "<b>입고처 :</b> " + from_location + "<br>" +
                      "<b>반출처 :</b> " + to_location + "<br>" +
                      "<b>반출자 :</b> " + out_user;
            TD.ColumnSpan = 7;
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
            Response.Redirect("in.aspx?nowpage=" + 1 + "&search=" + Search.Text + "&type=" + DropDownList1.SelectedValue + "&startdate=" + startdate.Text + "&enddate=" + enddate.Text);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["nowpage"] == null)
            {
                Response.Redirect("product_detail.aspx?no=" + HiddenField1.Value + "&flag=" + HiddenField2.Value +  "&search=" + Request["search"] + "&type=" + Request["type"]);
            }
            else
            {
                Response.Redirect("product_detail.aspx?no=" + HiddenField1.Value + "&flag=" + HiddenField2.Value +  "&nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
            }
                
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("IN.aspx");
        }
        protected void Unnamed_ServerClick1(object sender, EventArgs e)
        {

            int nowpage = Convert.ToInt32(Request["nowpage"]);
            if (nowpage == 0)
            {
                nowpage = 1;
            }

            string SQL2 = "select count(*) as count from product_mine where  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' ";
            if (DropDownList1.SelectedValue == "3")
            {
                SQL2 = "select count(*) as count from Product_sell where to_location like '%" + Search.Text + "%' and CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' ";
            }
            if (DropDownList1.SelectedValue == "4")
            {
                SQL2 = "select count(distinct product) as count from product_mine where product like '%" + Search.Text + "%' and CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' ";

            }
            if (DropDownList1.SelectedValue == "5")
            {
                SQL2 = "select count(distinct product) as count from product_mine where serial like '%" + Search.Text + "%' and CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' ";

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

            SqlDataAdapter ADT = new SqlDataAdapter("product_mine_sp", DB);
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
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where outdate is null and to_location like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");

                }
                else if (Request.QueryString["outsort"] == "outsort")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where outdate is not null and to_location like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");

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
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where outdate is null and product like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "'");

                }
                else if (Request.QueryString["outsort"] == "outsort")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where outdate is not null and product like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");

                }
                else
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where product like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "'");
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
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where outdate is null and serial like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");

                }
                else if (Request.QueryString["outsort"] == "outsort")
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where outdate is not null and serial like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");

                }
                else
                {
                    ADT.SelectCommand.Parameters.AddWithValue("@search", "where serial like '%" + Search.Text + "%' and  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");
                }
                ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end * pagecount);
            }
            else
            {
                ADT.SelectCommand.Parameters.AddWithValue("@search", " where  CONVERT(CHAR(10), indate, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "' order by indate desc");
                ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end * pagecount);
            }
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");

            System.Web.HttpResponse objResponse = System.Web.HttpContext.Current.Response;

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
        }
        protected void Button3_Click1(object sender, EventArgs e)
        {
            Response.Redirect("in.aspx?sort=" + HiddenField1.Value);
        }
        protected void Button5_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("in.aspx?nowpage=" + 1 + "&search=" + Search.Text + "&type=" + DropDownList1.SelectedValue + "&type2=" + DropDownList2.SelectedValue
                + "&insort=insort");
        }

        protected void Button6_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("in.aspx?nowpage=" + 1 + "&search=" + Search.Text + "&type=" + DropDownList1.SelectedValue + "&type2=" + DropDownList2.SelectedValue
              + "&outsort=outsort");
        }
    }
}

