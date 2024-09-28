using ProjectPSD.Dataset;
using ProjectPSD.Model;
using ProjectPSD.Report;
using ProjectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views
{
    public partial class TransactionsReport : System.Web.UI.Page
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
            }

            ProjectCrystalReport report = new ProjectCrystalReport();
            CrystalReportViewer1.ReportSource = report;

            TransactionHeaderRepository thRepo = new TransactionHeaderRepository();
            DataSet1 data = getData(thRepo.GetTransactions());
            report.SetDataSource(data);
        }

        private DataSet1 getData(List<TransactionHeader> transactionHeader)
        {
            DataSet1 data = new DataSet1();
            var headertable = data.TransactionHeader;
            var detailtable = data.TransactionDetail;

            foreach(TransactionHeader t in transactionHeader)
            {
                var hrow = headertable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["UserID"] = t.UserID;
                hrow["TranscationDate"] = t.TransactionDate;
                hrow["Status"] = t.Status;
                headertable.Rows.Add(hrow);

                foreach(TransactionDetail d in t.TransactionDetails)
                {
                    var drow = detailtable.NewRow();
                    drow["TransactionID"] = d.TransactionID;
                    drow["SupplementID"] = d.SupplementID;
                    drow["Quantity"] = d.Quantity;
                    detailtable.Rows.Add(drow);
                }
            }
            return data;
        }
    }
}