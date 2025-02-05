using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net.Mail;
using System.Net;

namespace Erel2.Pages
{
    public partial class passwordRecovery : System.Web.UI.Page
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
                User user = Helper.GetUserDataS(Request.Form["userName"].ToString(),Request.Form["email"].ToString());
                if (user.userName == "Visitor")
                {
                    message.InnerHtml = "האימייל או שם המשתמשים אינם נכונים";
                }
                else
                {
                    SmtpClient smtpc = new SmtpClient("smtp.gmail.com");
                    smtpc.Port = 587;
                    smtpc.EnableSsl = true;
                    smtpc.UseDefaultCredentials = false;
                    smtpc.Credentials = new NetworkCredential("erelroyproject@gmail.com", "qbuqkrponztuhrtu");
                    MailMessage email = new MailMessage("erelroyproject@gmail.com", user.email, "Maccabi Tel Aviv Basketball Club", $"!Hey {user.userName}, Your password is: {user.password} have a great day");
                    try
                    {
                        smtpc.Send(email);
                        message.InnerHtml = "הסיסמא נשלחה למייל בהצלחה";
                    }
                    catch
                    {
                        message.InnerHtml = "נסיון שליחת הסיסמא למייל נכשלה";
                    }
                }
            }
        }
    }
}