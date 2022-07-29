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
    public partial class Work_list : System.Web.UI.Page
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

            //create.Visible = false;

            if (!Page.IsPostBack)
            {
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
                    enddate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM");
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
            TR.BackColor = System.Drawing.Color.LightGray;

            //TD = new TableHeaderCell();
            //TD.Width = 20;
            //TD.Text = "번호";
            //TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            //TR.Cells.Add(TD);
           
        
            TD = new TableHeaderCell();
            TD.Width = 80;
            TD.Text = "고객사";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 80;
            TD.Text = "고객";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 80;
            TD.Text = "고객 연락처";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; ";
            TR.Cells.Add(TD);

            
            TD = new TableHeaderCell();
            TD.Width = 80;
            TD.Text = "협력사";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 80;
            TD.Text = "협력사 담당";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            TR.Cells.Add(TD);


            TD = new TableHeaderCell();
            TD.Width = 80;
            TD.Text = "협력사 연락처";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            TR.Cells.Add(TD);


            TD = new TableHeaderCell();
            TD.Width = 100;
            TD.Text = "유지보수 장비";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 100;
            TD.Text = "일정 확인";
            TD.Attributes["style"] = "text-align : center; vertical-align:middle;";
            TR.Cells.Add(TD);

            TD = new TableHeaderCell();
            TD.Width = 100;
            TD.Text = "주소";
            //TD.Font.Underline = true;
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; ";
            
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
            SQL = "select count(*) as count from maintenance where  left(CONVERT(CHAR(10), date, 23),7) like '%" + enddate.Text + "%'";
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
            else
            {
                 SQL2 = "select count(*) as count from work";
            }
                

         
         
            DB.Close();
            DB.Open();
            SqlCommand comm = new SqlCommand(SQL2, DB);
            Int32 count = (Int32)comm.ExecuteScalar();

            DB.Close();
            //int pagenum = Convert.ToInt32(DropDownList2.SelectedValue);
            int pagenum = 50;
            int pagecount = count / pagenum + 1;

            if (count / pagenum > 0)
            {
                pagecount++;
            }


            int start = 1;
            int end = nowpage * pagenum;
            PAGEADD(pagecount, nowpage);

            SqlDataAdapter ADT = new SqlDataAdapter("maintenance_list", DB);
            ADT.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (DropDownList1.SelectedValue == "1")
            {
                ADT.SelectCommand.Parameters.AddWithValue("@search", "where Customer_company like '%" + Search.Text + "%' and  CONVERT(CHAR(10), date, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "'");
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                ADT.SelectCommand.Parameters.AddWithValue("@search", "where engineer like '%" + Search.Text + "%' and  CONVERT(CHAR(10), date, 23)  between '" + startdate.Text + "' and '" + enddate.Text + "'");
            }
            else
            {
                ADT.SelectCommand.Parameters.AddWithValue("@search", " where  left(CONVERT(CHAR(10), date, 23),7) like '%" + enddate.Text + "%' order by company_name asc");
            }
            ADT.SelectCommand.Parameters.AddWithValue("@where", " tempno >= " + start + " and tempno <= " + end);
            startno.Value = start.ToString();
            endno.Value = end.ToString();
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                TBLADD(row["no"].ToString(), row["tempno"].ToString(),row["company_name"].ToString(), row["contract"].ToString(), row["item"].ToString(),
                        row["company_person"].ToString(), row["company_contact"].ToString(), row["company_email"].ToString(), 
                        row["adress"].ToString(), row["sales"].ToString(),row["mother_company"].ToString(),row["mother_person"].ToString(),
                        row["mother_contact"].ToString(), row["mother_email"].ToString(), row["schedule"].ToString(), row["main_check"].ToString(),row["engineer"].ToString(), count3);
                count3--;
            }

       


       


        }
        //protected void work2(object sender, EventArgs e)
        //{
        //    from.Text = DropDownList2.SelectedValue;
        //}
        long a = 1;
        private void TBLADD(string no, string tempno, string company_name, string contract, string item, string company_person,
            string company_contact, string company_email, string adress, string sales, string mother_company, string mother_person, string mother_contact,
            string mother_email, string schedule, string main_check, string engineer, int count)
        {
            TableRow TR;
            TableCell TD;


            TR = new TableRow();
            TR.Font.Size = 10;

            //TD = new TableCell();
            //TD.Width = 10;
            //TD.Text = count.ToString();
            //TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            //TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
            //TR.Cells.Add(TD);

            if (main_check.ToString() == "1")
            {
                TD = new TableCell();
                TD.Text = company_name.ToString();
                TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer; background-color:lightseagreen;";
                TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
                TR.Cells.Add(TD);

            }
            else
            {
                TD = new TableCell();
                TD.Text = company_name.ToString();
                TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer; ;";
                TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
                TR.Cells.Add(TD);
            }

         


            TD = new TableCell();
            TD.Text = company_person.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TR.Cells.Add(TD);


            TD = new TableCell();
            TD.Text = company_contact.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TR.Cells.Add(TD);


            TD = new TableCell();
            TD.Text = mother_company.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Text = mother_person.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TR.Cells.Add(TD);


            TD = new TableCell();
            TD.Text = mother_contact.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Text = item.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TR.Cells.Add(TD);

            TD = new TableCell();
            TD.Text = schedule.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TR.Cells.Add(TD);


            TD = new TableCell();
            TD.Text = adress.ToString();
            TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            TR.Cells.Add(TD);


            //DateTime date1 = Convert.ToDateTime(date.ToString());
            //TD = new TableCell();
            //TD.Width = 60;
            //TD.Text = date1.ToString("yy-MM-dd (ddd) HH:mm");
            //TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            //TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
            //TR.Cells.Add(TD);


            //TD = new TableCell();
            //TD.Width = 40;
            //TD.Text = create_user.ToString();
            //TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            //TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
            //TR.Cells.Add(TD);

            //TD = new TableCell();
            //TD.Width = 40;
            //TD.Text = modi_user.ToString();
            //TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            //TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
            //TR.Cells.Add(TD);

            //if (main_check.ToString() == "1")
            //{
            //    TD = new TableCell();
            //    TD.Width = 40;
            //    TD.Text = "완료";
            //    TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer; background-color:lightseagreen;";
            //    TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
            //    TR.Cells.Add(TD);
            //}
            //else
            //{
            //    TD = new TableCell();
            //    TD.Width = 40;
            //    TD.Text = "미완료";
            //    TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer; ";
            //    TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
            //    TR.Cells.Add(TD);
            //}

            //TD = new TableCell();
            //TD.Width = 40;
            //TD.Text = start_time.ToString() + " ~ " + end_time.ToString();
            //TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer; ";
            //TD.Attributes.Add("Onclick", "go2('" + no.ToString() + "', '" + "work" + "')");
            //TR.Cells.Add(TD);


            //TD = new TableCell();
            //TD.Width = 10;
            //TD.Text = "상세";
            //TD.Attributes["style"] = "text-align : center; vertical-align:middle; cursor:pointer;";
            //TD.Font.Underline = true;
            //TD.Attributes.Add("Onclick", "view('" + tempno.ToString() + "')");
            //TR.Cells.Add(TD);

            a++;
            TBLLIST.Rows.Add(TR);
            //TBLADD2(tempno, history,create_user, modi_user, Customer_request);

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
            cmd.CommandText = "insert into maintenance (company_name, contract, item, company_person, company_contact, company_email, adress, sales, mother_company, " +
                "mother_person, mother_contact, mother_email, schedule, main_check, date, engineer) " +
                "select @company_name, @contract , @item , @company_person ,@company_contact ,@company_email, @adress, @sales, @mother_company, @mother_person" +
                ",@mother_contact, @mother_email , @schedule, '0', getdate() ,@engineer";
            cmd.Parameters.Add("@company_name", SqlDbType.NVarChar, 100).Value = TextBox3.Text;
            cmd.Parameters.Add("@contract", SqlDbType.NVarChar, 100).Value = TextBox4.Text;
            cmd.Parameters.Add("@item", SqlDbType.NVarChar, 100).Value = TextBox1.Text;
            cmd.Parameters.Add("@company_person", SqlDbType.NVarChar, 100).Value = TextBox5.Text;
            cmd.Parameters.Add("@company_contact", SqlDbType.NVarChar, 100).Value = TextBox6.Text;
            cmd.Parameters.Add("@company_email", SqlDbType.NVarChar, 100).Value = TextBox7.Text;
            cmd.Parameters.Add("@adress", SqlDbType.NVarChar, 100).Value = TextBox8.Text;
            cmd.Parameters.Add("@sales", SqlDbType.NVarChar, 100).Value = TextBox9.Text;
            cmd.Parameters.Add("@mother_company", SqlDbType.NVarChar, 100).Value = TextBox10.Text;
            cmd.Parameters.Add("@mother_person", SqlDbType.NVarChar, 100).Value = TextBox11.Text;
            cmd.Parameters.Add("@mother_contact", SqlDbType.NVarChar, 100).Value = TextBox12.Text;
            cmd.Parameters.Add("@mother_email", SqlDbType.NVarChar, 100).Value = TextBox13.Text;
            cmd.Parameters.Add("@schedule", SqlDbType.NVarChar, 100).Value = TextBox50.Text;
            cmd.Parameters.Add("@engineer", SqlDbType.NVarChar, 100).Value = TextBox2.Text;
            cmd.ExecuteNonQuery();
            DB.Close();
            cmd.Dispose();
            cmd = null;

            Response.Redirect("work_list.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(Request.QueryString["nowpage"] == null)
            {
                Response.Redirect("Work_list_detail.aspx?no=" + HiddenField1.Value + "&flag=" + HiddenField2.Value+"&search="+ Request["search"]  + "&type="+ Request["type"]);
            }
            else
            {
                Response.Redirect("Work_list_detail.aspx?no=" + HiddenField1.Value + "&flag=" + HiddenField2.Value + "&nowpage=" + Request["nowpage"].ToString()+ "&search=" + Request["search"] + "&type=" + Request["type"]);
            }
            
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("work.aspx");
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
            
                Response.Redirect("work_list.aspx?nowpage=" + 1 + "&search=" + Search.Text + "&type=" + DropDownList1.SelectedValue + "&startdate=" + startdate.Text + "&enddate=" + enddate.Text);
            
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

            if (create.Visible == false)
            {
                create.Visible = true;
            }
            else
            {
                create.Visible = false;
            }



        }
    }
}

