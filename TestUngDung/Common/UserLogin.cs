using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestUngDung.Common
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string FullName { get; set; }

    }
}