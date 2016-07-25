using System;
using Autofac;
using Bolt.Logger;
using Bolt.Logger.NLog;
using Bolt.RestClient;
using Bolt.RestClient.Builders;
using Bolt.RestClient.Dto;
using Bolt.Serializer.Json;
using BookWorm.Web;

namespace Src.Ioc
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => RestClientBuilder.New()
                .WithSerializer(new JsonSerializer())
                //.WithProxy("http://localhost:8888", true)
                .WithLogger(Bolt.Logger.NLog.LoggerFactory.Create("Bolt.RestClient"))
                .WithTimeTakenNotifier(new LogBasedReportTimeTaken(Bolt.Logger.NLog.LoggerFactory.Create("Bolt.RestClient")))
                .Build()
            ).As<IRestClient>()
            .SingleInstance();

            builder.Register(x => Bolt.Logger.NLog.LoggerFactory.Create(typeof(Startup)))
                .As<Bolt.Logger.ILogger>() 
                .SingleInstance();

            builder.RegisterGeneric(typeof(BookWorm.Web.Features.Shared.CategoryMenu.LoadCategoryMenuOnPageLoadEventHandler<>)).As(typeof(Bolt.RequestBus.IAsyncEventHandler<>));
            builder.RegisterGeneric(typeof(BookWorm.Web.Features.Shared.LoginStatus.LoadLoginStatusOnPageLoadEventHandler<>)).As(typeof(Bolt.RequestBus.IAsyncEventHandler<>));
            builder.RegisterGeneric(typeof(BookWorm.Web.Features.Shared.SavedBooks.LoadSavedBooksOnPageLoadEventHandler<>)).As(typeof(Bolt.RequestBus.IAsyncEventHandler<>));
            builder.RegisterGeneric(typeof(BookWorm.Web.Features.Shared.Cart.LoadCartOnPageLoadEventHandler<>)).As(typeof(Bolt.RequestBus.IAsyncEventHandler<>));
        }
    }

    public class LogBasedReportTimeTaken : Bolt.RestClient.IReportTimeTaken
    {
        private readonly ILogger logger;

        public LogBasedReportTimeTaken(ILogger logger)
        {
            this.logger = logger;
        }

        public void Notify(RestRequest request, TimeSpan timeTaken)
        {
            logger.Trace("{0} : {1} took {2}ms", request.Method, request.Url, timeTaken.TotalMilliseconds);
        }
    }
}
