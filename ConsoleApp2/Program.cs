using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


using System.Net.Sockets;
using System.Data;
using System.Threading;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread thread = new Thread(test);
            //thread.Start();

            //Thread thread2 = new Thread(test2);
            //thread2.Start();

            test2();

        }
        public static void test3()
        {
           
        }
        public static void test2()
        {
            Pop3Client objPOP3Client = new Pop3Client();
            objPOP3Client.Connect("gw.sungsimit.co.kr", 110, false); //서버접속
            objPOP3Client.Authenticate("jjflysky@sungsimit.co.kr", "dnjsvltm1!", AuthenticationMethod.UsernameAndPassword); //서버인증
            var messageCount = objPOP3Client.GetMessageCount(); //받은메일의 메시지 개수
            var uids = objPOP3Client.GetMessageUids();
            Console.WriteLine( "  시작!");

            //for (var i = messageCount - 1; i >= 0; i--)
            for (var i = 0; i <= messageCount - 1; i++)
            {
                if (Convert.ToInt32(uids[i]) == 1164)
                {
                    var messageBody = "";
                    var attach = "";
                    var opensubject = "";
                    var fromAddress = "";
                    var fromname = "";
                    var cc = "";
                    DateTime date = DateTime.Now;
                    //try
                    //{
                        List<Message> allMessages = new List<Message>(messageCount);
                        var message = objPOP3Client.GetMessage(i + 1);

                        messageBody = String.Empty;
                        var plainText = message.FindFirstPlainTextVersion();
                        if (plainText == null)
                        {
                            var html = message.FindFirstHtmlVersion();
                            messageBody = html.GetBodyAsText();
                        }
                        else
                        {
                            var html = message.FindFirstHtmlVersion();
                            //messageBody = html.GetBodyAsText();
                            messageBody = plainText.GetBodyAsText();
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

                    string htmlTagPattern = "<[^>]*>";
                    var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    messageBody = regexCss.Replace(messageBody, string.Empty);
                    //messageBody = Regex.Replace(messageBody, htmlTagPattern, string.Empty);
                    //messageBody = Regex.Replace(messageBody, @"^\s*$\n", "", RegexOptions.Multiline);
                    //messageBody = Regex.Replace(messageBody, @"^\r\n", "<br>");
                    messageBody = messageBody.Replace("&nbsp;", string.Empty);
                    

                    Console.WriteLine(sub);
                    //}
                    //catch(Exception e)
                    //{
                    //    Console.WriteLine("에러"+e.Message);
                    //}


                    var attachFile = message.FindAllAttachments();


                    foreach (var currentAttachFile in attachFile)
                    {
                        Console.WriteLine(currentAttachFile.FileName);
                        //string strFile = "D:\\mobile\\Mail_attach\\" + currentAttachFile.FileName;
                        //string strFile = "D:\\mobile\\Mail_attach\\"+ user_id + "\\" + date.ToString("yyyy") + "\\" + date.ToString("MM") + "\\" + currentAttachFile.FileName;
                        //string strFile = "D:\\mobile\\Mail_attach\\" + user_id + "\\" + date.ToString("yyyy") + "\\" + date.ToString("MM") + "\\" + Regex.Replace(currentAttachFile.FileName, @"[$&+,:;=?@#'^*%!]", "", RegexOptions.Singleline);

                        //var folder = "D:\\mobile\\Mail_attach\\" + user_id + "\\" + date.ToString("yyyy") + "\\" + date.ToString("MM") + "\\";
                        //if (!Directory.Exists(folder))
                        //{
                        //    Directory.CreateDirectory(folder);
                        //}

                        //FileInfo fileInfo = new FileInfo(strFile);
                        //if (fileInfo.Exists)
                        //{

                        //}
                        //else
                        //{
                        //    //var attachFileInfo = new FileInfo(@"D:\\mobile\\Mail_attach\\" + user_id + "\\" + date.ToString("yyyy") + "\\" + date.ToString("MM") + "\\" + Regex.Replace(currentAttachFile.FileName, @"[$&+,:;=?@#'^*%!]", "", RegexOptions.Singleline));


                        //    currentAttachFile.Save(attachFileInfo);
                        //}
                        //Label4.Text += "<a href='" + "http://192.168.0.190:86/Mail_attach/" + currentAttachFile.FileName + "'>" + currentAttachFile.FileName + "</a>" + "   ";
                        //attach += Regex.Replace(currentAttachFile.FileName, @"[$&+,:;=?@#'^*%!]", "", RegexOptions.Singleline) + "|";
                    }
                }
            }
        }
        public static void test()
        {
            Pop3Client objPOP3Client = new Pop3Client();
            objPOP3Client.Connect("gw.sungsimit.co.kr", 110, false); //서버접속
            objPOP3Client.Authenticate("jjflysky@sungsimit.co.kr", "dnjsvltm1!", AuthenticationMethod.UsernameAndPassword); //서버인증
            //objPOP3Client.Authenticate("maria58@sungsimit.co.kr", "msaint2158*", AuthenticationMethod.UsernameAndPassword); //서버인증

            var messageCount = objPOP3Client.GetMessageCount(); //받은메일의 메시지 개수

            

            var uids = objPOP3Client.GetMessageUids();

            List<string> messageUids = objPOP3Client.GetMessageUids();
            Console.WriteLine(messageCount);
            int a = 0;
            //for (var i = messageCount-1; i >= 0; i--)
            for (var i = 0; i <= messageCount - 1; i++)
            {
                var messageBody = "";
                var attach = "";
                var opensubject = "";
                var fromAddress = "";
                var fromname = "";
                var cc = "";
                DateTime date = DateTime.Now;
                try
                {
                    List<Message> allMessages = new List<Message>(messageCount);
                    var message = objPOP3Client.GetMessage(i + 1);

                    messageBody = String.Empty;
                    var plainText = message.FindFirstPlainTextVersion();
                    if (plainText == null)
                    {
                        var html = message.FindFirstHtmlVersion();
                        messageBody = html.GetBodyAsText();
                    }
                    else
                    {
                        var html = message.FindFirstHtmlVersion();
                        messageBody = html.GetBodyAsText();
                        //messageBody = plainText.GetBodyAsText();
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
                }catch
                {

                }
                    //if (Convert.ToInt32(uids[i]) > 10)
                    //{
                    //    Console.WriteLine("i: " + i);
                    //    try
                    //    {
                    //        //var fromAddress = message.Headers.From.DisplayName;
                    //        //var subject = message.Headers.Subject;
                    //        //var messageBody = String.Empty;
                    //        //var time = message.Headers.Date;


                    //        //var messageBody = "";
                    //        message = objPOP3Client.GetMessage(i + 1);
                    //        Console.WriteLine("MessageId : " + Convert.ToInt32(uids[i]));

                    //        Console.WriteLine();
                    //        Console.WriteLine("subject : " + message.Headers.Subject);


                    //        //
                    //        //var cccount = message.Headers.Cc.Count();
                    //        //if(cccount != 0)
                    //        //{
                    //        //    for (var j = cccount-1; j >= 0; j--)
                    //        //    {
                    //        //        Console.WriteLine("subject : " + message.Headers.Cc[j]);

                    //        //    }
                    //        //}



                    //        //messageBody = String.Empty;
                    //        //var plainText = message.FindFirstPlainTextVersion();
                    //        //if (plainText == null)
                    //        //{
                    //        //    var html = message.FindFirstHtmlVersion();
                    //        //    messageBody = html.GetBodyAsText();
                    //        //}
                    //        //else
                    //        //{
                    //        //    messageBody = plainText.GetBodyAsText();
                    //        //}
                    //        //Console.WriteLine("body : " + messageBody);

                    //    }
                    //    catch (Exception e)
                    //    {
                    //        Console.WriteLine(e.Message);
                    //    }
                    //}


                    a++;
            }
            Console.WriteLine(a);
            //Console.Write("messageCount : " + messageCount);
        }
    }
}
