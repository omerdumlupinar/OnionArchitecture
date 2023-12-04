using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Extension
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<OnionArchitecture_Context>(conf =>
            {
                var conStr = configuration["DbConnectionStrings"].ToString();

                conf.UseSqlServer(conStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });


            return services;
        }
    }
}
