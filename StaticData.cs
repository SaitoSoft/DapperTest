using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest.Data.Utility
{
    public static class StaticData
    {
        public static string GetAllEmployeesCmd = "dbo.GetEmployees";
        public static string UpdateEmployeeSalaryCmd = "dbo.UpdateEmployeeSalaryById";
    }
}
