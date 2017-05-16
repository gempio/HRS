using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.NunitTests.TestDataClasses
{
    public static class TestUsersData
    {
        public static Tuple<string, string> GetValidUser(bool validUser)
        {
           return validUser ? new Tuple<string, string>("user","pass"): new Tuple<string, string>(string.Empty,string.Empty); 
        }
    }
}
