using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sanalogi.Service.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Sanalogi.API.StartupExtensions
{
    public static class ExtensionValidations
    {
        public static void AddValidations(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<SiparisValidation>());

        }
    }
}
