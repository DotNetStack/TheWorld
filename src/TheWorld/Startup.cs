using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheWorld.Services.MailService;
using Microsoft.Extensions.Configuration;

namespace TheWorld
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("config.json");
            _config = builder.Build();
            
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);
            services.AddMvc();
            if (_env.IsEnvironment("Development")|| _env.IsEnvironment("Testing"))
            {
                services.AddTransient<IMailService, DebugMailService>();
            }
             
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline. aka middleware
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles();
            app.UseMvc(config =>
            {
                config.MapRoute(
                    name : "Default", 
                    template: "{Controller}/{Action}/{id?}",
                    defaults:new { Controller ="App", Action="Index"});
            });
            
        }
    }
}
