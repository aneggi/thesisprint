using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using Google.GData.Spreadsheets;
using Google.GData.Client;


namespace KiLab.Models
{

    

    public class gOrder
    {

        public string ID { get; set; }
        public string isDelete { get; set; }
        public string stAperto10 { get; set; }
        public string stPagato20 { get; set; }
        public string stInvioBozza30 { get; set; }
        public string stRicezioneFile40 { get; set; }
        public string stAttesaSpedizione50 { get; set; }
        public string stSpedito60 { get; set; }
        public string stChiuso70 { get; set; }
        public string data { get; set; }
        public string fatturaEmessa { get; set; }
        
        public string email { get; set; }
        public string cell { get; set; }
        public string codFiscale { get; set; }
        public string token { get; set; }
        public string tokenScadenza { get; set; }
                
        
        public string spedNome { get; set; }
        public string spedCognome { get; set; }
        public string spedIndirizzo { get; set; }
        public string spedCitta { get; set; }
        public string spedCAP { get; set; }
        public string giornoLaurea { get; set; }

        public string stampeBN { get; set; }
        public string stampeColori { get; set; }
        public string copie { get; set; }
        public string fronteRetro { get; set; }
        public string bozzaAcquistata { get; set; }
        public string cartaPlusAcquistata { get; set; }
        //public MSpedizione spedizione { get; set; }
        //public MRilegatura rilegatura { get; set; }
        public string spedizione { get; set; }
        public string rilegatura { get; set; }

        public string costoBN { get; set; }
        public string costoColori { get; set; }
        public string costoSpedizione { get; set; }
        public string costoRilegatura { get; set; }
        public string costoBozza { get; set; }
        public string costoTotale { get; set; }
        public string costoCartaPlus { get; set; }
        public string note { get; set; }

        public void getByEmail(string mail)
        {
        }

        public void getById(string Id)
        {

            SpreadsheetsService myService = new SpreadsheetsService("exampleCo-exampleApp-1");
            myService.setUserCredentials("alessandro.aneggi@gmail.com", "alex83@x");

            SpreadsheetQuery query = new SpreadsheetQuery();
            //SpreadsheetQuery query = new SpreadsheetQuery("https://spreadsheets.google.com/feeds/spreadsheets/private/full/0ApoEY-P-zK6edG5vUHRpZUw5SERVUGxwZm8tZEhaTmc");
            SpreadsheetFeed feed = myService.Query(query);
            //SpreadsheetEntry entry = myService.Query(query);
            //foreach (SpreadsheetEntry entry in feed.Entries)
            //{
                // Print the title of this spreadsheet to the screen
            //    Console.WriteLine(entry.Title.Text);
            //}
            //FeedQuery que = new FeedQuery("https://spreadsheets.google.com/feeds/spreadsheets/private/full/0ApoEY-P-zK6edG5vUHRpZUw5SERVUGxwZm8tZEhaTmc");
            //preadsheetEntry entry = myService.Queryque);
            //SpreadsheetEntry spreadsheet = (SpreadsheetEntry)feed.Entries[0];
            //WorksheetFeed wsFeed = spreadsheet.Worksheets;
            //WorksheetEntry wsEntry = (WorksheetEntry) wsFeed.Entries[0];
            //CellQuery cellQuery = new CellQuery(wsEntry.CellFeedLink);
            //cellQuery.Query = "select A:Z where A == "1"";
            //CellFeed cellFeed = myService.Query(cellQuery);
            //AtomLink listFeedLink = wsEntry.Links.FindService(GDataSpreadsheetsNameTable.ListRel, null);
            //https://spreadsheets.google.com/feeds/list/tnoPtieL9HDUPlpfo-dHZNg/od6/private/full
            //ListQuery listQuery = new ListQuery(listFeedLink.HRef.ToString());
            ListQuery listQuery = new ListQuery("tnoPtieL9HDUPlpfo-dHZNg", "od6","private","full");
            listQuery.SpreadsheetQuery = "id = 10";
            ListFeed listFeed = myService.Query(listQuery);

            

        }

        public void update()
        {
            SpreadsheetsService myService = new SpreadsheetsService("exampleCo-exampleApp-1");
            myService.setUserCredentials("alessandro.aneggi@gmail.com", "alex83@x");
            ListQuery listQuery = new ListQuery("tnoPtieL9HDUPlpfo-dHZNg", "od6", "private", "full");
            listQuery.SpreadsheetQuery = "id = " + ID.ToString();
            ListFeed listFeed = myService.Query(listQuery);

            // TODO: Choose a row more intelligently based on your app's needs.
            ListEntry row = (ListEntry)listFeed.Entries[0];

            // Update the row's data.
            foreach (ListEntry.Custom element in row.Elements)
            {
                if (element.LocalName == "email")
                {
                    element.Value = email;
                }
                if (element.LocalName == "nome")
                {
                    element.Value = spedNome;
                }
                if (element.LocalName == "cognome")
                {
                    element.Value = spedCognome;
                }
                if (element.LocalName == "indirizzo")
                {
                    element.Value = spedIndirizzo;
                }
            }

            // Save the row using the API.
            row.Update();

        }

        public void add()
        {
            SpreadsheetsService myService = new SpreadsheetsService("exampleCo-exampleApp-1");
            myService.setUserCredentials("alessandro.aneggi@gmail.com", "alex83@x");
            ListQuery listQuery = new ListQuery("tnoPtieL9HDUPlpfo-dHZNg", "od6", "private", "full");
            //listQuery.SpreadsheetQuery = "id = " + ID.ToString();
            ListFeed listFeed = myService.Query(listQuery);

            //add test
            ListEntry row = new ListEntry();
            row.Elements.Add(new ListEntry.Custom() { LocalName = "id", Value = ID.ToString() });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "email", Value = email });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "data", Value = data });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "cell", Value = cell });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "codfis", Value = codFiscale });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "token", Value = token });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "nome", Value = spedNome });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "cognome", Value = spedCognome });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "indirizzo", Value = spedIndirizzo });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "citta", Value = spedCitta });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "cap", Value = spedCAP });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "giornolaurea", Value = giornoLaurea });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "copie", Value = copie });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "fronteretro", Value = fronteRetro });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "bozzaacquistata", Value = bozzaAcquistata });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "email", Value = "Smith" });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "data", Value = "26" });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "stampebn", Value = "176" });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "stampebn", Value = stampeBN.ToString() });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "stampecolori", Value = stampeColori.ToString() });

            row.Elements.Add(new ListEntry.Custom() { LocalName = "cartaplus", Value = cartaPlusAcquistata });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "spedizione", Value = spedizione });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "indirizzo", Value = spedIndirizzo });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "citta", Value = spedCitta });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "cap", Value = spedCAP });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "giornolaurea", Value = giornoLaurea });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "rilegatura", Value = rilegatura });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "costobn", Value = costoBN });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "costocolori", Value = costoColori });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "email", Value = "Smith" });
            row.Elements.Add(new ListEntry.Custom() { LocalName = "data", Value = "26" });


            // Send the new row to the API for insertion.
            myService.Insert(listFeed, row);

        }


    }
    
}