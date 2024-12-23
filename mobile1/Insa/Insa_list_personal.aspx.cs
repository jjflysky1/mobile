using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mobile1.Insa
{
    public partial class Insa_list_personal : System.Web.UI.Page
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField4.Value = Request["no"];
            HiddenField3.Value = Request["dropdownlist1"];

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

            if (!Page.IsPostBack)
            {

                //Search.Text = Request["search"];
                DropDownList1.SelectedValue = Request["type"];
                //startdate.Text = Request["startdate"];
                //enddate.Text = Request["enddate"];

                DropDownList2.SelectedValue = Request["type2"];
                //if (enddate.Text == "")
                //{
                //    //startdate.Text = DateTime.Now.AddDays(-365).ToString("yyyy-MM-dd");
                //}
                //else
                //{

                //}
                //if (enddate.Text == "")
                //{
                //    enddate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                //}
                //else
                //{

                //}
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
            TD.Text = "시기";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "월 실적";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "분기 실적";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "연 실적";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "실적";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 40;
            TD.Text = "성공률";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "영업 범위";
            TD.Attributes["style"] = "text-align : center; ";
            TR.Cells.Add(TD);


            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "애사심";
            TD.Attributes["style"] = "text-align : center; ";
            TR.Cells.Add(TD);


            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "근무태도";
            TD.Attributes["style"] = "text-align : center; ";
            TR.Cells.Add(TD);

            //TD = new TableHeaderCell();
            //TD.Width = 60;
            //TD.Text = "기초적 능력";
            //TD.Attributes["style"] = "text-align : center";
            //TR.Cells.Add(TD);

            //TD = new TableHeaderCell();
            //TD.Width = 40;
            //TD.Text = "사고 능력";
            //TD.Attributes["style"] = "text-align : center";
            //TR.Cells.Add(TD);

            //TD = new TableHeaderCell();
            //TD.Width = 60;
            //TD.Text = "대인 능력";
            //TD.Attributes["style"] = "text-align : center; ";
            //TR.Cells.Add(TD);


            //TD = new TableHeaderCell();
            //TD.Width = 60;
            //TD.Text = "집무태도";
            //TD.Attributes["style"] = "text-align : center; ";
            //TR.Cells.Add(TD);


            //TD = new TableHeaderCell();
            //TD.Width = 60;
            //TD.Text = "업적";
            //TD.Attributes["style"] = "text-align : center; ";
            //TR.Cells.Add(TD);


            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "종합";
            TD.Attributes["style"] = "text-align : center; ";
            TR.Cells.Add(TD);


            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "메모";
            TD.Attributes["style"] = "text-align : center; ";
            TR.Cells.Add(TD);


            TBLLIST.Rows.Add(TR);


            TBLLOAD();
        }
        private void PAGEADD(int pagecount, int nowpage)
        {
            StringBuilder SB = new StringBuilder();

            SB.Append("<ul class='pagination pagination-sm no-margin'>");
            SB.Append("<li>" + "<a href='Insa_list_personal.aspx?nowpage=" + 1 + "&no=" + Request["no"] + "'>" + "<span aria-hidden='true'> &laquo;</span>" + "</a>" + "<li>");
            if (pagecount == 0)
            {
                SB.Append("<li> " + "<a href='Insa_list_personal.aspx?nowpage=" + 1 + "&no=" + Request["no"] + "</a>" + " <li>");
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
                    SB.Append("<li class='page-item active'> " + "<a href='Insa_list_personal.aspx?nowpage=" + i + "&no=" + Request["no"] + " '>" + i + "</a>" + " <li>");
                }
                else
                {
                    SB.Append("<li> " + "<a href='Insa_list_personal.aspx?nowpage=" + i + "&no=" + Request["no"] + "'>" + i + "</a>" + " <li>");
                }
            }

            SB.Append("<li>" + "<a href='Insa_list_personal.aspx?nowpage=" + (pagecount - 1) + "&no=" + Request["no"] + "'>" + "<span aria-hidden='true'> &raquo;</span>" + "</a>" + "<li>");
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
            string SQL2 = "select count(*) as count from insa_report where id_no = '" + Request["no"] + "'";
            if (Request.QueryString["dropdownlist1"] == null)
            {
                SQL2 = "select count(*) as count from insa_report where id_no = '" + Request["no"] + "'";
            }
            else
            {
                SQL2 = "select count(*) as count from insa_report where left(date,4)  = '" + Request["dropdownlist1"] + "' and  id_no = '" + Request["no"] + "'";
            }



            DB.Close();
            DB.Open();
            SqlCommand comm = new SqlCommand(SQL2, DB);
            Int32 count = (Int32)comm.ExecuteScalar();
            DB.Close();
            //int pagenum = Convert.ToInt32(DropDownList2.SelectedValue);
            int pagenum = 12;
            int pagecount = count / pagenum + 1;
            if (count / pagenum > 0)
            {
                pagecount++;
            }


            int start = ((nowpage - 1) * pagenum) + 1;
            int end = nowpage * pagenum;
            PAGEADD(pagecount, nowpage);

            startno.Value = start.ToString();
            endno.Value = end.ToString();



            //if(Request.QueryString["dropdownlist1"] == null)
            //{
            //    SQL2 = "select a.* , b.duty_name from insa_report a , user_V b where  id_no = '" + Request["no"] + "' and a.id_no = b.no order by date desc";
            //}
            //else
            //{
            //    SQL2 = "select a.* , b.duty_name from insa_report a , user_V b where left(date,4)  = '"+ Request["dropdownlist1"] + "'  and id_no = '" + Request["no"] + "' and a.id_no = b.no order by date desc";
            //}

            SqlDataAdapter ADT = new SqlDataAdapter("insa_personal_list_sp", DB);
            ADT.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Request.QueryString["dropdownlist1"] == null)
            {
                ADT.SelectCommand.Parameters.AddWithValue("@search", "where  id_no = '" + Request["no"] + "' and a.id_no = b.no order by date desc");
            }
            else
            {
                ADT.SelectCommand.Parameters.AddWithValue("@search", "where left(date,4)  = '" + Request["dropdownlist1"] + "'  and id_no = '" + Request["no"] + "' and a.id_no = b.no order by date desc");
            }


            ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end);
            //SqlDataAdapter ADT = new SqlDataAdapter(SQL2, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                TBLADD(row["name"].ToString(), row["duty_name"].ToString(), row["date"].ToString(), row["Q1"].ToString(), row["Q2"].ToString(), row["Q3"].ToString(), row["Q4"].ToString(), row["Q5"].ToString()
                    , row["total"].ToString(), row["memo"].ToString(), row["id_no"].ToString(), row["month_1"].ToString(), row["month_2"].ToString()
                    , row["half_1"].ToString(), row["half_2"].ToString(), row["year_1"].ToString(), row["year_2"].ToString());

            }
            string SQL1 = "select distinct left(date,4) as date from insa_report where id_no = '" + Request["no"] + "'  order by date desc";
            SqlDataAdapter ADT1 = new SqlDataAdapter(SQL1, DB);
            DataSet DBSET1 = new DataSet();
            ADT1.Fill(DBSET1, "BD");
            foreach (DataRow row in DBSET1.Tables["BD"].Rows)
            {
                DropDownList1.Items.Add(row["date"].ToString());
            }


        }
        long a = 1;
        private void TBLADD(string name, string duty_name, string date, string Q1, string Q2, string Q3, string Q4, string Q5, string total, string memo, string id_no,
            string month_1, string month_2, string half_1, string half_2, string year_1, string year_2)
        {
            TableRow TR;
            TableCell TD;

            Label1.Text = name.ToString() + " " + duty_name.ToString();

            TR = new TableRow();
            TR.Font.Size = 10;


            TD = new TableCell();
            TD.Width = 10;
            TD.Text = date.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + date.ToString() + "'" + "'" + id_no + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 20;
            TD.Text = month_1.ToString() + "만" + " / " + month_2.ToString() + "만";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer; ";
            TD.Attributes.Add("Onclick", "go2('" + date.ToString() + "', '" + id_no.ToString() + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 20;
            TD.Text = half_1.ToString() + "만" + " / " + half_2.ToString() + "만";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer; ";
            TD.Attributes.Add("Onclick", "go2('" + date.ToString() + "', '" + id_no.ToString() + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 20;
            TD.Text = year_1.ToString() + "만" + " / " + year_2.ToString() + "만";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer; ";
            TD.Attributes.Add("Onclick", "go2('" + date.ToString() + "', '" + id_no.ToString() + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = new Unit("8%");
            TD.Text = Q1.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer; ";
            TD.Attributes.Add("Onclick", "go2('" + date.ToString() + "', '" + id_no.ToString() + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = new Unit("8%");
            TD.Text = Q2.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + date.ToString() + "', '" + id_no.ToString() + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = new Unit("8%");
            TD.Text = Q3.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + date.ToString() + "', '" + id_no.ToString() + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = new Unit("8%");
            TD.Text = Q4.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + date.ToString() + "', '" + id_no.ToString() + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = new Unit("8%");
            TD.Text = Q5.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + date.ToString() + "', '" + id_no.ToString() + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = new Unit("8%");
            TD.Text = total.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + date.ToString() + "', '" + id_no.ToString() + "')");
            TR.Cells.Add(TD);


            TD = new TableCell();
            TD.Width = 10;
            if (memo.Length < 10)
            {
                TD.Text = memo.ToString();
            }
            else
            {
                TD.Text = memo.Substring(0, 10) + "....";
            }
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + date.ToString() + "', '" + id_no.ToString() + "')");
            TR.Cells.Add(TD);

            a++;
            TBLLIST.Rows.Add(TR);


        }


        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Response.Redirect("notice.aspx?nowpage=" + 1 + "&search=" + Search.Text + "&type1=" + DropDownList1.SelectedValue + "&type2=" + DropDownList2.SelectedValue);
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            //Response.Redirect("insa_list.aspx?nowpage=" + 1 + "&search=" + Search.Text + "&type=" + DropDownList1.SelectedValue );
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["nowpage"] == null)
            {
                Response.Redirect("insa_detail.aspx?no=" + HiddenField2.Value + "&dropdownlist1=" + HiddenField1.Value);
            }
            else
            {
                Response.Redirect("insa_detail.aspx?no=" + HiddenField2.Value + "&dropdownlist1=" + HiddenField1.Value);
            }

        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Insa_list_personal.aspx?no=" + Request["no"]);
        }



        protected void Button3_Click1(object sender, EventArgs e)
        {

        }

        protected void Button1_ServerClick(object sender, EventArgs e)
        {

        }

        public class Customer3
        {
            public string total { get; set; }
            public string date { get; set; }
            public string name { get; set; }
        }
        [WebMethod]
        public static List<Customer3> chart(string no, string year, string startno, string endno)
        {
            SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
            List<Customer3> Parts3 = new List<Customer3>();

            //string SQL = "";
            //if (year == "")
            //{
            //    SQL = "select top 12 * from insa_report where id_no = '" + no + "' order by date desc";
            //}
            //else
            //{
            //    SQL = "select top 12 * from insa_report where left(date,4)  = '" + year + "'  and id_no = '" + no + "' order by date desc";
            //}
            //SqlDataAdapter ADT4 = new SqlDataAdapter(SQL, DB);


            SqlDataAdapter ADT4 = new SqlDataAdapter("insa_personal_list_sp", DB);
            ADT4.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (year == "")
            {
                ADT4.SelectCommand.Parameters.AddWithValue("@search", "where  id_no = '" + no + "' and a.id_no = b.no order by date desc");
            }
            else
            {
                ADT4.SelectCommand.Parameters.AddWithValue("@search", "where left(date,4)  = '" + year + "'  and id_no = '" + no + "' and a.id_no = b.no order by date desc");
            }
            ADT4.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + startno + " and tempno <= " + endno);

            DataSet DBSET4 = new DataSet();
            ADT4.Fill(DBSET4, "BD4");
            foreach (DataRow row1 in DBSET4.Tables["BD4"].Rows)
            {
                Parts3.Add(new Customer3
                {
                    total = row1["total"].ToString(),
                    date = row1["date"].ToString(),
                    name = row1["name"].ToString()
                });
            }



            string iresurlt = "";
            iresurlt = JsonConvert.SerializeObject(Parts3);


            return Parts3;

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HiddenField3.Value = DropDownList1.SelectedValue;
            Response.Redirect("insa_list_personal.aspx?no=" + Request["no"] + "&dropdownlist1=" + HiddenField3.Value);
        }

        protected void Unnamed_ServerClick1(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "window.print()", true);
        }
    }
}

