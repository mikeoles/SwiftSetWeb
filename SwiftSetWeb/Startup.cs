﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SwiftSetWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace SwiftSetWeb
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
            services.AddMvc();

            var connection = @"Data Source =.; Initial Catalog = SwiftSet; Persist Security Info = True; User ID = SwiftSetUser; Password = sspassword!; MultipleActiveResultSets = True; Application Name = EntityFramework";
            // Use SQL Database if in Azure, otherwise, use SQLite
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                services.AddDbContext<SwiftSetContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("MyDbConnection")));
            }
            else
            {
                services.AddDbContext<SwiftSetContext>(options => options.UseSqlServer(connection));

            }

            // Automatically perform database migration
            services.BuildServiceProvider().GetService<SwiftSetContext>().Database.Migrate();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
