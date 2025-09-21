using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Db.EFCore
{
    public class ConnectionSettings
    {
        public string ServerName { get; set; } = ".";
        public string DataBase { get; set; } = "";
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
