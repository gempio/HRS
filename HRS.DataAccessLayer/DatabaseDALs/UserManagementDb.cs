﻿using System;

namespace HRS.DataAccessLayer.DatabaseDALs
{
    public class UserManagementDb
    {
        public UserManagementDb()
        {}

        public void AuthenticateUser(string username, string password)
        {
            //Normally some DB connection stuff here.
            if (username.Equals("user") && password.Equals("pass"))
            {
                return;
            }
            throw new Exception("Failed to validate user. Access denied.");
        }
    }
}
