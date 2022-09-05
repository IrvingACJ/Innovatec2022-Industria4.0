using System; 
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
namespace Innovatec.Class
{
    public class Email
    {

        /// <summary>
        /// METHOD - SEND EMAIL
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public string SendMail(string receiver, string body)
        {
            using (SmtpClient smtp = new SmtpClient("smtp.office365.com", 587))
            {
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("replyweighingsystem@outlook.com", "Irvando8)123");
                //smtp.EnableSsl = true;
                //smtp.UseDefaultCredentials = false;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                var message = new MailMessage();
                MailAddress from = new MailAddress("replyweighingsystem@outlook.com", "Weighing System");
                //Recipient
                MailAddress to = new MailAddress(receiver);
                //Mail Info
                MailMessage email = new MailMessage(from, to)
                {
                    Subject = "ALERTA WEIGHING SYSTEM",
                    IsBodyHtml = true,
                    Body = body,
                    BodyEncoding = Encoding.GetEncoding("utf-8"),
                    Priority = MailPriority.Normal
                };
                try
                {
                    smtp.Send(email);
                    return "";
                }
                catch (Exception ex)
                {
                    return "error sending email";
                }

            }
        }

        /// <summary>
        /// METHOD- SELECT A TEMPLATE FOR EMAIL
        /// </summary>
        /// <param name="link"></param>
        /// <param name="path"></param>
        /// <param name="user"></param>
        /// <param name="type"></param>
        /// <param name="qty"></param>
        /// <returns></returns>
        public string Selector(string home, string path, string componente, string destinatario)
        {
            string message = "";
            using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var reader = new StreamReader(file);
                message = reader.ReadToEnd();
                message = message.Replace("@COMPONENTE", componente);
                message = message.Replace("@HOME", home);
            }
            return SendMail(destinatario, message);
        }
    }
}
