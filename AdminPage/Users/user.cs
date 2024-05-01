using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPage.Users
{
    public class Users
    {
        public string AdminName { get; set; }
        public string SRCode { get; set; }
    }

    public static class CurrentUser
    {
        public static Users LoggedInUser { get; set; }
    }
}
