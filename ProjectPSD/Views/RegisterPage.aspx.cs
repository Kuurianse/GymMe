using ProjectPSD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTB.Text;
            string email = useremailTB.Text;
            string radio = Convert.ToString(radioGender.SelectedIndex);
            string password = passwordTB.Text; ;
            string confirmpassword = confirmTB.Text;
            DateTime dob = dobCalendar.SelectedDate;

            Msg.Text = UserController.doRegister(username, email, radio, password, confirmpassword, dob);

        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LoginPage.aspx");
        }
    }
}