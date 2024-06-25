using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using propertymanagement.service.Commons;
using SPA.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Steeltoe.Discovery.Client;
using Steeltoe.Extensions.Configuration;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.ResponseCompression;
using propertymanagement.service.Hubs;
using Microsoft.OpenApi.Models;
using System.IO.Compression;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Options;

namespace propertymanagement.service
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddCloudFoundry()
                .AddEnvironmentVariables();

            Configuration = builder.Build();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            SetApplicationSettings();
            services.AddControllers();
            //services.AddSingleton();
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(ApplicationSetting.ConnectionString));
            services.AddDiscoveryClient(Configuration);
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Property Management Service",
                    Description = "Build on the .NET Core 3.1"

                });

            });
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {

                builder.WithOrigins("http://localhost:44344", "https://localhost:44344", "http://103.175.218.25", "http://localhost:30028", "http://spaserver3:3003", "http://localhost:3003");
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));
            services.AddMvcCore().AddApiExplorer();
            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddOptions();
            services.AddSignalR();
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });

            //mapper digunakan untuk mapping antar model agar properti dari model dapat digunakan di dalam function di repository untuk model lainnya.
            //AutoMapper.Mapper.Initialize(mapper =>
            //{

            //    //mapper.CreateMap<Models.Users, Models.ViewModels.UserMasters>().ReverseMap();
            //    //mapper.CreateMap<Models.UserContacts, Models.ViewModels.UserDetails>().ReverseMap();
            //    //mapper.CreateMap<Models.UserApplications, Models.ViewModels.UserApplicationDetails>().ReverseMap();

            //});
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {

                options.MimeTypes = new[]
                {
                    // Default
                    "text/plain",
                    "text/css",
                    "application/javascript",
                    "text/html",
                    "application/xml",
                    "text/xml",
                    "application/json",
                    "text/json",
                    // Custom
                    "image/svg+xml"
                };

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //loggerFactory.AddConsole((Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();
            app.UseRouting();
            //app.UseDiscoveryClient();
            //app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:44344", "https://localhost:44344", "http://103.175.218.25", "http://localhost:30028", "http://spaserver3:3003", "http://localhost:3003")
                .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });
            app.UseSwagger();
            app.UseResponseCompression();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
                endpoints.MapHub<NotificationHub>("/Hubs/Notification");

            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Property Management Service For MAG");
            });
            //app.UseEndpoints(endpoints =>
            //{
            //});

        }
        private void SetApplicationSettings()
        {
            ApplicationSetting.ConnectionString = Configuration["Data:ConnectionStringWCS"];
            //ApplicationSetting.ConnectionString = Configuration["Data:ConnectionStringAzure"];
            //ApplicationSetting.EmailAddressService = Configuration["LinkURL:linkUrlEmail"];
            //ValueStorage.urlSIM_VP_EmailSetting = Configuration["Data:urlSIM_VP_EmailSetting"];
        }
    }
}
