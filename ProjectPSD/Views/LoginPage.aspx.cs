using ProjectPSD.Controller;
using ProjectPSD.Model;
using ProjectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTB.Text;
            string password = passwordTB.Text;
            bool isRemember = checkBoxRemember.Checked;

            MsUser User = UserController.doLogin(username, password);

            if (User == null)
            {
                errorMsg.Text = "Wrong Username and Password";
            }
            else
            {
                // bool isAdmin = false;
                if (User.UserRole.Equals("Admin"))
                {
                    Session["IsAdmin"] = User;
                    // isAdmin = true;
                    // Session["IsAdmin"] = isAdmin;

                    if (isRemember)
                    {
                        HttpCookie adminCookie = new HttpCookie("Admin_cookie");
                        adminCookie.Value = Convert.ToString(User.UserID);
                        adminCookie.Expires = DateTime.Now.AddHours(10);          // cookie berlaku 10 jam
                        Response.Cookies.Add(adminCookie);
                    }

                    if (Application["count_user"] == null)
                        Application["count_user"] = 1;
                    else
                        Application["count_user"] = ((int)Application["count_user"]) + 1;

                    Response.Redirect("~/Views/HomeAdmin.aspx");

                    // HttpCookie adminCookie = new HttpCookie("IsAdmin_cookie", "true");
                    // adminCookie.Expires = DateTime.Now.AddHours(1);     // cookie berlaku 1 jam
                    // Response.Cookies.Add(adminCookie);
                }
                else
                {
                    Session["User"] = User;

                    if (isRemember)
                    {
                        HttpCookie cookie = new HttpCookie("User_cookie");  // cookie cuman bisa nampung 1 string
                        cookie.Value = Convert.ToString(User.UserID);
                        cookie.Expires = DateTime.Now.AddHours(10);          // cookie berlaku 1 jam
                        Response.Cookies.Add(cookie);
                    }

                    if (Application["count_user"] == null)
                        Application["count_user"] = 1;
                    else
                        Application["count_user"] = ((int)Application["count_user"]) + 1;

                    Response.Redirect("~/Views/HomeUser.aspx");
                }
            }
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/RegisterPage.aspx");
        }
    }
}