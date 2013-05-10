using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiLab.Models;
using System.IO;


namespace KiLab.Controllers
{

    
    public class TesionlineController : Controller
    {
        public TesiContainer db = new TesiContainer();
        //private OrderDBContext db1 = new OrderDBContext();


        public ActionResult Open(int id, string code)
        {
            var ord = (from c in db.Ordine where c.Id == id select c).FirstOrDefault();
            if (ord.Token == code)
            {
                Session["currentOrder"] = id;
               
            }
            else
            {
                Session.Clear();
            }
                return RedirectToAction("index","Stato");

            
        }


        public ActionResult Close()
        {
            Session.Clear();
            return RedirectToAction("index", "Home");
        }






        //
        // GET: /Tesionline/

        public ActionResult Index()
        {


            ViewBag.Rillegature = (from c in db.Rilegatura where c.delete == false select c).ToList();
            ViewBag.Spedizioni = db.Spediz.ToList();

            if (Session["currentOrder"] != null)
            {
                
                int id = (int)Session["currentOrder"];
                var ord = (from c in db.Ordine where c.Id == id select c).FirstOrDefault();

                if (ord.StPagato20 != null)
                {
                    return RedirectToAction("indexPayed");
                }
                else
                {
                    return View(ord);
                }

                
            }
            else
            {
                return View();
            }

           
        }


        public ActionResult IndexPayed()
        {

            
            int id = (int)Session["currentOrder"];
            var ord = (from c in db.Ordine where c.Id == id select c).FirstOrDefault();
            
            
            return View(ord);
           


        }




        [HttpPost]
        public ActionResult Index(Ordine ordin )//FormCollection collection
        {
            try
            {
                if (Session["currentOrder"] == null)
                {
                    ordin.Data = DateTime.Now;
                    ordin.Eliminato = false;
                    //creiamo il codice di sicurezza per garantire l'accesso al solo propietario
                    var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    var random = new Random();
                    string result = new string(
                        Enumerable.Repeat(chars, 64)
                                  .Select(s => s[random.Next(s.Length)])
                                  .ToArray());
                    ordin.Token = result;
                    ordin.TokenScadenza = DateTime.Now.AddDays(150);
                    db.Ordine.AddObject(ordin);
                    db.SaveChanges();
                    Session["currentOrder"] = ordin.Id;
                }
                
                return RedirectToAction("personali");
            }
            catch
            {
                return View();
            }
        }




       



        //
        // POST: /Tesionline/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Tesionline/Edit/5

        public ActionResult personali()
        {
            int id = (int)Session["currentOrder"];
            var ord = (from c in db.Ordine where c.Id == id select c).FirstOrDefault();

            return View(ord);
        }

        //
        // POST: /Tesionline/Edit/5

        [HttpPost]
        public ActionResult personali(int id, Ordine ordin)
        {
            try
            {
                var ord = (from c in db.Ordine where c.Id == id select c).FirstOrDefault();
                ord.Email = ordin.Email;
                ord.Cellulare = ordin.Cellulare;
                ord.CodFiscalePersonale = ordin.CodFiscalePersonale;
                ord.SpedCAP = ordin.SpedCAP;
                ord.SpedCitta = ordin.SpedCitta;
                ord.SpedCognome = ordin.SpedCognome;
                ord.SpedIndirizzo = ordin.SpedIndirizzo;
                ord.SpedNome = ordin.SpedNome;
                ord.GiornoLaurea = ordin.GiornoLaurea;

                db.SaveChanges();

                KiLab.Services.SendMail m = new KiLab.Services.SendMail();
                m.SendAccess(id);

                return RedirectToAction("pagamento", new { id = ordin.Id });
            }
            catch
            {
                return View();
            }
        }




        public ActionResult pagamento()
        {
            int id = (int)Session["currentOrder"];
            var ord = (from c in db.Ordine where c.Id == id select c).FirstOrDefault();
            if (ord.StAperto10 == null)
            {
                ord.StAperto10 = DateTime.Now;
            }

            db.SaveChanges();
            return View(ord);
        }

        //
        // POST: /Tesionline/Edit/5

        [HttpPost]
        public ActionResult pagamento(int id, Ordine ordin)
        {
            try
            {
                var ord = (from c in db.Ordine where c.Id == id select c).FirstOrDefault();
                ord.Email = ordin.Email;
                ord.Cellulare = ordin.Cellulare;
                ord.CodFiscalePersonale = ordin.CodFiscalePersonale;
                ord.SpedCAP = ordin.SpedCAP;
                ord.SpedCitta = ordin.SpedCitta;
                ord.SpedCognome = ordin.SpedCognome;
                ord.SpedIndirizzo = ordin.SpedIndirizzo;
                ord.SpedNome = ordin.SpedNome;
                ord.GiornoLaurea = ordin.GiornoLaurea;


                return RedirectToAction("pagamento", new { id = ordin.Id });
            }
            catch
            {
                return View();
            }
        }





        //
        // GET: /Tesionline/Delete/5

        public ActionResult uploadFiles()
        {

            return View();
        }

        //
        // POST: /Tesionline/Delete/5

        [HttpPost]
        public ActionResult uploadFiles( HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0) {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/Uploads"), fileName);
                    file.SaveAs(path);
                    KiLab.Models.File fi = new KiLab.Models.File();
                    fi.Data = DateTime.Now;
                    fi.Eliminato = false;
                    fi.Nome = fileName;
                    fi.PercorsoFisico = path;
                    fi.Stampato = false;
                    //fi.OrdineID = 
                }
                

                return RedirectToAction("uploadFiles");
            }
            catch (InvalidCastException e) 
            {
                Logs log = new Logs();
                log.Data = DateTime.Now;
                log.Testo = e.ToString();
                db.Logs.AddObject(log);
                db.SaveChanges();

                return View();
            }
        }



        



    }
}
