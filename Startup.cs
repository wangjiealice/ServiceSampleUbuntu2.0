using ServiceSample.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//using Swashbuckle.Swagger.Model;


namespace ServiceSample
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.     
            services.AddMvc().AddXmlSerializerFormatters();

            IBookChaptersRepository repos = new SampleBookChaptersRepository();
            repos.Init();
            services.AddSingleton(repos);

            ICan29Repository repos1 = new Can29Repository();
            repos1.Init();
            services.AddSingleton(repos1);

            services.AddSwaggerGen();

            //services.ConfigureSwaggerGen(options =>
            //{
            //    options.SingleApiVersion(new Info
            //    {
            //        Version = "v1",
            //        Title = "Book Chapters",
            //        Description = "A sample for Professional C# 6"
            //    });
            //    options.IgnoreObsoleteActions();
            //    options.IgnoreObsoleteProperties();
            //    options.DescribeAllEnumsAsStrings();
            //});

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();

            //// app.UseMvc(routes=>
            //// {
            ////     routes.MapRoute(
            ////         name:"default",
            ////         template:"{controller=Home}/api/BookChapters"
            ////     );
            //// });  


            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
                //routes.MapHub<Can29Hub>("/can29Hub");
                routes.MapHub<Can29Repository>("/can29Hub");
            });


            app.UseMvc();

            //app.UseSwagger(app);
            //app.UseSwaggerUi();
        }
    }
}
