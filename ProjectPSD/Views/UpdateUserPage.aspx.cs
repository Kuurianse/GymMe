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
    public partial class UpdateUserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserRepository userRepo = new UserRepository();

            if(IsPostBack == false)
            {
                int userId = Convert.ToInt32(Request.QueryString["userId"]);
                MsUser updateUser = userRepo.GetUserByID(userId);

                if (updateUser != null)
                {
                    usernameTB.Text =  updateUser.UserName;
                    useremailTB.Text = updateUser.UserEmail;
                    passwordTB.Text = updateUser.UserPassword;
                    confirmTB.Text = updateUser.UserPassword;

                }
                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            UserRepository userRepo = new UserRepository();

            int updateUserID = Convert.ToInt32(Request.QueryString["user_id"]);
            string username = usernameTB.Text;
            string email = useremailTB.Text;
            string password = passwordTB.Text;
            DateTime dob = dobCalendar.SelectedDate;

            userRepo.UpdateUserByID(updateUserID, username, email, password, dob);
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}