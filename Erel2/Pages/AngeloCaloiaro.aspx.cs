using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Erel2.Pages.PlayersInfo
{
    public partial class AngeloCaloiaro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["tryLogin"] == 5)
            {
                Response.StatusCode = 401;
                Response.End();
            }

            if ((bool)Session["Login"] == false)
                Response.Redirect("Main.aspx");
        }
    }
}