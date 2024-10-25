using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest.Data.Utility
{
    public class ConnectionOptions
    {
        public const string Position = "ConnectionStrings";
        public string DefaultConnection { get; set; } = string.Empty;
    }
}
