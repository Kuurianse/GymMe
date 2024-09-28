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
    public partial class UpdateSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAdmin"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }

            SupplementRepository suppRepo = new SupplementRepository();
            SupplementTypeRepository suppTypeRepo = new SupplementTypeRepository();

            if(IsPostBack == false)
            {
                int id = Convert.ToInt32(Request.QueryString["suppId"]);
                MsSupplement updateMsSupp = suppRepo.GetSupplementByID(id);

                if(updateMsSupp != null)
                {
                    suppNameTB.Text = updateMsSupp.SupplementName;
                    expiryDateCalendar.SelectedDate = updateMsSupp.SupplementExpiryDate;
                    suppPriceTB.Text = Convert.ToString(updateMsSupp.SupplementPrice);
                    
                    List<String> suppTypeNames = suppTypeRepo.GetSupplementTypeNames();
                    suppTypeDropDown.DataSource = suppTypeNames;
                    suppTypeDropDown.DataBind();
                    suppTypeDropDown.SelectedValue = suppTypeRepo.GetSupplementTypeNameByID(id);
                    
                }
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            SupplementRepository suppRepo = new SupplementRepository();
            SupplementTypeRepository suppTypeRepo = new SupplementTypeRepository();

            int updateSuppID = Convert.ToInt16(Request.QueryString["suppId"]);
            String suppName = suppNameTB.Text;
            DateTime suppExpiryDate = expiryDateCalendar.SelectedDate;
            int suppPrice = Convert.ToInt32(suppPriceTB.Text);
            String suppTypeName = suppTypeDropDown.Text;
            int suppTypeID = suppTypeRepo.GetSupplementTypeIDByName(suppTypeName);

            suppRepo.UpdateSupplementByID(updateSuppID, suppName, suppExpiryDate, suppPrice, suppTypeID);
            Response.Redirect("~/Views/ManageSupplement.aspx");
        }
        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageSupplement.aspx");
        }
    }
}