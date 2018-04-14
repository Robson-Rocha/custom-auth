using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomAuthenticationHandler.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomAuthenticationHandler
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
            services
                //Step 01 - Adicionar os servi�os do Middleware de autentica��o
                .AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = MyCustomAuthSchemes.UserScheme;
                    options.DefaultChallengeScheme = MyCustomAuthSchemes.UserScheme;
                })
                //Step 03 - Inje��o do nosso Handler de Autentica��o Customizado
                .AddMyCustomAuth(options => {
                    options.LoginPage = "/account/login";
                    options.ForbiddenPage = "/account/forbidden";
                });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            //Step 11 - Inser��o do Middleware de Autentica��o do ASP.NET Core no pipeline
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
