using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace mobile1.soap
{
    /// <summary>
    /// device_token의 요약 설명입니다.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // ASP.NET AJAX를 사용하여 스크립트에서 이 웹 서비스를 호출하려면 다음 줄의 주석 처리를 제거합니다. 
    // [System.Web.Script.Services.ScriptService]
    public class device_token : System.Web.Services.WebService
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string token(string token)
        {


            DB.Open();
            SqlCommand cmd = new SqlCommand("add_token", DB);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@token", token.ToString());
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            DB.Close();



            return "1";

        }
        [WebMethod]
        public string potal_version_check()
        {
            string SQL = "SELECT* FROM site_config";
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            string version = "";

            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                version = row["potal_version"].ToString();

            }


            return version;
        }
        [WebMethod]
        public string barcode_version_check()
        {
            string SQL = "SELECT* FROM site_config";
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            string version = "";

            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                version = row["barcode_version"].ToString();

            }


            return version;
        }
        [WebMethod]
        public string product_get(string serial)
        {
            string SQL = "SELECT* FROM product_mine where serial = '" + serial + "'" +
                " Union " +
                "SELECT* FROM product_demo where serial = '" + serial + "'" +
                " Union " +
                "SELECT* FROM Product_sell where serial = '" + serial + "'";
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            string productname = "";
            string serial2 = "";
            string[] data = { };
            int a = 0;
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                productname = row["product"].ToString();
                //data[a] = row["product"].ToString();
                //a++;
                //data[a] = row["serial"].ToString();
                //a++;
                //data[a] = row["from_location"].ToString();
            }


            return productname;
        }

        [WebMethod]
        public string product_out(string serial, string outdate, string to_location, string out_name)
        {
            //string SQL = "select * device_token a , user_ba b where a.id = b.id and token = '" + token + "'";
            //SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            //DataSet DBSET = new DataSet();
            //ADT.Fill(DBSET, "BD");
            //string name = "";
            //foreach (DataRow row in DBSET.Tables["BD"].Rows)
            //{
            //    name = row["name"].ToString();
            //}

            DB.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DB;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update Product_sell set outdate = '" + outdate + " '+ CONVERT(CHAR(8), GETDATE(), 24) , to_location = '" + to_location + "' , out_user = '" + out_name + "' where serial = '" + serial + "' ";
            cmd.ExecuteNonQuery();
            DB.Close();
            cmd.Dispose();
            cmd = null;

            DB.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = DB;
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "update product_mine set outdate = '" + outdate + " '+ CONVERT(CHAR(8), GETDATE(), 24) , to_location = '" + to_location + "' , out_user = '" + out_name + "' where serial = '" + serial + "' ";
            cmd2.ExecuteNonQuery();
            DB.Close();
            cmd2.Dispose();
            cmd2 = null;

            DB.Open();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = DB;
            cmd3.CommandType = System.Data.CommandType.Text;
            cmd3.CommandText = "update product_demo set outdate = '" + outdate + " '+ CONVERT(CHAR(8), GETDATE(), 24) , to_location = '" + to_location + "' , out_user = '" + out_name + "' where serial = '" + serial + "' ";
            cmd3.ExecuteNonQuery();
            DB.Close();
            cmd3.Dispose();
            cmd3 = null;

            return "1";
        }
        [WebMethod]
        public string product_check_tolocation(string product, string serial, string fromlocation, string what)
        {
            string SQL = "SELECT * FROM product_mine where serial = '" + serial + "'" +
                " Union " +
                "SELECT * FROM product_demo where serial = '" + serial + "'" +
                " Union " +
                "SELECT * FROM Product_sell where serial = '" + serial + "'";
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            string from_location = "";
            string serial2 = "";
            string[] data = { };
            int a = 0;
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {
                from_location = row["from_location"].ToString();
                //data[a] = row["product"].ToString();
                //a++;
                //data[a] = row["serial"].ToString();
                //a++;
                //data[a] = row["from_location"].ToString();
            }


            return from_location;
        }
        [WebMethod]
        public string product_check(string product, string serial, string fromlocation, string what)
        {
            if (what == "check")
            {
                int count = 0;
                int count1 = 0;
                int count2 = 0;
                string flag = "";

                string SQL = "select count(*) as count, to_location, product from product_sell where serial = '" + serial + "' group by to_location, product";
                SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
                DataSet DBSET = new DataSet();
                ADT.Fill(DBSET, "BD");
                foreach (DataRow row in DBSET.Tables["BD"].Rows)
                {
                    count = Convert.ToInt32(row["count"]);
                    flag = row["to_location"].ToString();


                }

                string SQL2 = "select count(*) as count, to_location, product from product_mine where serial = '" + serial + "' group by to_location, product";
                SqlDataAdapter ADT2 = new SqlDataAdapter(SQL2, DB);
                DataSet DBSET2 = new DataSet();
                ADT2.Fill(DBSET2, "BD");
                foreach (DataRow row in DBSET2.Tables["BD"].Rows)
                {
                    count1 = Convert.ToInt32(row["count"]);
                    flag = row["to_location"].ToString();


                }

                string SQL3 = "select count(*) as count, to_location, product from product_demo where serial = '" + serial + "' group by to_location, product";
                SqlDataAdapter ADT3 = new SqlDataAdapter(SQL3, DB);
                DataSet DBSET3 = new DataSet();
                ADT3.Fill(DBSET3, "BD");
                foreach (DataRow row in DBSET3.Tables["BD"].Rows)
                {
                    count2 = Convert.ToInt32(row["count"]);
                    flag = row["to_location"].ToString();


                }

                if (flag.ToString().Length > 0)
                {

                    return "반출완료";


                }
                else
                {
                    if (count != 0)
                    {

                        return "판매";

                    }
                    else if (count1 != 0)
                    {

                        return "자산";

                    }
                    else if (count2 != 0)
                    {

                        return "데모";

                    }
                }

            }
            return "";
        }
        [WebMethod]
        public string product(string product, string serial, string fromlocation, string what)
        {


            if (what == "sell")
            {
                DB.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DB;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into  product_sell(product,serial,indate,up_user,from_location) values(@product,@serial,getdate(),@user,@from_location)";
                cmd.Parameters.Add("@product", SqlDbType.NVarChar, 100).Value = product.ToString();
                cmd.Parameters.Add("@serial", SqlDbType.NVarChar, 100).Value = serial.ToString();
                cmd.Parameters.Add("@user", SqlDbType.NVarChar, 100).Value = "1";
                cmd.Parameters.Add("@from_location", SqlDbType.NVarChar, 100).Value = fromlocation.ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
                DB.Close();

            }
            if (what == "mine")
            {
                DB.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DB;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into  product_mine(product,serial,indate,up_user,from_location) values(@product,@serial,getdate(),@user,@from_location)";
                cmd.Parameters.Add("@product", SqlDbType.NVarChar, 100).Value = product.ToString();
                cmd.Parameters.Add("@serial", SqlDbType.NVarChar, 100).Value = serial.ToString();
                cmd.Parameters.Add("@user", SqlDbType.NVarChar, 100).Value = "1";
                cmd.Parameters.Add("@from_location", SqlDbType.NVarChar, 100).Value = fromlocation.ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
                DB.Close();
            }
            if (what == "demo")
            {
                DB.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DB;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into  product_demo(product,serial,indate,up_user,from_location) values(@product,@serial,getdate(),@user,@from_location)";
                cmd.Parameters.Add("@product", SqlDbType.NVarChar, 100).Value = product.ToString();
                cmd.Parameters.Add("@serial", SqlDbType.NVarChar, 100).Value = serial.ToString();
                cmd.Parameters.Add("@user", SqlDbType.NVarChar, 100).Value = "1";
                cmd.Parameters.Add("@from_location", SqlDbType.NVarChar, 100).Value = fromlocation.ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
                DB.Close();
            }

            return "product";
        }
        [WebMethod]
        public string login(string id, string pwd)
        {

            int count = 0;
            string SQL3 = "select count(*) as count from user_ba where id = '" + id + "' and pwd = '" + pwd +"'";
            SqlDataAdapter ADT3 = new SqlDataAdapter(SQL3, DB);
            DataSet DBSET3 = new DataSet();
            ADT3.Fill(DBSET3, "BD");
            foreach (DataRow row in DBSET3.Tables["BD"].Rows)
            {
                count = Convert.ToInt32(row["count"]);
            }

            if(count == 1)
            {
                return "OK";
            }
            else
            {
                return "NO";
            }
            
        }
    }
}
