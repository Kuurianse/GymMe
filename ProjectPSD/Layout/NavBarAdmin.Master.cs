using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Layout
{
    public partial class NavBarAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomeAdmin.aspx");
        }

        protected void manageSuppBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageSupplement.aspx");
        }

        protected void orderQueueBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionsQueue.aspx");
        }

        protected void profileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ProfileAdmin.aspx");
        }

        protected void transactionReportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionsReport.aspx");
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            string[] cookies = Request.Cookies.AllKeys;

            foreach (string cookie in cookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }

            // Application["count_user"] = ((int)Application["count_user"]) - 1;
            Session.Remove("IsAdmin");
            Response.Redirect("~/Views/LoginPage.aspx");
        }
    }
}