using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;

namespace mobile1.FCM
{
    public class FCMSEND
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        public void send(string gettitle, string getbody)
        {

            string SQL = "select * from device_token";
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, DB);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            foreach (DataRow row in DBSET.Tables["BD"].Rows)
            {

                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                //serverKey - Key from Firebase cloud messaging server  
                tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAukYEuxs:APA91bERLOVuHKqXeBN-G4wh23FgskupNJDDYxRxgMQA1LfgUx0cN7Z93Yukv3il7Rgfyi7xuvJxl-Bb0AjneX69OMRuqTqm8rUs9P7Pqt0Asmt3S68LjwGfwq5m9E5T7mwzwETIuVAe"));
                //Sender Id - From firebase project setting  
                tRequest.Headers.Add(string.Format("Sender: id={0}", "800038632219"));
                tRequest.ContentType = "application/json";
                var payload = new
                {
                    to = "cnuw_-zxs3I:APA91bHfrYDNSb56ztNmSTEi3STZugRUg5CcCK7qJf1baqgnIXwGwH0EQsF7_GxIExuwe6uuGakB6NmVE9FU9I2U2SEK0nPeFpwkUgQkZNEXPjw1z61czP-XxBwzbm5fHzfQoSdoni8g",
                    //to= row["token"].ToString(),
                    priority = "high",
                    content_available = true,
                    notification = new
                    {
                        title = gettitle,
                        body = getbody,
                        badge = 1
                    },
                };

                string postbody = JsonConvert.SerializeObject(payload).ToString();
                Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                {
                                    String sResponseFromServer = tReader.ReadToEnd();
                                    //result.Response = sResponseFromServer;
                                }
                        }
                    }
                }



            }


        }
    }
}