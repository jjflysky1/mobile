using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace mobile1.Product
{
    public partial class product_detail : System.Web.UI.Page
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        DataSet DBSET = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (outdate.Text == "")
            {
                outdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

            if (IsPostBack == true)
            {
                HiddenField2.Value = TextBox2.Text;
                HiddenField3.Value = TextBox1.Text;
                HiddenField4.Value = TextBox3.Text;
                HiddenField5.Value = from.Text;
                HiddenField6.Value = product_code.Text;
            }

            if (Request["flag"] == "Sell")
            {
                //count
                string SQL = "";
                SQL = "select count(distinct to_location) as count from Product_sell ";
                int count = 0;
                SqlDataAdapter ADT2 = new SqlDataAdapter(SQL, DB);
                DataSet DBSET2 = new DataSet();
                ADT2.Fill(DBSET2, "BD");
                foreach (DataRow row in DBSET2.Tables["BD"].Rows)
                {
                    count = Convert.ToInt32(row["count"].ToString());
                }

                //to_location
                string to_location = "";
                SQL = "select distinct to_location from Product_sell where to_location is not null and len(to_location) > 1  order by to_location asc  ";
                SqlDataAdapter ADT4 = new SqlDataAdapter(SQL, DB);
                DataSet DBSET3 = new DataSet();
                ADT4.Fill(DBSET3, "BD");
                foreach (DataRow row in DBSET3.Tables["BD"].Rows)
                {
                    to_location = row["to_location"].ToString();
                    if (DropDownList1.Items.Count <= Convert.ToInt32(count + 1))
                    {
                        DropDownList1.Items.Add(to_location.ToString());
                    }
                    DropDownList1.SelectedIndexChanged += work;
                }

                //count
                SQL = "select count(distinct from_location) as count from Product_sell ";
                int count2 = 0;
                SqlDataAdapter ADT7 = new SqlDataAdapter(SQL, DB);
                DataSet DBSET7 = new DataSet();
                ADT7.Fill(DBSET7, "BD");
                foreach (DataRow row in DBSET7.Tables["BD"].Rows)
                {
                    count2 = Convert.ToInt32(row["count"].ToString());
                }

                //from_location
                string from_location = "";
                SQL = "select distinct from_location from Product_sell where from_location is not null and len(from_location) > 1  order by from_location asc  ";
                SqlDataAdapter ADT6 = new SqlDataAdapter(SQL, DB);
                DataSet DBSET6 = new DataSet();
                ADT6.Fill(DBSET6, "BD");
                foreach (DataRow row in DBSET6.Tables["BD"].Rows)
                {
                    from_location = row["from_location"].ToString();
                    if (DropDownList2.Items.Count <= Convert.ToInt32(count2 + 1))
                    {
                        DropDownList2.Items.Add(from_location.ToString());
                    }
                    DropDownList2.SelectedIndexChanged += work2;
                }


                string SQL3 = "select * from Product_sell where no = '" + Request["no"] + "' ";
                SqlDataAdapter ADT3 = new SqlDataAdapter(SQL3, DB);
                ADT3.Fill(DBSET, "BD");
                foreach (DataRow row in DBSET.Tables["BD"].Rows)
                {

                    TextBox3.Text = row["product"].ToString();
                    if (row["serial"].ToString() == "")
                    {
                        Label5.Text = "없음";
                    }
                    else
                    {
                        Label5.Text = row["serial"].ToString();
                        product_code.Text = row["serial"].ToString();
                    }
                    if (Request.Cookies["ID"].Value == "jjflysky" || Request.Cookies["ID"].Value == "admin" || Request.Cookies["ID"].Value == "kwak0001")
                    {
                        serial.Style.Add("display", "none");
                    }
                    else
                    {
                        serial2.Style.Add("display", "none");
                    }


                    TextBox1.Text = row["qty"].ToString();
                    Label7.Text = row["indate"].ToString();

                    if (row["outdate"].ToString() == "")
                    {
                        Label8.Text = "없음";
                        out2.Style.Add("display", "none");
                    }
                    else
                    {
                        Label8.Text = row["outdate"].ToString();
                        out1.Style.Add("display", "none");
                    }

                    if (row["out_user"].ToString() == "")
                    {
                        Label9.Text = "없음";
                    }
                    else
                    {
                        Label9.Text = row["out_user"].ToString();
                    }

                    if (row["to_location"].ToString() == "")
                    {
                        //TextBox2.Text = "없음";
                    }
                    else
                    {
                        TextBox2.Text = row["to_location"].ToString();
                        LinkButton2.Enabled = false;
                        LinkButton4.Enabled = false;
                    }

                    if (row["from_location"].ToString() == "")
                    {
                        from.Text = "없음";
                        qty1.Style.Add("display", "none");
                    }
                    else
                    {
                        qty1.Style.Add("display", "none");
                        Label6.Text = row["qty"].ToString();
                        from.Text = row["from_location"].ToString();
                    }




                    //Label8.Attributes.Add("Onclick", "go('" + row["email"].ToString() + "')");
                    //Label8.Attributes["style"] = "cursor:pointer;";

                }

            }
            else if (Request["flag"] == "Demo")
            {
                //count
                string SQL = "";
                SQL = "select count(distinct to_location) as count from product_demo ";
                int count = 0;
                SqlDataAdapter ADT2 = new SqlDataAdapter(SQL, DB);
                DataSet DBSET2 = new DataSet();
                ADT2.Fill(DBSET2, "BD");
                foreach (DataRow row in DBSET2.Tables["BD"].Rows)
                {
                    count = Convert.ToInt32(row["count"].ToString());
                }

                //to_location
                string to_location = "";
                SQL = "select distinct to_location from product_demo where to_location is not null and len(to_location) > 1  order by to_location asc  ";
                SqlDataAdapter ADT4 = new SqlDataAdapter(SQL, DB);
                DataSet DBSET3 = new DataSet();
                ADT4.Fill(DBSET3, "BD");
                foreach (DataRow row in DBSET3.Tables["BD"].Rows)
                {
                    to_location = row["to_location"].ToString();
                    if (DropDownList1.Items.Count <= Convert.ToInt32(count + 1))
                    {
                        DropDownList1.Items.Add(to_location.ToString());
                    }
                    DropDownList1.SelectedIndexChanged += work;
                }

                //count
                SQL = "select count(distinct from_location) as count from product_demo ";
                int count2 = 0;
                SqlDataAdapter ADT7 = new SqlDataAdapter(SQL, DB);
                DataSet DBSET7 = new DataSet();
                ADT7.Fill(DBSET7, "BD");
                foreach (DataRow row in DBSET7.Tables["BD"].Rows)
                {
                    count2 = Convert.ToInt32(row["count"].ToString());
                }

                //from_location
                string from_location = "";
                SQL = "select distinct from_location from product_demo where from_location is not null and len(from_location) > 1  order by from_location asc  ";
                SqlDataAdapter ADT6 = new SqlDataAdapter(SQL, DB);
                DataSet DBSET6 = new DataSet();
                ADT6.Fill(DBSET6, "BD");
                foreach (DataRow row in DBSET6.Tables["BD"].Rows)
                {
                    from_location = row["from_location"].ToString();
                    if (DropDownList2.Items.Count <= Convert.ToInt32(count2 + 1))
                    {
                        DropDownList2.Items.Add(from_location.ToString());
                    }
                    DropDownList2.SelectedIndexChanged += work2;
                }



                string SQL3 = "select * from product_demo where no = '" + Request["no"] + "'";
                SqlDataAdapter ADT3 = new SqlDataAdapter(SQL3, DB);
                ADT3.Fill(DBSET, "BD");
                foreach (DataRow row in DBSET.Tables["BD"].Rows)
                {
                    TextBox3.Text = row["product"].ToString();
                    if (row["serial"].ToString() == "")
                    {
                        Label8.Text = "없음";
                    }
                    else
                    {
                        Label5.Text = row["serial"].ToString();
                    }
                    TextBox1.Text = row["qty"].ToString();
                    Label7.Text = row["indate"].ToString();

                    if (row["outdate"].ToString() == "")
                    {
                        Label8.Text = "없음";
                        out2.Style.Add("display", "none");
                    }
                    else
                    {
                        Label8.Text = row["outdate"].ToString();
                        out1.Style.Add("display", "none");
                    }

                    if (row["out_user"].ToString() == "")
                    {
                        Label9.Text = "없음";
                    }
                    else
                    {
                        Label9.Text = row["out_user"].ToString();
                    }

                    if (row["to_location"].ToString() == "")
                    {
                        //TextBox2.Text = "없음";
                    }
                    else
                    {
                        TextBox2.Text = row["to_location"].ToString();
                        LinkButton2.Enabled = false;
                        LinkButton4.Enabled = false;
                    }

                    if (row["from_location"].ToString() == "")
                    {
                        from.Text = "없음";
                        qty1.Style.Add("display", "none");
                    }
                    else
                    {
                        from.Text = row["from_location"].ToString();
                    }

                }
            }
            else if (Request["flag"] == "IN")
            {

                //count
                string SQL = "";
                SQL = "select count(distinct to_location) as count from product_mine ";
                int count = 0;
                SqlDataAdapter ADT2 = new SqlDataAdapter(SQL, DB);
                DataSet DBSET2 = new DataSet();
                ADT2.Fill(DBSET2, "BD");
                foreach (DataRow row in DBSET2.Tables["BD"].Rows)
                {
                    count = Convert.ToInt32(row["count"].ToString());
                }

                //to_location
                string to_location = "";
                SQL = "select distinct to_location from product_mine where to_location is not null and len(to_location) > 1  order by to_location asc  ";
                SqlDataAdapter ADT4 = new SqlDataAdapter(SQL, DB);
                DataSet DBSET3 = new DataSet();
                ADT4.Fill(DBSET3, "BD");
                foreach (DataRow row in DBSET3.Tables["BD"].Rows)
                {
                    to_location = row["to_location"].ToString();
                    if (DropDownList1.Items.Count <= Convert.ToInt32(count + 1))
                    {
                        DropDownList1.Items.Add(to_location.ToString());
                    }
                    DropDownList1.SelectedIndexChanged += work;
                }

                //count
                SQL = "select count(distinct from_location) as count from product_mine ";
                int count2 = 0;
                SqlDataAdapter ADT7 = new SqlDataAdapter(SQL, DB);
                DataSet DBSET7 = new DataSet();
                ADT7.Fill(DBSET7, "BD");
                foreach (DataRow row in DBSET7.Tables["BD"].Rows)
                {
                    count2 = Convert.ToInt32(row["count"].ToString());
                }

                //from_location
                string from_location = "";
                SQL = "select distinct from_location from product_mine where from_location is not null and len(from_location) > 1  order by from_location asc  ";
                SqlDataAdapter ADT6 = new SqlDataAdapter(SQL, DB);
                DataSet DBSET6 = new DataSet();
                ADT6.Fill(DBSET6, "BD");
                foreach (DataRow row in DBSET6.Tables["BD"].Rows)
                {
                    from_location = row["from_location"].ToString();
                    if (DropDownList2.Items.Count <= Convert.ToInt32(count2 + 1))
                    {
                        DropDownList2.Items.Add(from_location.ToString());
                    }
                    DropDownList2.SelectedIndexChanged += work2;
                }



                string SQL3 = "select * from product_mine where no = '" + Request["no"] + "'";
                SqlDataAdapter ADT3 = new SqlDataAdapter(SQL3, DB);
                ADT3.Fill(DBSET, "BD");
                foreach (DataRow row in DBSET.Tables["BD"].Rows)
                {
                    TextBox3.Text = row["product"].ToString();
                    if (row["serial"].ToString() == "")
                    {
                        Label8.Text = "없음";
                    }
                    else
                    {
                        Label5.Text = row["serial"].ToString();
                    }
                    TextBox1.Text = row["qty"].ToString();
                    Label7.Text = row["indate"].ToString();

                    if (row["outdate"].ToString() == "")
                    {
                        Label8.Text = "없음";
                        out2.Style.Add("display", "none");
                    }
                    else
                    {
                        Label8.Text = row["outdate"].ToString();
                        out1.Style.Add("display", "none");
                    }

                    if (row["out_user"].ToString() == "")
                    {
                        Label9.Text = "없음";
                    }
                    else
                    {
                        Label9.Text = row["out_user"].ToString();
                    }

                    if (row["to_location"].ToString() == "")
                    {
                        //TextBox2.Text = "없음";
                    }
                    else
                    {
                        TextBox2.Text = row["to_location"].ToString();
                        LinkButton2.Enabled = false;
                        LinkButton4.Enabled = false;
                    }

                    if (row["from_location"].ToString() == "")
                    {
                        from.Text = "없음";
                        qty1.Style.Add("display", "none");
                    }
                    else
                    {
                        from.Text = row["from_location"].ToString();
                    }

                }
            }
            else if (Request["flag"] == "RMA")
            {

                //count
                string SQL = "";
                SQL = "select count(distinct to_location) as count from product_RMA ";
                int count = 0;
                SqlDataAdapter ADT2 = new SqlDataAdapter(SQL, DB);
                DataSet DBSET2 = new DataSet();
                ADT2.Fill(DBSET2, "BD");
                foreach (DataRow row in DBSET2.Tables["BD"].Rows)
                {
                    count = Convert.ToInt32(row["count"].ToString());
                }

                //to_location
                string to_location = "";
                SQL = "select distinct to_location from product_RMA where to_location is not null and len(to_location) > 1  order by to_location asc  ";
                SqlDataAdapter ADT4 = new SqlDataAdapter(SQL, DB);
                DataSet DBSET3 = new DataSet();
                ADT4.Fill(DBSET3, "BD");
                foreach (DataRow row in DBSET3.Tables["BD"].Rows)
                {
                    to_location = row["to_location"].ToString();
                    if (DropDownList1.Items.Count <= Convert.ToInt32(count + 1))
                    {
                        DropDownList1.Items.Add(to_location.ToString());
                    }
                    DropDownList1.SelectedIndexChanged += work;
                }

                //count
                SQL = "select count(distinct from_location) as count from product_RMA ";
                int count2 = 0;
                SqlDataAdapter ADT7 = new SqlDataAdapter(SQL, DB);
                DataSet DBSET7 = new DataSet();
                ADT7.Fill(DBSET7, "BD");
                foreach (DataRow row in DBSET7.Tables["BD"].Rows)
                {
                    count2 = Convert.ToInt32(row["count"].ToString());
                }

                //from_location
                string from_location = "";
                SQL = "select distinct from_location from product_RMA where from_location is not null and len(from_location) > 1  order by from_location asc  ";
                SqlDataAdapter ADT6 = new SqlDataAdapter(SQL, DB);
                DataSet DBSET6 = new DataSet();
                ADT6.Fill(DBSET6, "BD");
                foreach (DataRow row in DBSET6.Tables["BD"].Rows)
                {
                    from_location = row["from_location"].ToString();
                    if (DropDownList2.Items.Count <= Convert.ToInt32(count2 + 1))
                    {
                        DropDownList2.Items.Add(from_location.ToString());
                    }
                    DropDownList2.SelectedIndexChanged += work2;
                }



                string SQL3 = "select * from product_RMA where no = '" + Request["no"] + "'";
                SqlDataAdapter ADT3 = new SqlDataAdapter(SQL3, DB);
                ADT3.Fill(DBSET, "BD");
                foreach (DataRow row in DBSET.Tables["BD"].Rows)
                {
                    TextBox3.Text = row["product"].ToString();
                    if (row["serial"].ToString() == "")
                    {
                        Label8.Text = "없음";
                    }
                    else
                    {
                        Label5.Text = row["serial"].ToString();
                    }
                    TextBox1.Text = row["qty"].ToString();
                    Label7.Text = row["indate"].ToString();

                    if (row["outdate"].ToString() == "")
                    {
                        Label8.Text = "없음";
                        out2.Style.Add("display", "none");
                    }
                    else
                    {
                        Label8.Text = row["outdate"].ToString();
                        out1.Style.Add("display", "none");
                    }

                    if (row["out_user"].ToString() == "")
                    {
                        Label9.Text = "없음";
                    }
                    else
                    {
                        Label9.Text = row["out_user"].ToString();
                    }

                    if (row["to_location"].ToString() == "")
                    {
                        //TextBox2.Text = "없음";
                    }
                    else
                    {
                        TextBox2.Text = row["to_location"].ToString();
                        LinkButton2.Enabled = false;
                        LinkButton4.Enabled = false;
                    }

                    if (row["from_location"].ToString() == "")
                    {
                        from.Text = "없음";
                        qty1.Style.Add("display", "none");
                    }
                    else
                    {
                        from.Text = row["from_location"].ToString();
                    }

                }
            }
            else
            {

                info.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../mail/mail_write.aspx?email=" + HiddenField1.Value);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            if (Request["flag"] == "Sell")
            {
                if (Request.QueryString["nowpage"] == null)
                {
                    Response.Redirect("Sell.aspx?search=" + Request["search"] + "&type=" + Request["type"]);
                }
                else
                {
                    Response.Redirect("Sell.aspx?nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
                }

            }
            else if (Request["flag"] == "Demo")
            {
                if (Request.QueryString["nowpage"] == null)
                {
                    Response.Redirect("demo.aspx?search=" + Request["search"] + "&type=" + Request["type"]);
                }
                else
                {
                    Response.Redirect("demo.aspx?nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
                }

            }
            else if (Request["flag"] == "IN")
            {
                if (Request.QueryString["nowpage"] == null)
                {
                    Response.Redirect("in.aspx?search=" + Request["search"] + "&type=" + Request["type"]);
                }
                else
                {
                    Response.Redirect("in.aspx?nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
                }

            }
            else if (Request["flag"] == "RMA")
            {
                if (Request.QueryString["nowpage"] == null)
                {
                    Response.Redirect("RMA.aspx?search=" + Request["search"] + "&type=" + Request["type"]);
                }
                else
                {
                    Response.Redirect("RMA.aspx?nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
                }

            }


        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (TextBox2.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                     "alert",
                     "alert('반출처를 입력해주세요');window.location ='" + HttpContext.Current.Request.Url.AbsoluteUri + "';",
                     true);
            }
            else
            {
                string SQL = "select * from user_ba where id = '" + Request.Cookies["ID"].Value + "'";
                SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
                DataSet DBSET = new DataSet();
                ADT.Fill(DBSET, "BD");
                string name = "";
                foreach (DataRow row in DBSET.Tables["BD"].Rows)
                {
                    name = row["name"].ToString();

                }


                if (Request["flag"] == "Sell")
                {
                    DB.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DB;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "update product_sell set product = '" + HiddenField4.Value + "', outdate= '" + outdate.Text + " ' +  CONVERT(CHAR(8), GETDATE(), 24), out_user = '" + name + "', to_location = '" + HiddenField2.Value + "' where no = " + Request["no"];
                    cmd.ExecuteNonQuery();
                    DB.Close();
                    cmd.Dispose();
                    cmd = null;

                    //Response.Redirect("Sell.aspx?nowpage="+Request["nowpage"].ToString());
                    if (Request.QueryString["nowpage"] == null)
                    {
                        Response.Redirect("Sell.aspx?search=" + Request["search"] + "&type=" + Request["type"]);
                    }
                    else
                    {
                        Response.Redirect("Sell.aspx?nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
                    }
                }
                else if (Request["flag"] == "Demo")
                {
                    DB.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DB;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "update product_demo set product = '" + HiddenField4.Value + "', outdate= '" + outdate.Text + " ' +  CONVERT(CHAR(8), GETDATE(), 24) , out_user = '" + name + "', to_location = '" + HiddenField2.Value + "' where no = " + Request["no"];
                    cmd.ExecuteNonQuery();
                    DB.Close();
                    cmd.Dispose();
                    cmd = null;

                    //Response.Redirect("Demo.aspx");
                    if (Request.QueryString["nowpage"] == null)
                    {
                        Response.Redirect("demo.aspx?search=" + Request["search"] + "&type=" + Request["type"]);
                    }
                    else
                    {
                        Response.Redirect("demo.aspx?nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
                    }
                }
                else if (Request["flag"] == "IN")
                {
                    DB.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DB;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "update product_mine set product = '" + HiddenField4.Value + "', outdate= '" + outdate.Text + " ' +  CONVERT(CHAR(8), GETDATE(), 24), out_user = '" + name + "', to_location = '" + HiddenField2.Value + "' where no = " + Request["no"];
                    cmd.ExecuteNonQuery();
                    DB.Close();
                    cmd.Dispose();
                    cmd = null;

                    //Response.Redirect("IN.aspx");
                    if (Request.QueryString["nowpage"] == null)
                    {
                        Response.Redirect("in.aspx?search=" + Request["search"] + "&type=" + Request["type"]);
                    }
                    else
                    {
                        Response.Redirect("in.aspx?nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
                    }
                }
                else if (Request["flag"] == "RAM")
                {
                    DB.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DB;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "update product_RAM set product = '" + HiddenField4.Value + "', outdate= '" + outdate.Text + " ' +  CONVERT(CHAR(8), GETDATE(), 24), out_user = '" + name + "', to_location = '" + HiddenField2.Value + "' where no = " + Request["no"];
                    cmd.ExecuteNonQuery();
                    DB.Close();
                    cmd.Dispose();
                    cmd = null;

                    //Response.Redirect("IN.aspx");
                    if (Request.QueryString["nowpage"] == null)
                    {
                        Response.Redirect("RAM.aspx?search=" + Request["search"] + "&type=" + Request["type"]);
                    }
                    else
                    {
                        Response.Redirect("RAM.aspx?nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
                    }
                }
            }



        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string SQL = "select * from user_ba where id = '" + Request.Cookies["ID"].Value + "'";
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            string name = "";
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                name = row["name"].ToString();

            }

            if (Request["flag"] == "Sell")
            {
                DB.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DB;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update product_sell set serial = '" + HiddenField6.Value + "', modi_user = '" + name + "' , product = '" + HiddenField4.Value + "', qty = '" + HiddenField3.Value + "', to_location = '" + HiddenField2.Value + "' where no = " + Request["no"];
                cmd.ExecuteNonQuery();
                DB.Close();
                cmd.Dispose();
                cmd = null;

                //Response.Redirect("Sell.aspx?nowpage="+Request["nowpage"].ToString());
                if (Request.QueryString["nowpage"] == null)
                {
                    Response.Redirect("Sell.aspx?search=" + Request["search"] + "&type=" + Request["type"]);
                }
                else
                {
                    Response.Redirect("Sell.aspx?nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
                }
            }

            if (Request["flag"] == "Sell")
            {
                DB.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DB;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update product_sell set modi_user = '" + name + "' , product = '" + HiddenField4.Value + "', qty = '" + HiddenField3.Value + "', to_location = '" + HiddenField2.Value + "' where no = " + Request["no"];
                cmd.ExecuteNonQuery();
                DB.Close();
                cmd.Dispose();
                cmd = null;

                //Response.Redirect("Sell.aspx?nowpage="+Request["nowpage"].ToString());
                if (Request.QueryString["nowpage"] == null)
                {
                    Response.Redirect("Sell.aspx?search=" + Request["search"] + "&type=" + Request["type"]);
                }
                else
                {
                    Response.Redirect("Sell.aspx?nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
                }
            }
            else if (Request["flag"] == "Demo")
            {
                DB.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DB;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update product_demo set modi_user = '" + name + "' , product = '" + HiddenField4.Value + "',  qty = '" + HiddenField3.Value + "' , to_location = '" + HiddenField2.Value + "' where no = " + Request["no"];
                cmd.ExecuteNonQuery();
                DB.Close();
                cmd.Dispose();
                cmd = null;

                //Response.Redirect("Demo.aspx");
                if (Request.QueryString["nowpage"] == null)
                {
                    Response.Redirect("demo.aspx?search=" + Request["search"] + "&type=" + Request["type"]);
                }
                else
                {
                    Response.Redirect("demo.aspx?nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
                }
            }
            else if (Request["flag"] == "IN")
            {
                DB.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DB;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update product_mine set modi_user = '" + name + "' , product = '" + HiddenField4.Value + "',  qty = '" + HiddenField3.Value + "', to_location = '" + HiddenField2.Value + "' where no = " + Request["no"];
                cmd.ExecuteNonQuery();
                DB.Close();
                cmd.Dispose();
                cmd = null;

                //Response.Redirect("IN.aspx");
                if (Request.QueryString["nowpage"] == null)
                {
                    Response.Redirect("in.aspx?search=" + Request["search"] + "&type=" + Request["type"]);
                }
                else
                {
                    Response.Redirect("in.aspx?nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
                }
            }
            else if (Request["flag"] == "RMA")
            {
                DB.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DB;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update product_RMA set modi_user = '" + name + "' , product = '" + HiddenField4.Value + "',  qty = '" + HiddenField3.Value + "', to_location = '" + HiddenField2.Value + "' where no = " + Request["no"];
                cmd.ExecuteNonQuery();
                DB.Close();
                cmd.Dispose();
                cmd = null;

                //Response.Redirect("IN.aspx");
                if (Request.QueryString["nowpage"] == null)
                {
                    Response.Redirect("RMA.aspx?search=" + Request["search"] + "&type=" + Request["type"]);
                }
                else
                {
                    Response.Redirect("RMA.aspx?nowpage=" + Request["nowpage"].ToString() + "&search=" + Request["search"] + "&type=" + Request["type"]);
                }
            }
        }
        protected void work(object sender, EventArgs e)
        {
            TextBox2.Text = DropDownList1.SelectedValue;
        }
        protected void work2(object sender, EventArgs e)
        {
            from.Text = DropDownList2.SelectedValue;
        }
    }
}