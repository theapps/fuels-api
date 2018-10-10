﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Config;
using api.Database;
using api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpaApiMiddleware;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;



namespace api
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
            var conStr = Configuration.GetConnectionString("DefaultConnection");
            var pgConn = Environment.GetEnvironmentVariable("DATABASE_URL");

            if (!string.IsNullOrWhiteSpace(pgConn))
                conStr = HerokuPGParser.ConnectionHelper.BuildExpectedConnectionString(pgConn);
           
            services.AddDbContext<AppDb>(options => options.UseNpgsql(conStr));
            
            services.AddAutoMapper();
            
            services
                .AddMvc(opt => opt.Filters.Add(typeof(PhoneUserAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUserService, UserServiceFake>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
//            else
//            {
//                app.UseHsts();
//            }
//
//            app.UseHttpsRedirection();

            app.UseSpaApiOnly();
            
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
            
            app.UseCors(cfg => cfg.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                if (serviceScope.ServiceProvider.GetService<AppDb>() != null)
                {
                    var ctx = serviceScope.ServiceProvider.GetService<AppDb>();
                    new DatabaseFacade(ctx).Migrate();
                }
            }
        }
    }
}
