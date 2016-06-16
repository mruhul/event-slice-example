using System;
using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Src.Infrastructure.ViewLocationExpanders;
using Autofac.Extensions.DependencyInjection;

namespace BookWorm.Web
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new FeatureBasedViewLocationExpander());
            });

            var builder = new ContainerBuilder();

            builder.Populate(services);

            builder.RegisterAssemblyModules(typeof(Startup).GetTypeInfo().Assembly);
            builder.RegisterModule<Bolt.RequestBus.Autofac.RequestBusModule>();

            var container = builder.Build();
            
            return container.Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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