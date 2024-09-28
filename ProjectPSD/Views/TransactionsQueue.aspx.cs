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
    public partial class TransactionsQueue : System.Web.UI.Page
    {
        public List<TransactionHeader> transactions = null;
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
            }

            TransactionHeaderRepository thRepo = new TransactionHeaderRepository();
            MsUser msUser = (MsUser)Session["IsAdmin"];
            int userID = msUser.UserID;

            if (IsPostBack == false)
            {
                transactions = thRepo.GetTransactions();
                TransactionHeaderGV.DataSource = transactions;
                TransactionHeaderGV.DataBind();
            }
        }

        protected void TransactionHeaderGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TransactionHeaderGV.SelectedRow.Cells[0].Text.ToString());
            TransactionHeaderRepository thRepo = new TransactionHeaderRepository();
            
            TransactionHeader th = thRepo.GetTransactionByID(id);
            string status = th.Status;

            thRepo.UpdateTransactionStatusByID(id, status);

            transactions = thRepo.GetTransactions();
            TransactionHeaderGV.DataSource = transactions;
            TransactionHeaderGV.DataBind();
            msgLbl.Text = "Handle Success";

            // Response.Redirect("~/Views/DetailTransaction.aspx?id=" + id);
        }
    }
}