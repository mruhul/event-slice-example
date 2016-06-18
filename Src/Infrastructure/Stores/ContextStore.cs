using System.Collections.Concurrent;
using Bolt.Common.Extensions;
using Microsoft.AspNetCore.Http;

namespace Src.Infrastructure.Stores
{
    public interface IContextStore
    {
        object Get(string name);
        void Set(string name, object value);
    }
    
    public class ContextStore : IContextStore
    {
        private readonly ConcurrentDictionary<string, object> store;

        public ContextStore()
        {
            this.store = new ConcurrentDictionary<string, object>();
        }

        public object Get(string name)
        {
            object result;
            return store.TryGetValue(name, out result) ? result : null;
        }

        public void Set(string name, object value)
        {
            store.TryAdd(name, value);
        }
    }
}
