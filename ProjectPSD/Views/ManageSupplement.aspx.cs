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
    public partial class ManageSupplement1 : System.Web.UI.Page
    {
        public List<MsSupplement> supplements = null;

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
            SupplementRepository suppRepo = new SupplementRepository();

            if (IsPostBack == false)
            {
                supplements = suppRepo.GetSupplements();
                manageSupplementGV.DataSource = supplements;
                manageSupplementGV.DataBind();
            }
        }

        protected void manageSupplementGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SupplementRepository suppRepo = new SupplementRepository();
            GridViewRow row = manageSupplementGV.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            suppRepo.RemoveSupplementByID(id);

            supplements = suppRepo.GetSupplements();
            manageSupplementGV.DataSource = supplements;
            manageSupplementGV.DataBind();
        }

        protected void manageSupplementGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = manageSupplementGV.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdateSupplement.aspx?suppId=" + id);
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertSupplement.aspx");
        }
        protected void manageSupplementGV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}