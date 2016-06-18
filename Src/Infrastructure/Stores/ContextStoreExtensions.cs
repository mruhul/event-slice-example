namespace Src.Infrastructure.Stores
{
    public static class ContextStoreExtensions
    {
        public static T Get<T>(this IContextStore source, string name)
        {
            return (T) source.Get(name);
        }
    }
}