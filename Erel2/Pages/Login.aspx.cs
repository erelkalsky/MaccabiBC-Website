using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Erel2.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["tryLogin"] == 5)
            {
                Response.StatusCode = 401;
                Response.End();
            }

            if ((bool)Session["Login"] == true)
                Response.Redirect("Main.aspx");

            if (IsPostBack)
            {
                User user = Helper.GetUserData2(Request.Form["userName"].ToString(), Request.Form["password"].ToString());

                if (user.userName == "Visitor")
                {                  
                    Session["userName"] = "אורח";
                    Session["Login"] = false;
                    Session["Admin"] = user.admin;
                    message.InnerHtml = "שם משתמש או סיסמא לא תקינים" + "<br />" + "נשארו לך עוד " + (5 - ((int)Session["tryLogin"] + 1)) + " " + "נסיונות התחברות";

                    Session["tryLogin"] = ((int)Session["tryLogin"] + 1);
                    if ((int)Session["tryLogin"] == 5)
                    {
                        Response.StatusCode = 401;
                        Response.End();
                    }
                }
                else
                {
                    Session["userName"] = user.userName;
                    Session["password"] = user.password;
                    Session["userId"] = user.userId;
                    Session["Login"] = true;
                    Session["Admin"] = user.admin;
                    message.InnerHtml = "";
                    Response.Redirect("/Pages/Main.aspx");
                }
            }
        }
    }
}