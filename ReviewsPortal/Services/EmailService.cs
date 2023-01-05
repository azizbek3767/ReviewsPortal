using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace ReviewsPortal.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("azizbekba25", "azizbekba25@yandex.ru"));
            //emailMessage.From.Add(new MailboxAddress("Azizbek", "azizbekk3767@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            /*using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 25, false);
                await client.AuthenticateAsync("azizbekba25@yandex.ru", "azizbekYandex2565");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }*/

            /*using (var client = new SmtpClient())
            {
                client.Connect("smtp.yandex.ru", 25, false);
                client.Authenticate("azizbekba25@yandex.ru", "azizbekYandexEmail2565");
                client.Send(emailMessage);
                client.Disconnect(true);
            }*/
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 465, true);
                //await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync("azizbekba25@yandex.ru", "azizbekYandexEmail2565");
                //await client.AuthenticateAsync("kkddazizbek@gmail.com", "azizbekYouanv");
                //await client.AuthenticateAsync("azizbekba25@gmail.com", "25651800");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
