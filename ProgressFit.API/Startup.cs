using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProgressFit.API.Helpers;
using ProgressFit.Data;
using ProgressFit.Data.Entities;
using ProgressFit.Data.Repositories;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgressFit.Domain.Services.Contracts;
using ProgressFit.Domain.Services;
using Microsoft.Extensions.Caching.Memory;

namespace ProgressFit.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("LocalConnection")));
            services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
            IdentityBuilder builder = services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.SignIn.RequireConfirmedPhoneNumber = false;

            });

            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddSignInManager<SignInManager<AppUser>>();
            builder.AddDefaultTokenProviders();

            services.AddAuthenticationCore();

            services.AddAutoMapper(typeof(Startup));
            services.AddLogging();
            services.AddScoped<IRepository<AppUserSetting>, AppUserSettingRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAppUserSettingService, AppUserSettingService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IDailyDietService, DailyDietService>();
            services.AddScoped<IDietService, DietService>();
            services.AddScoped<ITosService, TosService>();
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddScoped<IMemoryCache, MemoryCache>();
            services.AddControllers();

            services.AddAuthentication("Bearer")
               .AddIdentityServerAuthentication(options =>
               {
                   options.ApiName = "progressfit-api";
                   options.Authority = "https://10.0.2.2:5001";
                   options.RequireHttpsMetadata = false;
               });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProgressFit.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProgressFit.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            //app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
