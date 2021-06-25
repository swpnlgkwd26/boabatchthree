using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using sample_app.Extensions;
using sample_app.Models;
using sample_app.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Read the Config file that is appSetting.json
        private IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) //  Built in DI .Net Core
        {
            // This will activate all the services required to return views along with controller
            services.AddControllersWithViews();

            // IFileProvide :  PhysicalFileProvider : Whohas access to Current Directory 
            // Physical File PRovider => CurrentDirector
            IFileProvider physicalFileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
            services.AddSingleton<IFileProvider>(physicalFileProvider); // Activated

            // configure Application to use ConnectionString
            services.AddDbContext<BankOfAmericaBatchThreeContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:ProductConnection"]);
            });

            // Activate Service For IStoreRepository
            //services.AddScoped<IStoreRepository, ProductInMemoryRepository>();

            services.AddScoped<IStoreRepository, ProductSQLRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Request Pipeline
            // env:  Enviroment Specific information :  if you want to run any code only dev, Staging
            // You can run environment specific code
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // By default it shows
            }
            // Middleware
            else if (env.IsStaging() || env.IsProduction())
            {
                app.UseExceptionHandler("/error");
            }
            app.UseStatusCodePages();



            // Static File Middleware : Exposing Static files
            app.UseStaticFiles(); // wwwroot
            // Keep Your Static Files in Separate Folder
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider($"{env.ContentRootPath}/mystaticfiles"),
                RequestPath = "/files"
            });


            // Custom Middleware :  Set the Culture
            app.UseRequestCulture();


            // Routing  Middleware
            //  Select the Best Endpoint for the Current URL
            app.UseRouting();
            // Conventional Routing
            // Configuration of the Endpoints
            app.UseEndpoints(endpoints =>
            {
                // 100 Route
                // http://localhost/Chess/Page1
                endpoints.MapControllerRoute("category", "{category}/Page{productpage}",
              new { controller = "Home", action = "Index" });
                // http://locahost/Chess
                //endpoints.MapControllerRoute("category", "{category}",
                //    new { controller = "Home", action = "Index", productpage = 1 });

                //Products/Page2 .. productpage = 2
                endpoints.MapControllerRoute("pagination", "Products/Page{productpage}",
                    new { controller = "Home", action = "Index" });

                endpoints.MapGet("/productinfo/{price:int}", async context =>
                {
                    var price = context.Request.RouteValues["price"]; // Read Route Parameter
                    await context.Response.WriteAsync($"Hello  : " + price);
                });

                endpoints.MapGet("/authorize/{username:minlength(4)}", async context =>
                {
                    var userName = context.Request.RouteValues["username"]; // Read Route Parameter
                    await context.Response.WriteAsync($"Hello  : " + userName);
                });

                endpoints.MapDefaultControllerRoute();// home: controller and index will be action
            });
             
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Shopping Admin App");
            //});


        }
    }
}
