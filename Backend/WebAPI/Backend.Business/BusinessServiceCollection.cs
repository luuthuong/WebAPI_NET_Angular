using Backend.Business.Services.Interfaces;
using Backend.Business.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Business
{
    public static class BusinessServiceCollection
    {
        public static void DIServiceRegister(this IServiceCollection service)
        {
            service.AddTransient<IAuthService, AuthService>();
        }
    }
}
