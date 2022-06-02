using System.Net;
using System.Net.Mail;
using System.Text;
using ChineseSneakers.Models;

namespace ChineseSneakers;

public class Service
{
    private readonly ILogger<Service> Logger;

    public Service(ILogger<Service> logger) => Logger = logger;

    public void SendEmail(OrderModel orderModel)
    {
        try
        {
            var msg = new MailMessage();
            msg.IsBodyHtml = true;
            msg.From = new MailAddress("admin@chinessesneakers.ru", "Магазин кросовок");
            msg.To.Add(orderModel.Email);
            msg.Subject = "Вы приобрели кроссовки:";

            List<string> sneakers_models = new List<string>();
            List<LinkedResource> sneakers_images = new List<LinkedResource>();
            var htmlView = AlternateView.CreateAlternateViewFromString("");

            int index = 0;
            string htmlView_Line = "";

            foreach (var od in orderModel.OrderDetails)
            {
               sneakers_images.Add(new LinkedResource("wwwroot" + od.SneakersModel.Image));
               sneakers_images[index].ContentId = "ID" + od.Id;
               htmlView_Line += ("<p>" 
                                 + od.SneakersModel.LongDescription 
                                 + "</p>" + "img style='width: 500px' src=cid:" 
                                 + sneakers_images[index].ContentId 
                                 + ">");
               index++;
            }

            htmlView = AlternateView.CreateAlternateViewFromString(htmlView_Line, null, "text/html");
            index = 0;

            foreach (var odm in orderModel.OrderDetails)
            {
                htmlView.LinkedResources.Add(sneakers_images[index]);
                index++;
            }
            msg.AlternateViews.Add(htmlView);

            using (SmtpClient client = new SmtpClient("smtp.yandex.com"))
            {
                client.Credentials = new NetworkCredential("superkotopess@yandex.ru", "zHeccrbq78");
                client.Port = 465;
                client.EnableSsl = true;
                client.Send(msg);
                Logger.LogInformation("Сообщение успешно отправлено");
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.GetBaseException().Message);
        }

        
    }
}