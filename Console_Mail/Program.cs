using System.Threading;

namespace Console_Mail
{
    class Program
    {
        static void Main(string[] args)
        {
            mail mail = new mail();


            Thread thread1 = new Thread(mail.Mailthread);
            thread1.Start();

            //try
            //{
            //    using (Pop3Client client = new Pop3Client())
            //    {
            //        client.Connect("sungsim.daouoffice.com", 110, false); //서버접속
            //        client.Authenticate("jjflysky@sungsimit.co.kr", "dnjsvltm1!", AuthenticationMethod.UsernameAndPassword); //서버인증
            //        var messageCount = client.GetMessageCount(); //받은메일의 메시지 개수
            //        List<Message> allMessages = new List<Message>(messageCount);

            //        for (var i = 1; i < messageCount; i++)
            //        {
            //            var message = client.GetMessage(i);
            //            var fromAddress = message.Headers.From.Address;
            //            var subject = message.Headers.Subject;
            //            var messageBody = String.Empty;

            //            var plainText = message.FindFirstPlainTextVersion();

            //            if (plainText == null)
            //            {
            //                var html = message.FindFirstHtmlVersion();
            //                messageBody = html.GetBodyAsText();
            //            }
            //            else
            //            {
            //                messageBody = plainText.GetBodyAsText();
            //            }

            //            var attachFile = message.FindAllAttachments();

            //            //Console.WriteLine("fromAddress : " + fromAddress + "<br />");
            //            Console.WriteLine("subject : " + subject + "<br />");
            //            //Console.WriteLine("messageBody : " + messageBody + "<br />");
            //            //Console.WriteLine("attachFileCount : " + attachFile.Count + "<br />");
            //            //Console.WriteLine("MessageId : " + message.Headers.MessageId + "<br />");

            //            //Console.WriteLine("MessageId : " + message.Headers.Date + "<br />");
            //            ////                    DateTime date = DateTime.ParseExact(message.Headers.Date, "yyyy", null);
            //            if(message.Headers.Date != null)
            //            {
            //                string[] yyyy = message.Headers.Date.Split(null);
            //            }

            //            //Console.WriteLine("연도" + yyyy[3]);
            //            //Console.WriteLine("날짜" + yyyy[1]);


            //            //foreach (var currentAttachFile in attachFile)
            //            //{
            //            //    Console.WriteLine("currentAttachFile : " + currentAttachFile.FileName + "<br />");
            //            //    var attachFileInfo = new FileInfo(@"c:\yourpath\" + currentAttachFile.FileName);
            //            //    currentAttachFile.Save(attachFileInfo);
            //            //}

            //            Console.WriteLine("<br /><br /><br />");
            //        }

            //        Console.WriteLine("messageCount : " + messageCount);
            //    }
            //}
            //catch(Exception E)
            //{
            //    Console.WriteLine(E.Message);
            //}


        }
    }
}
