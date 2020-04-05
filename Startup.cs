using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newproject3.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Logging;

namespace newproject3
{
    public class Startup

    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public string CookiePath { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //public void ConfigureServices(IServiceCollection services)
            {
                services.AddIdentity<ApplicationUser, IdentityRole>()
                        .AddEntityFrameworkStores<ApplicationDbContext>()
                        .AddDefaultTokenProviders();

                // If you want to tweak Identity cookies, they're no longer part of IdentityOptions.
                services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/LogIn");
            }
            {
                services.AddAuthentication()
                        .AddFacebook(options =>
                        {
                            options.AppId = Configuration["auth:facebook:appid"];
                            options.AppSecret = Configuration["auth:facebook:appsecret"];
                        });
            }

            {
                UseAuthentication();
             }

            //public void UseAuthentication()
        {
            //throw new NotImplementedException();
        }
        }

        private void AddDefaultTokenProviders()
        {
            throw new NotImplementedException();
        }

        private void UseAuthentication()
        {
            
        }

        private void GetOpenIdConnectOptions()
        {
            throw new NotImplementedException();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            //app.UseMvc();
        }
    }
}
