using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KiLab.admin
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mode"] != null)
            {

                if ((Request.QueryString["mode"] == "admin1onnow" )&&( Request.QueryString["secpass"] == "d76t6drhHGF76tftr9j-gjig847hjGTYrr23t-duft6FRwQhg"))
                {
                    Session["admin"] = true;
                }
            
            }

            if (Session["admin"] == null)
            {
                Server.Transfer("http://www.coffeetesi.it/error");
                
            }

        }


        

    }
}