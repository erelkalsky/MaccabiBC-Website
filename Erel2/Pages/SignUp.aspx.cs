using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Erel2.Pages
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["tryLogin"] == 5)
            {
                Response.StatusCode = 401;
                Response.End();
            }
            
            if ((bool)Session["Login"] == true && (bool)Session["Admin"] == false)
                Response.Redirect("Main.aspx");


            if (IsPostBack)
            {
                // בדיקה אם קיים שם משתמש
                if (Helper.IsUserExist1(Request.Form["userName"].ToString()))
                {
                    userNameAlert.InnerHtml = "שם המשתמש נמצא כבר בשימוש. בחר שם אחר.";
                }
                else
                {
                    if(Request.Form["userName"].ToString().Length > 0)
                    {
                        // בניית השורה להוספה
                        User user = new User();
                        user.userName = Request.Form["userName"].ToString();
                        user.password = Request.Form["password"].ToString();
                        user.firstName = Request.Form["firstName"].ToString();
                        user.lastName = Request.Form["lastName"].ToString();
                        user.gender = Request.Form["gender"].ToString();
                        user.phoneAreaCode = Request.Form["phoneAreaCode"].ToString();
                        user.phone = Request.Form["phone"].ToString();
                        user.email = Request.Form["email"].ToString();
                        user.admin = false;

                        //Helper.Insert1(user);
                        Helper.Insert2(user);
                        Response.Redirect("/Pages/Main.aspx");
                    }
                }
            }
        }
    }
}