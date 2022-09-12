using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Sanalogi.Core.UnitofWork;
using Sanalogi.Core.UnitOfWorks;
using Sanalogi.Data.Context;
using Sanalogi.Data.Repositories;
using Sanalogi.Data.Repositories.Abstract;
using Sanalogi.Data.Repositories.Concrete;
using Sanalogi.Service.Mapper;
using Sanalogi.Service.Services;
using Sanalogi.Service.Services.Abstract;
using Sanalogi.Service.Services.Concrete;
using System;
using System.Text;
using UrunKatalogProjesi.Service.Services;

namespace Sanalogi.API.StartupExtensions
{
    public static class ExtensionService
    {
        public static void AddContextDependencyInjection(this IServiceCollection services, IConfiguration Configuration)
        {
            // cors 
            services.AddCors(options => options.AddPolicy("Cors", builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            AppDbContext.SetContextConnectionString(Configuration.GetConnectionString("DefaultConnection"));
        }
        public static void AddServicesDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ISiparisRepository, SiparisRepository>();
            services.AddScoped<ISiparisService, SiparisService>();
            services.AddScoped<IUnitofWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
            // mapper 
            MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
