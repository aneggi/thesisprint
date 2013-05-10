using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiLab.Models;
using System.IO;

namespace KiLab.Controllers
{
    public class StatoController : Controller
    {
        private TesiContainer db = new TesiContainer();

        //
        // GET: /Stato/

        public ActionResult Index()
        {
            if (Session["currentOrder"] != null)
            {
                int id = (int)Session["currentOrder"];
                var ord = (from c in db.Ordine where c.Id == id select c).FirstOrDefault();
                //var file = ord.File.ToList();
                var file = (from c in db.File where ((c.Eliminato != true) && (c.OrdineID == id)) select c).ToList();
                ViewBag.Ordine = ord;
                return View(file.ToList());
            }
            else
            {

                

                return RedirectToAction("noauth");
            }
            
            
        }


        public ActionResult Test()
        {

            //KiLab.Models.gOrder o = new KiLab.Models.gOrder();
            //o.getById("5");



            return View();
            


        }


        public ActionResult noauth()
        {
            
            return View();
            


        }


        [HttpPost]
        public ActionResult noauth(FormCollection collection)
        {

            string indirizzo = collection["email"];

            var ord = (from c in db.Ordine where c.Email == indirizzo select c).FirstOrDefault();

            if (ord != null)
            {
                //Session["currentOrder"] = ord.Id;
                KiLab.Services.SendMail mail = new KiLab.Services.SendMail();
                bool esito = mail.SendAccess(ord.Id);

                if (esito == true)
                {
                    ViewBag.Alert = "La mail è stata spedita.";
                }
                else
                {
                    ViewBag.Alert = "Errore del server, ti preghiamo di contattarci scrivendo una mail all'indirizzo info@coffeetesi.it";
                }
                return View();
                //return RedirectToAction("index", "Home");
            }
            else
            {
                ViewBag.Alert = "Mi dispiace ma la mail indicata non risulta nei nostri database.";
                //Session["currentOrder"] = 21;
                return View();
            }

            

             
            

            



        }


        //
        // GET: /Stato/Details/5

        public ActionResult Details(int id = 0)
        {
            KiLab.Models.File file = db.File.Single(f => f.Id == id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        

        //
        // GET: /Stato/Edit/5

        public ActionResult Edit(int id = 0)
        {
            KiLab.Models.File file = db.File.Single(f => f.Id == id);
            if (file == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrdineID = new SelectList(db.Ordine, "Id", "Email", file.OrdineID);
            return View(file);
        }

        //
        // POST: /Stato/Edit/5

        [HttpPost]
        public ActionResult Edit(KiLab.Models.File file)
        {
            if (ModelState.IsValid)
            {
                db.File.Attach(file);
                db.ObjectStateManager.ChangeObjectState(file, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrdineID = new SelectList(db.Ordine, "Id", "Email", file.OrdineID);
            return View(file);
        }

        //
        // GET: /Stato/Delete/5

        public ActionResult Delete(int id = 0)
        {
            KiLab.Models.File file = db.File.Single(f => f.Id == id);
            if (file == null)
            {
                return HttpNotFound();
            }
            else
            {
                file.Eliminato = true;
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }

        //
        // POST: /Stato/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            KiLab.Models.File file = db.File.Single(f => f.Id == id);
            file.Eliminato = true;
            //db.File.DeleteObject(file);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }





        public ActionResult upload()
        {

            return View();
        }

        //
        // POST: /Tesionline/Delete/5

        [HttpPost]
        public ActionResult upload( HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    int ordId = (int)Session["currentOrder"];

                    var fileName = ordId + "_" + Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/Uploads"), fileName);
                    file.SaveAs(path);

                    KiLab.Models.File f = new KiLab.Models.File();
                    f.OrdineID = ordId;
                    f.Nome = fileName;
                    f.PercorsoFisico = path;
                    f.Stampato = false;
                    f.Bozza = false;
                    f.Data = DateTime.Now;
                    f.DimensioneKb = file.ContentLength;
                    f.Eliminato = false;
                    db.File.AddObject(f);
                    db.SaveChanges();


                }


                return RedirectToAction("index");
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