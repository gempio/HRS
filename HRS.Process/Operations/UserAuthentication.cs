using HRS.DataAccessLayer.DatabaseDALs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Process.Operations
{
    public static class UserAuthentication
    {
        public static void AuthenticateUser(string username, string password)
        {
            UserManagementDb userDbManager = new UserManagementDb();
            userDbManager.AuthenticateUser(username, password);
        }
    }
}
