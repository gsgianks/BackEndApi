using System;
using System.Net;
using System.Net.Mail;

namespace Servicios.Common
{
    public class Email
    {
        public static void sendMail(string email, string password) {
            try
            {
                var fromAddress = new MailAddress("gsgianks@gmail.com");
                var fromPassword = "kitgavuubsvbthny";
                var toAddress = new MailAddress(email);

                string subject = "Sistema UMA";
                string body = "La contraseña para ingresar al sistema es: "+password;

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,

                })


                    smtp.Send(message);
                smtp.Dispose();
            }
            catch (Exception ex)
            {
                var x = ex;
            }
        }
    }
}
