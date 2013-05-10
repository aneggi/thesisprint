using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Specialized;
using KiLab.Models;

namespace KiLab.Views.Tesionline
{
    public partial class IPN_handler : System.Web.UI.Page
    {
        public TesiContainer db = new TesiContainer();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                //Post back to either sandbox or live
                string strSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
                string strLive = "https://www.paypal.com/cgi-bin/webscr";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strSandbox);

                //Set values for the request back
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
                string strRequest = Encoding.ASCII.GetString(param);
                strRequest += "&cmd=_notify-validate";
                req.ContentLength = strRequest.Length;

                //for proxy
                //WebProxy proxy = new WebProxy(new Uri("http://url:port#"));
                //req.Proxy = proxy;

                //Send the request to PayPal and get the response
                StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
                streamOut.Write(strRequest);
                streamOut.Close();
                StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
                string strResponse = streamIn.ReadToEnd();
                streamIn.Close();
                string strResponse_copy = strRequest;

                //log su file del pagamento
                //string FILE_NAME = "PaymentLog_" + DateTime.Today + ".txt"; 
                //StreamWriter sw = System.IO.File.CreateText(FILE_NAME);
                //sw.WriteLine(strResponse);
                //sw.Close(); 





                if (strResponse == "VERIFIED")
                {

                    NameValueCollection these_argies = HttpUtility.ParseQueryString(strResponse_copy);
                    string user_email = these_argies["payer_email"];
                    string pay_stat = these_argies["payment_status"];

                    int id = int.Parse(these_argies["item_number"]);
                    var ord = (from c in db.Ordine where c.Id == id select c).FirstOrDefault();


                    //log su db del pagamento
                    KiLab.Models.Logs l = new KiLab.Models.Logs();
                    l.Data = DateTime.Now;
                    l.Testo = strRequest;






                    //.
                    //.  more args as needed look at the list from paypal IPN doc
                    //.
                    if (pay_stat.Equals("Completed"))
                    {
                        ord.PagamentoId = these_argies["txn_id"];
                        ord.StPagato20 = DateTime.Now;
                        //Send_download_link("yours_truly@mycompany.com", user_email, "Your order", "Thanks for your order this the downnload link ... blah blah blah");
                    }
                    db.Logs.AddObject(l);
                    db.SaveChanges();


                }
                else if (strResponse == "INVALID")
                {
                    KiLab.Models.Logs l = new KiLab.Models.Logs();
                    l.Data = DateTime.Now;
                    l.Testo = strRequest;


                    db.Logs.AddObject(l);
                    db.SaveChanges();
                    //log for manual investigation
                }
                else
                {
                    KiLab.Models.Logs l = new KiLab.Models.Logs();
                    l.Data = DateTime.Now;
                    l.Testo = strRequest;


                    db.Logs.AddObject(l);
                    db.SaveChanges();
                    //log response/ipn data for manual investigation
                }


                //More info
                //https://cms.paypal.com/it/cgi-bin/?cmd=_render-content&content_ID=developer/e_howto_html_IPNandPDTVariables
                //https://cms.paypal.com/it/cgi-bin/?cmd=_render-content&content_ID=developer/e_howto_html_formbasics
                //Test in sendbox (developer.paypal.com)
            }


            catch (InvalidCastException eb)
            {
                KiLab.Models.Logs l = new KiLab.Models.Logs();
                l.Data = DateTime.Now;
                l.Testo = eb.ToString();
                db.Logs.AddObject(l);
                db.SaveChanges();


            }


        }
    }
}