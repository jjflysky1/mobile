using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class MSSQL 
    {
        private SqlConnection DB = new SqlConnection("server = 192.168.0.190; uid = nms; pwd = P@ssw0rd; database = mobile;");
        public DataSet select(string SQL)
        {
            //SQL = "select top 5 * from notice where flag = '1' order by no desc";

            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            //foreach (DataRow row in DBSET.Tables["BD"].Rows)
            //{
            //    //Console.WriteLine(row["title"].ToString());
            //}

            return DBSET;
        }
    }
}
