using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer.UserManagement
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            const string from = "artemy.sinitsa@gmail.com";
            const string password = "artemy0431";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(from, password),
                EnableSsl = true
            };

            var mail = BuildMessage(from, message);

            return client.SendMailAsync(mail);
        }

        public MailMessage BuildMessage(string sender, IdentityMessage message)
        {
            var mail = new MailMessage(sender, message.Destination);
            mail.Subject = message.Subject;
            mail.Body = message.Body;
            mail.IsBodyHtml = true;

            return mail;
        }
    }
}
