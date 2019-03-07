using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthServer.Models;
using IdentityServer4;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AuthServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddIdentityServer()
            //     .AddDeveloperSigningCredential()
            //     .AddInMemoryClients(Config.GetClients())
            //     .AddInMemoryScopes(Config.GetScopes())
            //     .AddInMemoryUsers(Config.GetUsers());
            //        services.AddAuthentication()
            //.AddGoogle("Google", options =>
            //{
            //    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

            //    options.ClientId = "google";
            //    options.ClientSecret = "secret";
            //});
            services.AddMvc();

            services.AddDbContext<ApplicationDbcontext>(opts =>
  opts.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=IdentityServerDatabase;Trusted_Connection=True"));

            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>()
    .AddTransient<IProfileService, ProfileService>()
    .AddTransient<IAuthRepository, AuthRepository>();
            services.AddIdentityServer()
               .AddDeveloperSigningCredential()
               //.AddInMemoryIdentityResources(Config.GetIdentityResources())
             //  .AddTestUsers(Config.GetUsers())
               .AddInMemoryApiResources(Config.GetApiResources())
               .AddInMemoryClients(Config.GetClients())
               .AddProfileService<ProfileService>(); 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           // LoggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
