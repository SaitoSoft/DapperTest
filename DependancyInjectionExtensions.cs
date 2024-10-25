using DapperTest.Data.Intefaces;
using DapperTest.Data.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperTest.Data.Utility;

namespace DapperTest.Data.Extensions
{
    public static class DependancyInjectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {

            services.AddScoped<IDataLayer, DataLayer>();
            
            return services;
        }
    }
}
