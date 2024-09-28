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
    public partial class HistoryAdmin : System.Web.UI.Page
    {
        public List<TransactionHeader> transactions = null;
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
            TransactionHeaderRepository thRepo = new TransactionHeaderRepository();
            MsUser msUser = (MsUser)Session["User"];
            int userID = msUser.UserID;

            if (IsPostBack == false)
            {
                transactions = thRepo.GetTransactionHeadersByUserId(userID);
                TransactionHeaderGV.DataSource = transactions;
                TransactionHeaderGV.DataBind();
            }
        }

        protected void TransactionHeaderGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TransactionHeaderGV.SelectedRow.Cells[0].Text.ToString());
            Response.Redirect("~/Views/DetailTransaction.aspx?id=" + id);
        }

        protected void clearTransactionBtn_Click(object sender, EventArgs e)
        {
            TransactionHeaderRepository thRepo = new TransactionHeaderRepository();
            thRepo.ClearAllTransactionHeader();
            transactions = thRepo.GetTransactions();
            TransactionHeaderGV.DataSource = transactions;
            TransactionHeaderGV.DataBind();
        }
    }
}