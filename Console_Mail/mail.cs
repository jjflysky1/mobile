using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Console_Mail
{
    class mail
    {
        int sleep = 10000;
        DBCON.Class1 DBCON = new DBCON.Class1();

        public void Mailthread()
        {
            try
            {
                while (true)
                {

                    SqlConnection CON = new SqlConnection(DBCON.DBCON);
                    string[] id = { };
                    string[] pwd = { };
                    string[] email = { };
                    string tempid = "";
                    string temppwd = "";
                    string tempemail = "";

                    int count = 0;
                    string SQL = "select * from user_ba";
                    SqlDataAdapter ADT = new SqlDataAdapter(SQL, CON);
                    DataSet DBSET = new DataSet();
                    ADT.Fill(DBSET, "BD");
                    foreach (DataRow row in DBSET.Tables["BD"].Rows)
                    {
                        tempid += row["id"].ToString() + ",";
                        temppwd += row["pwd"].ToString() + ",";
                        tempemail += row["email"].ToString() + ",";

                        count++;
                    }

                    id = tempid.Split(',');
                    pwd = temppwd.Split(',');
                    email = tempemail.Split(',');

                    Thread[] thread = new Thread[count];
                    for (int i = 0; i < count; i++)
                    {
                        thread[i] = new Thread(delegate ()
                        {
                            getlist(id[i], pwd[i], email[i]);
                        });

                        thread[i].Start();
                        Thread.Sleep(500);
                    }
                    for (int i = 0; i < count; i++)
                    {
                        thread[i].Join(60000);
                        Thread.Sleep(500);
                        thread[i].Abort();

                    }
                    Thread.Sleep(sleep);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }




        }


        public void getlist(string user_id, string pwd, string email)
        {
            //SmtPop.POP3Client pop = new SmtPop.POP3Client();
            //pop.Open("gw.sungsimit.co.kr", 110, "jjflysky@sungsimit.co.kr", "dnjsvltm1!");
            //// Get message list from POP server
            //SmtPop.POPMessageId[] messages = pop.GetMailList();

            SqlConnection CON = new SqlConnection(DBCON.DBCON);
            string SQL = "select top 1 id from email_list where user_id = '" + user_id + "' order by id desc";
            int end = 0;
            SqlDataAdapter ADT = new SqlDataAdapter(SQL, CON);
            DataSet DBSET = new DataSet();
            ADT.Fill(DBSET, "BD");
            if (DBSET.Tables["BD"].Rows.Count == 0)
            {

            }
            else
            {
                foreach (DataRow row in DBSET.Tables["BD"].Rows)
                {
                    end = Convert.ToInt32(row["id"]);
                }
            }


            //int numChk = 0;
            //bool isNum = int.TryParse(end.ToString(), out numChk);
            //if (!isNum)
            //{
            //    end = 0; //숫자가 아님
            //}
            //else
            //{
            //    //숫자
            //    //숫자일 경우 numChk 의 값은 101 이 된다.
            //}
            try
            {
                Pop3Client objPOP3Client = new Pop3Client();
                objPOP3Client.Connect("sungsim.daouoffice.com", 110, false); //서버접속
                objPOP3Client.Authenticate(email, pwd, AuthenticationMethod.UsernameAndPassword); //서버인증
                var messageCount = objPOP3Client.GetMessageCount(); //받은메일의 메시지 개수
                //var uids = objPOP3Client.GetMessageUids();
                Console.WriteLine(user_id + "  시작!");

                //for (var i = messageCount - 1; i >= 0; i--)
                for (var i = 0; i <= messageCount - 1; i++)
                {
                    //if (Convert.ToInt32(uids[i]) > end)
                    //{
                    var messageBody = "";
                    var attach = "";
                    var opensubject = "";
                    var fromAddress = "";
                    var fromname = "";
                    var cc = "";
                    var email_id = "";
                    DateTime date = DateTime.Now;
                    try
                    {
                        List<Message> allMessages = new List<Message>(messageCount);
                        var message = objPOP3Client.GetMessage(i + 1);

                        messageBody = String.Empty;


                        email_id = message.Headers.MessageId;

                        //원래꺼
                        //if (plainText == null)
                        //{
                        //    var html = message.FindFirstHtmlVersion();
                        //    messageBody = html.GetBodyAsText();
                        //}
                        //else
                        //{
                        //    try
                        //    {
                        //        var html = message.FindFirstHtmlVersion();
                        //        messageBody = html.GetBodyAsText();
                        //    }
                        //    catch(Exception E)
                        //    {
                        //        messageBody = plainText.GetBodyAsText();
                        //        Console.WriteLine("1" + E.Message);
                        //    }


                        //}
                        try
                        {
                            var plainText = message.FindFirstPlainTextVersion();
                            if (plainText == null)
                            {
                                var html = message.FindFirstHtmlVersion();
                                messageBody = html.GetBodyAsText();
                            }
                            else
                            {
                                messageBody = plainText.GetBodyAsText();
                            }

                        }
                        catch (Exception E)
                        {
                            Console.WriteLine(E.Message);
                        }


                        //Label2.Text = messageBody;
                        fromname = message.Headers.From.DisplayName;


                        var sub = message.Headers.Subject;
                        if (sub == null)
                        {
                            //Console.WriteLine("없다");
                            opensubject = "-";
                        }
                        else
                        {
                            opensubject = message.Headers.Subject;
                        }

                        fromAddress = message.Headers.From.Address;
                        var cccount = message.Headers.Cc.Count();
                        if (cccount != 0)
                        {
                            for (var j = cccount - 1; j >= 0; j--)
                            {
                                //Console.WriteLine("subject : " + message.Headers.Cc[j]);
                                cc += message.Headers.Cc[j] + " | ";
                            }
                        }
                        //date = Convert.ToDateTime(message.Headers.Date);


                        SqlConnection CON1 = new SqlConnection(DBCON.DBCON);
                        string SQL1 = "select email_id from email_list where email_id = '" + email_id + "'";
                        SqlDataAdapter ADT1 = new SqlDataAdapter(SQL1, CON1);
                        DataSet DBSET1 = new DataSet();
                        ADT1.Fill(DBSET1, "BD");
                        if (DBSET1.Tables["BD"].Rows.Count != 0)
                        {
                            if (message.Headers.Date != null)
                            {
                                string[] yyyy = message.Headers.Date.Split(null);

                                //Console.WriteLine("연도" + yyyy[3]);
                                //Console.WriteLine("날짜" + yyyy[2]);

                                var regex = new Regex(@"[^a-zA-Z0-9가-힣_]");
                                var attachFile = message.FindAllAttachments();
                                foreach (var currentAttachFile in attachFile)
                                {
                                    //string strFile = "D:\\mobile\\Mail_attach\\" + currentAttachFile.FileName;
                                    //string strFile = "D:\\mobile\\Mail_attach\\"+ user_id + "\\" + date.ToString("yyyy") + "\\" + date.ToString("MM") + "\\" + currentAttachFile.FileName;
                                    string strFile = "D:\\mobile\\Mail_attach\\" + user_id + "\\" + yyyy[3] + "\\" + yyyy[2] + "\\" + Regex.Replace(currentAttachFile.FileName, @"[$&+,:;=?@#'^*%!]", "", RegexOptions.Singleline);

                                    var folder = "D:\\mobile\\Mail_attach\\" + user_id + "\\" + yyyy[3] + "\\" + yyyy[2] + "\\";
                                    if (!Directory.Exists(folder))
                                    {
                                        Directory.CreateDirectory(folder);
                                    }

                                    FileInfo fileInfo = new FileInfo(strFile);
                                    int indexOfDot = currentAttachFile.FileName.LastIndexOf(".");
                                    string strName = currentAttachFile.FileName.Substring(0, indexOfDot);
                                    string strExt = currentAttachFile.FileName.Substring(indexOfDot);
                                    string pathCombine = System.IO.Path.Combine(folder, currentAttachFile.FileName);


                                    if (fileInfo.Exists)
                                    {
                                        //Guid guid = new Guid();
                                        //string a = Guid.NewGuid().ToString("N").Substring(0, 6);

                                        //var attachFileInfo = new FileInfo(@"D:\\mobile\\Mail_attach\\" + user_id + "\\" + yyyy[3] + "\\" +
                                        //    yyyy[2] + "\\" + Regex.Replace(strName + "(" + a.ToString() + ")" + strExt, @"[$&+,:;=?@#'^*%!]", "", RegexOptions.Singleline));
                                        //currentAttachFile.Save(attachFileInfo);
                                        //attach += Regex.Replace(strName + "(" + a.ToString() + ")" + strExt, @"[$&+,:;=?@#'^*%!]", "", RegexOptions.Singleline) + "|";

                                    }
                                    else
                                    {
                                        var attachFileInfo = new FileInfo(@"D:\\mobile\\Mail_attach\\" + user_id + "\\" + yyyy[3] + "\\" + yyyy[2] + "\\" + Regex.Replace(currentAttachFile.FileName, @"[$&+,:;=?@#'^*%!]", "", RegexOptions.Singleline));
                                        currentAttachFile.Save(attachFileInfo);
                                        attach += Regex.Replace(currentAttachFile.FileName, @"[$&+,:;=?@#'^*%!]", "", RegexOptions.Singleline) + "|";
                                    }
                                    //Label4.Text += "<a href='" + "http://192.168.0.190:86/Mail_attach/" + currentAttachFile.FileName + "'>" + currentAttachFile.FileName + "</a>" + "   ";

                                }
                            }
                        }
                        else
                        {

                        }



                    }
                    catch (Exception E)
                    {
                        Console.WriteLine("2" + E.Message);
                    }

                    //string htmlTagPattern = "<[^>]*>";
                    //var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    //messageBody = regexCss.Replace(messageBody, string.Empty);
                    //messageBody = Regex.Replace(messageBody, htmlTagPattern, string.Empty);
                    //messageBody = Regex.Replace(messageBody, @"^\s*$\n", "", RegexOptions.Multiline);
                    //messageBody = messageBody.Replace("&nbsp;", string.Empty);
                    if (email_id.ToString().Length <= 0)
                    {
                        email_id = "0";
                    }

                    CON.Open();
                    SqlCommand cmd = new SqlCommand("add_email", CON);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fromname", fromname);
                    cmd.Parameters.AddWithValue("@fromadress", fromAddress);
                    cmd.Parameters.AddWithValue("@cc", cc);
                    cmd.Parameters.AddWithValue("@subject", opensubject);
                    cmd.Parameters.AddWithValue("@date", date);
                    //cmd.Parameters.AddWithValue("@id", uids[i]);
                    cmd.Parameters.AddWithValue("@user_id", user_id);
                    cmd.Parameters.AddWithValue("@body", messageBody);
                    cmd.Parameters.AddWithValue("@attach", attach);
                    cmd.Parameters.AddWithValue("@email_id", email_id);
                    //cmd.Parameters.AddWithValue("@user_id", Request.Cookies["ID"].Value);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cmd = null;
                    CON.Close();
                }

                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            //foreach (SmtPop.POPMessageId id in messages.Reverse())
            //{

            //}


            //pop.Quit();




        }
    }
}
