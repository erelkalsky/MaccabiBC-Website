using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Erel2
{
    public partial class Page : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["Login"] == false) // un-authorized user
            {
                showGuestMenu();
            }
            else // authorized user
            {
                showUserMenu();
                Session["tryLogin"] = 0;
            }
            totalVisitors.Value = Application["totalVisitors"].ToString();
            //curVisitors.Value = Application["currentVisitors"].ToString();
        }

        public void btn_logot(object sender, EventArgs e)
        {
            Session["userName"] = "אורח";
            Session["Login"] = false;
            Session["Admin"] = false;
            showGuestMenu();
            Response.Redirect("/Pages/Main.aspx");
        }

        private void showGuestMenu()
        {
            Main.Visible = true;

            TheClub.Visible = false;
            TheTeam.Visible = false;
            UsersTable.Visible = false;

            UpdateUser.Visible = false;
            logoutBtn.Visible = false;
            Login.Visible = true;
            SignUp.Visible = true;
        }

        private void showUserMenu()
        {
            Main.Visible = true;

            TheClub.Visible = true;
            TheTeam.Visible = true;
            UsersTable.Visible = (bool)Session["Admin"];

            UpdateUser.Visible = true;
            logoutBtn.Visible = true;
            Login.Visible = false;
            SignUp.Visible = false;
        }
    }
}