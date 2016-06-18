using Autofac;
using Bolt.Logger.NLog;
using Bolt.RestClient;
using Bolt.RestClient.Builders;
using Bolt.Serializer.Json;

namespace Src.Ioc
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => RestClientBuilder.New().WithSerializer(new JsonSerializer()).Build()).As<IRestClient>().SingleInstance();

            builder.Register(x => new NLogLogger("BookWorm"))
                .As<Bolt.Logger.ILogger>()
                .SingleInstance();

            builder.RegisterGeneric(typeof(BookWorm.Web.Features.Shared.CategoryMenu.LoadCategoryMenuOnPageLoadEventHandler<>)).As(typeof(Bolt.RequestBus.IAsyncEventHandler<>));
            builder.RegisterGeneric(typeof(BookWorm.Web.Features.Shared.LoginStatus.LoadLoginStatusOnPageLoadEventHandler<>)).As(typeof(Bolt.RequestBus.IAsyncEventHandler<>)); 
        }
    }
}
