using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using KiLab.Models;

namespace KiLab.Services
{
    public class SendMail
    {

        private TesiContainer db = new TesiContainer();


        public bool SendToMe(string testo, string mittente)
        {
            return this.Send("COFFEETESI-Modulo online", testo, "info@coffeetesi.it", mittente);
        }

        public bool SendFromeMe(string oggetto, string testo, string destinatario)
        {
            return this.Send(oggetto, testo, destinatario, "info@coffeetesi.it");
        }

        public bool Send(string oggetto, string testo, string destinatario, string mittente)
        {

            try
            {
                MailMessage msg = new MailMessage();
                msg.IsBodyHtml = true;
                msg.Subject = oggetto;
                msg.Body = testo;
                msg.From = new MailAddress(mittente);
                msg.To.Add(new MailAddress(destinatario));
                msg.Bcc.Add(new MailAddress("info@coffeetesi.it"));


                SmtpClient sc = new SmtpClient();
                sc.Host = "mail.coffeetesi.it";
                sc.Port = 25;
                sc.Credentials = new System.Net.NetworkCredential("coffeetesi.it@coffeetesi.it", "taloozoo");
                sc.EnableSsl = false; // runtime encrypt the SMTP communications using SSL
                sc.Send(msg);
                return true;
            }
            catch (Exception e)
            {
                //KiLab.Models.Logs l = KiLab.Models.Logs();
                //l.Data = DateTime.Now;
                //l.Testo = e.ToString();
                //db.Logs.AddObject(l);
                //db.SaveChanges();


                return false;
            }

            
        }
        public bool SendAccess(int IdOrdine)
        {
            var ord = (from c in db.Ordine where c.Id == IdOrdine select c).FirstOrDefault();


            string text = @"

<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
    
    <style type=""text/css"">
        .style1
        {
            width: 258px;
            height: 111px;
        }
    </style>
</head>
<body>
    <p>
        <img alt=""Coffee Tesi"" class=""style1""
            longdesc=""Coffee Tesi online stampa rapida, rilegatura similpelle e cartoncino"" 
            src=""http://www.coffeetesi.it/img/logo.png"" /></p>
    <p>
        &nbsp;</p>
    <p>
        Gentile cliente,</p>
    <p>
        abbiamo ricevuto il tuo ordine che verrà processato appena avrai provveduto al 
        pagamento e a inviarci il file da stampare.</p>
    <p>
        Per inviarci i file di stampa, effettuare il pagamento o controllare lo stato 
        del tuo ordine ti basterà cliccare il seguente link:</p>
    <p>
        <a href=";
            
            text += "http://www.coffeetesi.it/tesionline/open/" + IdOrdine.ToString() + "/" + ord.Token.ToString();

            text += @"
            
            "">ACCESSO AL MIO ORDINE</a></p>
    <p>
        Per contattarci rispondi semplicemente a questa mail o vai sul nostro sito e 
        clicca contatti.</p>
    <p>
        <a href=""http://www.coffeetesi.it"">http://www.coffeetesi.it</a></p>
    <p>
        <a href=""http://www.facebook.com/CoffeeTesi"">http://www.facebook.com/</a></p>
    <p>
        Se non sei tu il destinatario ti preghiamo di risposndere alla mail 
        comunicandocelo. Se non vuoi ricevere questa mail puoi rispondere 
        comunicandocelo.</p>
    <p>
        Grazie per il tuo ordine.</p>

</body>
</html>

                ";



            //text.Replace("LINK-ACC", "http://www.coffeetesi.it/tesionline/open/" + IdOrdine.ToString() + "/" + ord.Token.ToString());
            return this.SendFromeMe("CoffeeTesi - Dati accesso ordine online", text, ord.Email);
        
        }


        public bool SendPaymentRecived(int IdOrdine)
        {
            var ord = (from c in db.Ordine where c.Id == IdOrdine select c).FirstOrDefault();


            string text = @"

<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
    
    <style type=""text/css"">
        .style1
        {
            width: 258px;
            height: 111px;
        }
    </style>
</head>
<body>
    <p>
        <img alt=""Coffee Tesi"" class=""style1""
            longdesc=""Coffee Tesi online stampa rapida, rilegatura similpelle e cartoncino"" 
            src=""http://www.coffeetesi.it/img/logo.png"" /></p>
    <p>
        &nbsp;</p>
    <p>
        Gentile cliente,</p>
    <p>
        abbiamo ricevuto il pagamento del tuo ordine</p>
    <p>
        Per vedere maggiori dettagli puoi cliccare qui sotto e verificare il pagmaneto</p>
    <p>
        <a href=";

            text += "http://www.coffeetesi.it/tesionline/open/" + IdOrdine.ToString() + "/" + ord.Token.ToString();

            text += @"
            
            "">VERIFICA SITUAZIONE PAGAMENTO</a></p>
    <p>
        Per contattarci rispondi semplicemente a questa mail o vai sul nostro sito e 
        clicca contatti.</p>
    <p>
        <a href=""http://www.coffeetesi.it"">http://www.coffeetesi.it</a></p>
    <p>
        <a href=""http://www.facebook.com/CoffeeTesi"">http://www.facebook.com/</a></p>
    <p>
        Se non sei tu il destinatario ti preghiamo di risposndere alla mail 
        comunicandocelo. Se non vuoi ricevere questa mail puoi rispondere 
        comunicandocelo.</p>
    <p>
        Grazie per il tuo ordine.</p>

</body>
</html>

                ";



            //text.Replace("LINK-ACC", "http://www.coffeetesi.it/tesionline/open/" + IdOrdine.ToString() + "/" + ord.Token.ToString());
            return this.SendFromeMe("CoffeeTesi - Pagamento ordine n°" + IdOrdine.ToString(), text, ord.Email);

        }


    }
}