using System;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace IOTWaterloo_JobBoard
{
    public class Uility
    {
        public static bool SendMail(string strFrom, string strTo, string strSubject, string strMsg)
        {
            try
            {
                // Create the mail message
                MailMessage objMailMsg = new MailMessage(strFrom, strTo);

                objMailMsg.BodyEncoding = Encoding.UTF8;
                objMailMsg.Subject = strSubject;
                objMailMsg.Body = strMsg;
                Attachment data = new Attachment(
                         "PATH_TO_YOUR_FILE",
                         MediaTypeNames.Application.Octet);
                // your path may look like Server.MapPath("~/file.ABC")
                objMailMsg.Attachments.Add(data);

                objMailMsg.Priority = MailPriority.High;
                objMailMsg.IsBodyHtml = true;

                //prepare to send mail via SMTP transport
                SmtpClient objSMTPClient = new SmtpClient();
                objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                objSMTPClient.Send(objMailMsg);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
