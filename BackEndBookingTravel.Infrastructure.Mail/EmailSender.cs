using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(string toEmail, string subject)
        {
            // Set up SMTP client
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("your-email-address@gmail.com", "your-email-password");

            // Create email message
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("your-email-address@gmail.com");
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat("<h1>Reserva Creada</h1>");
            mailBody.AppendFormat("<br />");
            mailBody.AppendFormat("<p>Gracias por reservar con nosotros</p>");
            mailMessage.Body = mailBody.ToString();

            // Send email
            client.Send(mailMessage);
        }
    }
}