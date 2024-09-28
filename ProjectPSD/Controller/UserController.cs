using Microsoft.Win32;
using ProjectPSD.Factories;
using ProjectPSD.Hadler;
using ProjectPSD.Model;
using ProjectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace ProjectPSD.Controller
{
    public class UserController
    {
        public static string UpdatePassword(int updateUserID, string oldPassword, string newPassword)
        {
            UserRepository userRepository = new UserRepository();
            string currentPassword = userRepository.GetCurrentPassword(updateUserID);

            if (string.IsNullOrEmpty(oldPassword) || oldPassword != currentPassword)
            {
                return "Must be the same with the current password and cannot be empty.\n";
            }
            if (string.IsNullOrEmpty(newPassword) || !newPassword.All(char.IsLetterOrDigit))
            {
                return "Must be the same with the current password and cannot be empty.\n";
            }
            else
            {
                UserRepository userRepo = new UserRepository();
                userRepo.UpdatePasswordByID(updateUserID, newPassword);

                return "Update Password Success";
            }
        }
        
        public static string UpdateProfile(int updateUserID, string username, string email, int radio, DateTime dob)
        {
            if (string.IsNullOrEmpty(username) || username.Length < 5 || username.Length > 15 || !username.All(c => char.IsLetter(c) || c == ' '))
            {
                return "Length must be between 5 and 15 alphabet with space only and cannot be empty.\n";
            }
            else if (string.IsNullOrEmpty(email) || !email.EndsWith(".com"))
            {
                return "Must ends with ‘.com’ and cannot be empty.\n";
            }else if (radio == -1)
            {
                return "Gender must be chosen.\n";
            }
            else if (dob == DateTime.MinValue)
            {
                return "Cannot be empty";
            }
            else
            {
                string gender = "";

                if (radio == 0)
                {
                    gender = "Male";
                }
                else if (radio == 1)
                {
                    gender = "Female";
                }

                UserRepository userRepo = new UserRepository();
                userRepo.UpdateProfileByID(updateUserID, username, email, gender, dob);

                return "Update Profile Success";
            }
        }
        
        public static MsUser doLogin(string username, string password)
        {
            MsUser tempUser = UserHandler.doLogin(username, password);

            return tempUser;
        }

        public static string doRegister(string username, string email, string radio, string password, string confirmPassword, DateTime dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(username) || username.Length < 5 || username.Length > 15 || 
                !IsAlphaWithSpace(username))
            {
                return "Username must be between 5 and 15 characters long, consisting of alphabet with space only.\n";
            }

            if (string.IsNullOrWhiteSpace(email) || !email.EndsWith(".com"))
            {
                return "Email must not be empty and must end with '.com'.\n";
            }

            if (radio.Equals("-1"))
            {
                return "Gender must be chosen.\n";
            }

            if (string.IsNullOrWhiteSpace(password) || !IsAlphaNumeric(password) || !password.Equals(confirmPassword))
            {
                return "Password must not be empty, must be alphanumeric, and must match the confirmation password.\n";
            }

            if (string.IsNullOrWhiteSpace(confirmPassword) || !password.Equals(confirmPassword))
            {
                return "Confirmation password must not be empty and must match the password.\n";
            }

            if (dateOfBirth == DateTime.MinValue)
            {
                return "Date of birth must not be empty.\n";
            }
            else
            {
                string gender = "";

                if (radio.Equals("0"))
                {
                    gender = "Male";
                }
                else if (radio.Equals("1"))
                {
                    gender = "Female";
                }


                if (UserHandler.doRegister(username, email, gender, password, dateOfBirth) ==true)
                {
                    return "Register Success";
                    
                }
                else
                {
                    return "Same Username already exists";
                }
            }

            bool IsAlphaWithSpace(string input)
            {
                foreach (char c in input)
                {
                    if (!char.IsLetter(c) && c != ' ')
                    {
                        return false;
                    }
                }
                return true;
            }

            bool IsAlphaNumeric(string input)
            {
                foreach (char c in input)
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}