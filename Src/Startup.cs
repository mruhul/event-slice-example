using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Src.Infrastructure.ViewLocationExpanders;
using Autofac.Extensions.DependencyInjection;
using Bolt.Common.Extensions;
using BookWorm.Web.Features.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Config;
using Src.Infrastructure.StartUpTasks;
using Src.Infrastructure.Stores;
using NLog.Extensions.Logging;
using Src.Features.Shared.Settings;

namespace BookWorm.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder();
            builder
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

        }

        public IConfigurationRoot Configuration { get; private set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddOptions();

            services.Configure<ApiSettings>(Configuration.GetSection("ApiSettings"));

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new FeatureBasedViewLocationExpander());
            });
            
            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IContextStore, ContextStore>();
            services.AddSingleton<IConfiguration>(opt => Configuration);

            var builder = new ContainerBuilder();

            builder.Populate(services);

            builder.RegisterAssemblyModules(typeof(Startup).GetTypeInfo().Assembly);
            builder.RegisterModule<Bolt.RequestBus.Autofac.RequestBusModule>();

            var container = builder.Build();

            container.Resolve<IEnumerable<IStartUpTask>>()
                .ForEach(task =>
                {
                    try
                    {
                        task.Run();
                    }
                    catch (Exception e)
                    {
                        // ignored
                    }
                });

            return container.Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,  ILoggerFactory loggerFactory)
        {
            env.ConfigureNLog("NLog.config");
            loggerFactory
                .AddNLog();

            loggerFactory.CreateLogger<Startup>().LogError("Configuration started");

            
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {

            }

            app.UseStaticFiles("/public");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=index}/{id?}");
            });

            app.Run(context =>
            {
                return context.Response.WriteAsync("Hello world from asp.net");
            });
        }
    }
}