using ProjectPSD.Factories;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repositories
{
    public class UserRepository
    {
        static ProjectDatabaseEntities db = new ProjectDatabaseEntities();
        // ProjectDatabaseEntities db = DatabaseSingleton.GetInstance();

        public string GetCurrentPassword(int userId)
        {
            MsUser msUser = db.MsUsers.Find(userId);
            string password = msUser.UserPassword;

            return password;
        }
        
        public void UpdateUserByID(int id, string username, string userEmail, string password, DateTime dob)
        {
            MsUser updateUser = GetUserByID(id);
            updateUser.UserName = username;
            updateUser.UserEmail = userEmail;
            updateUser.UserDOB = dob;
            updateUser.UserPassword = password;
            db.SaveChanges();
        }

        public void UpdateProfileByID(int id, string username, string userEmail, string gender, DateTime dob)
        {
            MsUser updateUser = GetUserByID(id);
            updateUser.UserName = username;
            updateUser.UserEmail = userEmail;
            updateUser.UserDOB = dob;
            updateUser.UserGender = gender;
            db.SaveChanges();
        }

        public void UpdatePasswordByID(int id, string newPassword)
        {
            MsUser updateUser = GetUserByID(id);
            updateUser.UserPassword = newPassword;
            db.SaveChanges();
        }

        public MsUser GetUserByID(int id)
        {
            MsUser msUser = db.MsUsers.Find(id);
            return msUser;
        }
        
        public void RemoveUserByID(int id)
        {
            MsUser msUser = db.MsUsers.Find(id);
            db.MsUsers.Remove(msUser);
            db.SaveChanges();
        }

        public List<MsUser> GetUsers()
        {
            return db.MsUsers.ToList();
        }
        
        public static MsUser login(string username, string password)
        {
            MsUser user = (from i in db.MsUsers 
                           where i.UserName.Equals(username) && i.UserPassword.Equals(password)
                           select i).FirstOrDefault();
            return user;
        }

        public static void doRegister(string username, string userEmail, string gender, string password, DateTime dob)
        {
            MsUser lastUser = (from i in db.MsUsers orderby i.UserID descending select i).FirstOrDefault();

            int id = 0;
            if (lastUser != null)
            {
                id = lastUser.UserID;
                id++;
            }
            
            string role = "User";

            MsUser user = UserFactory.Create(id, username, userEmail, dob, gender, role, password);
            Debug.WriteLine(user.UserID);
            db.MsUsers.Add(user);
            db.SaveChanges();
        }

        public static MsUser checkSameUsername(String username)
        {
            MsUser user = (from i in db.MsUsers where i.UserName.Equals(username) select i).FirstOrDefault();
            return user;
        }
    }
}