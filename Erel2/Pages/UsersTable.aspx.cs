using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Erel2.Pages
{
    public partial class UsersTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["tryLogin"] == 5)
            {
                Response.StatusCode = 401;
                Response.End();
            }

            if ((bool)Session["Login"] == false || (bool)Session["Admin"] == false)
                Response.Redirect("Main.aspx");

            if (((bool)Session["Login"] == false) ||
                ((bool)Session["Admin"] == false))
                Response.Redirect("/Pages/Main.aspx");

            if (!IsPostBack)
            {
                string table = Helper.BuildFullUsersTable();
                tableDiv.InnerHtml = table;
            }
        }

        public void Click_Filter(object sender, EventArgs e)
        {
            string table = Helper.BuildFilteredByNameUsersTable(Request.Form["filter"]);
            tableDiv.InnerHtml = table;
        }

        public void Click_Delete(object sender, EventArgs e)
        {
            // בניית מערך של משתמשים למחיקה
            List<int> usersList = new List<int>();

            for (int i = 1; i < Request.Form.Count; i++)
            {
                if (Request.Form.AllKeys[i].Contains("chk"))
                {
                    int userId = int.Parse(Request.Form.AllKeys[i].Remove(0, 3));
                    usersList.Add(userId);
                }
            }
            int[] userIdToDelete = usersList.ToArray();

            if (userIdToDelete.Length == 0)
            {
                message.InnerHtml = "עליך לבחור שורה";
                return;
            }

            Helper.Delete(userIdToDelete);

            // הדפסת הטבלה המעודכנת
            string table = Helper.BuildFullUsersTable();
            tableDiv.InnerHtml = table;
        }

        public void Click_Edit(object sender, EventArgs e)
        {
            // Iterate over input text boxes and checked buttons
            foreach (string key in Request.Form.Keys)
            {
                if (key.Contains("chk"))
                {
                    Session["userToUpdate"] = int.Parse(key.Remove(0, 3));
                    Response.Redirect("/Pages/EditUser.aspx");
                }
            }
            message.InnerHtml = "לא נבחר משתמש";
        }

        public void Click_Add(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/SignUp.aspx");
        }

        public void ChangeToAdmin(object sender, EventArgs e)
        {
            ChangeAdmin("True");
        }

        public void ChangeToUser(object sender, EventArgs e)
        {
            ChangeAdmin("False");
        }

        public void ChangeAdmin(string value)
        {
            // בניית מערך של משתמשים לעדכון כמנהל.ת
            List<int> usersList = new List<int>();

            // Iterate over input text boxes and checked buttons
            foreach (string key in Request.Form.Keys)
            {
                if (key.Contains("chk"))
                {
                    int userId = int.Parse(key.Remove(0, 3));
                    usersList.Add(userId);
                }
            }

            int[] userIdToAdminOrUser = usersList.ToArray();

            if (userIdToAdminOrUser.Length == 0)
            {
                message.InnerHtml = "עליך לבחור שורה";
                return;
            }

            // עדכון בסיס הנתונים
            Helper.UpdateToAdmin(userIdToAdminOrUser, value);

            // הדפסת הטבלה מחדש
            string table = Helper.BuildFullUsersTable();
            tableDiv.InnerHtml = table;
        }

        public void Click_Sort(object sender, EventArgs e)
        {
            //string table = Helper.BuildSortedUsersTable(Columns.Value, Request.Form["order"].ToString());Select1
            string table = Helper.BuildSortedUsersTable(Columns.Value, Select1.Value);
            tableDiv.InnerHtml = table;
        }
    }
}