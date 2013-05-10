using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiLab.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            
            return View();
        }

        public ActionResult Spedizione()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
        public ActionResult Pagamento()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult Faqs()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";




            return View();
        }
        [HttpPost]
        public ActionResult Contact(FormCollection collection)
        {
            string indirizzo = collection["Email"];
            string name = collection["Name"];
            string text = collection["textarea"];

            KiLab.Services.SendMail mail = new KiLab.Services.SendMail();
            bool esito = mail.SendToMe(name + " " + text, indirizzo);


            if (esito == true)
            {
                ViewBag.Alert = "La mail è stata spedita.";
            }
            else
            {
                ViewBag.Alert = "Errore del server, ti preghiamo di contattarci scrivendo una mail all'indirizzo info@coffeetesi.it";
            }

            

            return View();
        }

    }
}
