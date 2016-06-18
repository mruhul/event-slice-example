using System;
using Autofac;
using BookWorm.Web;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.StartUpTasks;

namespace Src.Ioc
{
    public class ConventionBasedModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = new[] {typeof (Startup).Assembly};

            builder.RegisterAssemblyTypes(assemblies)
                .Where(a => a.IsClass &&
                            a.Name.EndsWith("Handler"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(a => a.IsClass &&
                            Attribute.IsDefined(a, typeof(AutoBindSingletonAttribute)))
                .AsImplementedInterfaces()
                .SingleInstance();


            builder.RegisterAssemblyTypes(assemblies)
                .Where(a => a.IsClass &&
                            Attribute.IsDefined(a, typeof(AutoBindAttribute)))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assemblies)
                .AssignableTo<IStartUpTask>()
                .AsImplementedInterfaces();
        }
    }
}