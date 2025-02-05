﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Erel2.Pages
{
    public partial class EditUser2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["tryLogin"] == 5)
            {
                Response.StatusCode = 401;
                Response.End();
            }

            if ((bool)Session["Login"] == false)
                Response.Redirect("/Pages/Main.aspx");

            if (Session["userName"] == null)
            {
                Response.Redirect("/Pages/Main.aspx");
            }

            if(!IsPostBack)
            {
                User user = Helper.GetUserData1((int) Session["userId"]);

                userName.Value = user.userName;
                password.Value = user.password;
                firstName.Value = user.firstName;
                lastName.Value = user.lastName;
                gender.Items.FindByValue(user.gender).Selected = true;
                phoneAreaCode.Items.FindByValue(user.phoneAreaCode).Selected = true;
                phone.Value = user.phone;
                email.Value = user.email;

                ViewState["userName"] = userName.Value;
            }
        }

        public void UpdateUser(object sender, EventArgs e)
        {
            User oldUser = Helper.GetUserData1((int)Session["userId"]);

            User user = new User();
            user.userName = userName.Value;
            user.password = password.Value;
            user.firstName = firstName.Value;
            user.lastName = lastName.Value;
            user.gender = gender.Value;
            user.phoneAreaCode = phoneAreaCode.Value;
            user.phone = phone.Value;
            user.email = email.Value;
            user.userId = (int)Session["userId"];
            if(oldUser != null)
                user.admin = oldUser.admin;

            // בדיקה אם שם המשתמש שונה ואם כן האם שם משתמש כבר קיים 
            if (ViewState["userName"].ToString() != Request.Form[userName.UniqueID].ToString() && Helper.IsUserExist2(Request.Form[userName.UniqueID].ToString()))
            {
                userNameAlert.InnerHtml = "* שם המשתמש נמצא כבר בשימוש, אנא בחר שם אחר *";
                return;
            }
            else
            {
                Helper.Update(user);
                User updatedUser = Helper.GetUserData2(user.userName, user.password);
                if (updatedUser != null)
                {
                    Session["userName"] = updatedUser.userName;
                    Session["password"] = updatedUser.password;
                }
                Response.Redirect("/Pages/Main.aspx");
            }
        }
    }
}