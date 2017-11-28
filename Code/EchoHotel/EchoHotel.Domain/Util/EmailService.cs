using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Util
{
    public class EmailService
    {
        public void SendMail(string emailAddress)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("csanterio@gmail.com", "****");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;

            MailMessage mail = new MailMessage();

            // Setting From , To and CC
            mail.From = new MailAddress("csanterio@gmail.com", "Echo Hotel");
            mail.To.Add(new MailAddress("csanterio@gmail.com"));
            mail.Body = "Este é um email teste, por favor deconsidere esta mensage!";
            //mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));

            smtpClient.Send(mail);
        }
    }
}
