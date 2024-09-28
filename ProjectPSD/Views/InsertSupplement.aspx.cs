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
    public partial class InsertSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAdmin"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }

            SupplementTypeRepository suppTypeRepo = new SupplementTypeRepository();

            if (IsPostBack == false)
            {
                List<String> suppTypeNames = suppTypeRepo.GetSupplementTypeNames();
                suppTypeDropDown.DataSource = suppTypeNames;
                suppTypeDropDown.DataBind();
            }
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            SupplementRepository suppRepo = new SupplementRepository();
            SupplementTypeRepository suppTypeRepo = new SupplementTypeRepository();

            String suppName = suppNameTB.Text;
            DateTime suppExpiryDate = expiryDateCalendar.SelectedDate;
            int suppPrice = Convert.ToInt32(suppPriceTB.Text);
            String suppTypeName = suppTypeDropDown.Text;
            int suppTypeID = suppTypeRepo.GetSupplementTypeIDByName(suppTypeName);

            // suppRepo.InsertSupplement(id, suppName, suppExpiryDate, suppPrice, suppTypeID);
            // Response.Redirect("~/Views/ManageSupplement.aspx");

            Msg.Text = SupplementController.doInsertSupplement(suppName, suppExpiryDate, suppPrice, suppTypeID);
            
        }
        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageSupplement.aspx");
        }
    }
}