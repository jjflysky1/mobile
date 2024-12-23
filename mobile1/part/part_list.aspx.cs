using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace mobile1.part
{
    public partial class part_list : System.Web.UI.Page
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
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "IN 날짜";
            TD.Attributes["style"] = "text-align : center";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "OUT 날짜";
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
            TR.Font.Size = 11;

            TD = new TableCell();
            TD.Width = 10;
            TD.Text = a.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 60;
            TD.Text = title.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
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
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            TR.Cells.Add(TD);


            TD = new TableCell();
            TD.Width = 60;
            TD.Text = writer.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 60;
            TD.Text = create_date.ToString().Substring(0, 10);
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
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
            Response.Redirect("notice.aspx?nowpage=" + 1 + "&search=" + Search.Text + "&type1=" + DropDownList1.SelectedValue + "");
        }


    }
}

