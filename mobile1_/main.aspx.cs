using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mobile1
{
    public partial class main : System.Web.UI.Page
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
            TD.Text = "NO";
            //TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 60;
            TD.Text = "순번";
            TD.Attributes["style"] = "text-align : center";
            //TR.Cells.Add(TD);

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


            //TBLLIST.Rows.Add(TR);


            TBLLOAD();
        }
        string SQL = "";
        private void TBLLOAD()
        {
            SQL = "select top 5 * from notice where create_date > getdate()-30 and flag = '1' order by no desc";


            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
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
            TR.Font.Bold = true;
            
            TD = new TableCell();
            TD.Width = 10;
            TD.Text = a.ToString();
            TD.Attributes["style"] = " vertical-align:middle; cursor:pointer;";
            //TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 130;
            TD.Text = title.ToString();
            TD.Attributes.Add("Onclick", "go('" + no.ToString() + "', '" + writer.ToString() + "')");
            TD.Attributes["style"] = " vertical-align:middle; cursor:pointer;";
            TR.Cells.Add(TD);



            //TD = new TableCell();
            //TD.Width = 60;
            //if (body.Length > 10)
            //{
            //    TD.Text = body.Substring(0, 10) + ".....";
            //}
            //else
            //{
            //    TD.Text = body.ToString();
            //}
            //TD.Attributes.Add("Onclick", "go('" + no.ToString() + "', '" + writer.ToString() + "')");
            //TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            //TR.Cells.Add(TD);


            //TD = new TableCell();
            //TD.Width = 10;
            //TD.Text = writer.ToString();
            //TD.Attributes.Add("Onclick", "go('" + no.ToString() + "', '" + writer.ToString() + "')");
            //TD.Attributes["style"] = "text-align : right; vertical-align:middle; cursor:pointer;";
            //TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Width = 100;
            TD.Text = writer.ToString() + "　　" + create_date.ToString().Substring(0, 10);
            TD.Attributes.Add("Onclick", "go('" + no.ToString() + "', '" + writer.ToString() + "')");
            TD.Attributes["style"] = "text-align : right; vertical-align:middle; cursor:pointer;";
            TR.Cells.Add(TD);



            a++;
            TBLLIST.Rows.Add(TR);
            TBLADD2(body, no , writer);
        }
        private void TBLADD2( string body, string no , string writer)
        {
            TableRow TR;
            TableCell TD;
            string str = body.ToString();
            str.Replace("  ", "<br>");

            TR = new TableRow();
            TR.Font.Size = 10;
            TR.Height = 10;

            TD = new TableCell();
            TD.Width = 60;
            TD.Text = body.ToString();
            TD.Attributes.Add("Onclick", "go('" + no.ToString() + "', '" + writer.ToString() + "')");
            TD.ColumnSpan = 2;
            TD.Attributes["style"] = " padding-bottom:20px; vertical-align:top; cursor:pointer; ";
            TR.Cells.Add(TD);

            TBLLIST.Rows.Add(TR);
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("notice/notice_writer.aspx?no=" + HiddenField1.Value + "&writer=" + HiddenField2.Value);
        }
    }
}