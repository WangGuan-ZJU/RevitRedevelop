using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitRedevelop.DB
{
    class DBDao
    {

    }
    public class UserInfo
    {
        private string UserName { get; set; }
        private int PhoneNumber { get; set; }
        private string Password { get; set; }
        private string IDCardNumber { get; set; }
        private string EMail { get; set; }
        private string RealName { get; set; }
        private int ContactMobileNumber { get; set; }
        private DBProcess db { get; set; }
    }
}
