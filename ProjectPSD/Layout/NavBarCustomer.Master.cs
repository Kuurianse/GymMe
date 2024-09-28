using ProjectPSD.Repositories;
using ProjectPSD.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Layout
{
    public partial class NavBarCustomer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void orderSuppBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/OrderSupplement.aspx");
        }

        protected void historyBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HistoryUser.aspx");
        }

        protected void profileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Profile.aspx");
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            CartRepository cartRepo = new CartRepository();
            cartRepo.ClearAllCart();
            
            string[] cookies = Request.Cookies.AllKeys;

            foreach (string cookie in cookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }

            // Application["count_user"] = ((int)Application["count_user"]) - 1;
            Session.Remove("User");
            Response.Redirect("~/Views/LoginPage.aspx");
        }
    }
}