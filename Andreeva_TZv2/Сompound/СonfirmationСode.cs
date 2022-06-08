using System;
using System.Net;
using System.Net.Mail;

namespace Andreeva_TZv2.Сompound
{
    internal class СonfirmationСode
    {
        private static MailAddress myAdress = new MailAddress("ktkAbramv4@gmail.com", "DayAndNight");
        private static MailAddress clientAdress;

        private static string allowChar = "1234567890";
        private static string confirmationСode; 

        public СonfirmationСode(string _emailAdressClien, string _name)
        {
            confirmationСode = CreateConfirmationСode();

            clientAdress = new MailAddress(_emailAdressClien, _name);

            MailMessage message = new MailMessage(myAdress, clientAdress);
            message.Body = confirmationСode.ToString();
            message.Subject = "Не сообщайте никому код подтверждения";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(myAdress.Address, "Kartochka_228");

            smtpClient.Send(message);
        }

        private string CreateConfirmationСode()
        { 
            string pwd = "";
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                pwd += allowChar.Substring(random.Next(0, allowChar.Length), 1);
            }
            return pwd;
        }
        
        public string GetСonfirmationСode()
        {
            return confirmationСode;
        }
    }
}
