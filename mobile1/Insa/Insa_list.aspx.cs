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

namespace mobile1.Insa
{
    public partial class Insa_list : System.Web.UI.Page
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

            if (!Page.IsPostBack)
            {

                Search.Text = Request["search"];
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
            TD.Text = "이름";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "제품번호";
            TD.Attributes["style"] = "text-align : center";
            //TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 40;
            TD.Text = "부서";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "평가하기";
            TD.Attributes["style"] = "text-align : center; ";
            TR.Cells.Add(TD);


            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "기록보기";
            TD.Attributes["style"] = "text-align : center; ";
            TR.Cells.Add(TD);



            TBLLIST.Rows.Add(TR);


            TBLLOAD();
        }
        private void PAGEADD(int pagecount, int nowpage)
        {
            StringBuilder SB = new StringBuilder();

            SB.Append("<ul class='pagination pagination-sm no-margin'>");
            SB.Append("<li>" + "<a href='sell.aspx?nowpage=" + 1 + " &search=" + Request["search"] + "&type=" + Request["type"] + "'>" + "<span aria-hidden='true'> &laquo;</span>" + "</a>" + "<li>");
            if (pagecount == 0)
            {
                SB.Append("<li> " + "<a href='sell.aspx?nowpage=" + 1 + "&search=" + Request["search"] + "&type=" + Request["type"] + "' >" + 1 + "</a>" + " <li>");
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
                    SB.Append("<li class='page-item active'> " + "<a href='sell.aspx?nowpage=" + i + " &search=" + Request["search"] + "&type=" + Request["type"] + "&sort=" + Request["sort"] + " '>" + i + "</a>" + " <li>");
                }
                else
                {
                    SB.Append("<li> " + "<a href='sell.aspx?nowpage=" + i + "&search=" + Request["search"] + "&type=" + Request["type"] + "&sort=" + Request["sort"] + "'>" + i + "</a>" + " <li>");
                }
            }

            SB.Append("<li>" + "<a href='sell.aspx?nowpage=" + (pagecount - 1) + "&search=" + Request["search"] + "&type=" + Request["type"] + "'>" + "<span aria-hidden='true'> &raquo;</span>" + "</a>" + "<li>");
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

            string SQL2 = "select count(*) as count from user_ba";

            if (DropDownList1.SelectedValue == "3")
            {
                SQL2 = "select count(*) as count from user_ba ";
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



      


            SqlDataAdapter ADT = new SqlDataAdapter("insa_list_sp", DB);
            ADT.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (DropDownList1.SelectedValue == "1")
            {
                SQL = "select * from Service where os like '%" + Search.Text + "%' order by no desc";
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                ADT.SelectCommand.Parameters.AddWithValue("@search", Request.Cookies["ID"].Value);
            }
            
            ADT.SelectCommand.Parameters.AddWithValue("@search", Request.Cookies["ID"].Value);
            ADT.SelectCommand.Parameters.AddWithValue("@where", " where name like '%" + Search.Text + "%'");

            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                TBLADD(row["name"].ToString(), row["dept_name"].ToString(), row["no"].ToString(), row["tempno"].ToString());


            }


        }
        long a = 1;
        private void TBLADD(string name, string dept_name, string no, string tempno)
        {
            TableRow TR;
            TableCell TD;


            TR = new TableRow();
            TR.Font.Size = 10;


            TD = new TableCell();
            TD.Width = 10;
            TD.Text = tempno.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 60;
            TD.Text = name.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 60;
            TD.Text = dept_name.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "')");
            TR.Cells.Add(TD);


            TD = new TableCell();
            TD.Width = 60;
            TD.Text = "<i class='fa fa-sticky-note-o' ></i>";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "')");
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 60;
            TD.Text = "<i class='fa fa-line-chart' ></i>";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TD.Attributes.Add("Onclick", "go3('" + no.ToString() + "')");
            TR.Cells.Add(TD);





            a++;
            TBLLIST.Rows.Add(TR);
            

        }
     

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("notice.aspx?nowpage=" + 1 + "&search=" + Search.Text + "&type1=" + DropDownList1.SelectedValue + "&type2=" + DropDownList2.SelectedValue);
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("insa_list.aspx?nowpage=" + 1 + "&search=" + Search.Text + "&type=" + DropDownList1.SelectedValue );
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["nowpage"] == null)
            {
                Response.Redirect("insa_detail.aspx?no="+ HiddenField1.Value);
            }
            else
            {
                Response.Redirect("insa_detail.aspx?no=" + HiddenField1.Value);
            }

        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Sell.aspx");
        }

       

        protected void Button3_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Insa_list_personal.aspx?no=" + HiddenField1.Value);
        }

        protected void Button1_ServerClick(object sender, EventArgs e)
        {

        }
    }
}

