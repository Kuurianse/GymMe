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
    public partial class HomeAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAdmin"] == null && Request.Cookies["Admin_cookie"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else
            {
                UserRepository userRepo = new UserRepository();
                MsUser userSession = new MsUser();

                if (Session["IsAdmin"] == null)
                {
                    int userId = Convert.ToInt32(Request.Cookies["Admin_cookie"].Value);
                    userSession = userRepo.GetUserByID(userId);
                    Session["IsAdmin"] = userSession;
                }
                else
                {
                    userSession = (MsUser)Session["IsAdmin"];
                }

                userLbl.Text = "Username: " + userSession.UserName;
                idLbl.Text = "UserID: " + Convert.ToString(userSession.UserID);

                /*
                if (Application["count_user"] != null)
                    userOnlineLbl.Text = Application["count_user"] + " User(s) Online";
                */

                if (userSession.UserName.Equals("admin"))
                {

                    var u = userRepo.GetUsers();

                    foreach (var x in u)
                    {
                        listUserLB.Items.Add(x.UserName);
                    }
                }
            }
        }
    }
}