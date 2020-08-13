using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Email
{
    public static class SendGridExtensions
    {
        public static IServiceCollection AddSendGridEmailSender(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, SendGridEmailSender>();

            return services;
        }
    }
}
