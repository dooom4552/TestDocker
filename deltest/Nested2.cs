using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace deltest
{
    class Nested2 : Abstr
    {
        public override void Metodd(string name)
        {
            MailAddress From = new MailAddress("dooom4552@yandex.ru","Sasha");

            MailAddress To = new MailAddress("severenok@mail.ru");

            MailMessage msg = new MailMessage(From, To);

            msg.Subject = name;
            msg.Body = "<h4>fghfghfg<h4>";
            msg.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.yandex.ru",587);
            smtp.Credentials = new NetworkCredential("dooom4552@yandex.ru", "Ritasasha1885");
            smtp.EnableSsl = true;
            smtp.Send(msg);
        }
    }
}
