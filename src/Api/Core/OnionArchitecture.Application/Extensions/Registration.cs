using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Interfaces.Services;
using OnionArchitecture.Application.Services.CategoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddAplicationRegistration(this IServiceCollection services)
        {
            var assm= Assembly.GetExecutingAssembly();

            services.AddMediatR(assm);
            services.AddAutoMapper(assm);
            services.AddValidatorsFromAssembly(assm);

            services.AddScoped<ICategoryService, CatecoryService>();



            return services;
        }
    }
}
