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
    public partial class DetailTransaction : System.Web.UI.Page
    {
        public List<TransactionDetail> details = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null && Request.Cookies["User_cookie"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else
            {
                UserRepository userRepo = new UserRepository();
                MsUser userSession = new MsUser();

                if (Session["User"] == null)
                {
                    int userId = Convert.ToInt32(Request.Cookies["User_cookie"].Value);
                    userSession = userRepo.GetUserByID(userId);
                    Session["User"] = userSession;
                }
                else
                {
                    userSession = (MsUser)Session["User"];
                }

            }
            TransactionDetailRepository tdRepo = new TransactionDetailRepository();
            if (IsPostBack == false)
            {
                int transactionId = Convert.ToInt32(Request.QueryString["id"]);
                details = tdRepo.GetTransactionDetailsByTransactionId(transactionId);
                TransactionDetailGV.DataSource = details;
                TransactionDetailGV.DataBind();
            }
        }
        protected void backBtn_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Views/HistoryUser.aspx");
        }
    }
}