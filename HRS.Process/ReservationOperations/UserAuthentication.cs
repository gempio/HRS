using HRS.DataAccessLayer.DatabaseDALs;

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