using System;
using Autofac;
using BookWorm.BooksApi.Infrastructure.Attributes;
using BookWorm.BooksApi.Infrastructure.StartUpTasks;

namespace BookWorm.BooksApi.Ioc
{
    public class ConventionBasedModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = new[] { typeof(Startup).Assembly };

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
