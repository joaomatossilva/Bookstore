using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Application
{
    public static class Configure
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Configure));
            return services;
        }
    }
}
