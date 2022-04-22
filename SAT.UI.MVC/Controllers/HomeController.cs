using System.Web.Mvc;
using SAT.UI.MVC.Models;
using System.Net;
using System.Net.Mail;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }
            string message = $"You have recieved an email from {cvm.Name}.<br />" +
                $"Subject: {cvm.Subject}<br />" +
                $"Message: {cvm.Message}<br />" +
                $"Please reply to {cvm.Email} with your response at your earliest convenience.";


            MailMessage mm = new MailMessage("administrator@kaylawin.com", "kayla.nghi.nguyen@gmail.com", cvm.Subject, message);


            //MailMessage Properties
            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.High;
            //Reply to the sender, and not our website/webmail
            mm.ReplyToList.Add(cvm.Email);

            //SmtpClient - info from host that allows emails to be sent
            SmtpClient client = new SmtpClient("mail.kaylawin.com");


            //Client Credentials
            client.Credentials = new NetworkCredential("administrator@kaylawin.com", "P@ssw0rd");


            //Port options -- SMTP uses two ports 25 and 8889. Test with both to determine if your internet provider blocks/does not use one of these. 
            //client.Port = 25;
            client.Port = 8889;

            //Try to send the email
            try
            {
                //Attempt to send email
                client.Send(mm);
            }
            catch (System.Exception ex)
            {
                ViewBag.CustomerMessage = $"We're sorry, your request could not be completed at this time. Please try again later. If the issue persists, please contact your site admnistrator and provide the following information:<br />{ex.StackTrace}";
                return View(cvm);
            }

            return View("EmailConfirmation", cvm);
        }
    }
}
