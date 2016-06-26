using System;
using System.Threading.Tasks;
using Bolt.Logger;

namespace Src.Infrastructure.ErrorSafeHelpers
{
    public interface IErrorSafeExecutor
    {
        Task<IErrorSafeResponse> ExecuteAsync(Func<Task> action);
        Task<IErrorSafeResponse<T>> ExecuteAsync<T>(Func<Task<T>> action);
    }

    public class ErrorSafe : IErrorSafeExecutor
    {
        private readonly ILogger logger = null;

        public ErrorSafe(ILogger logger)
        {
            this.logger = logger;
        }

        public static IErrorSafeExecutor WithLogger(ILogger logger)
        {
            return new ErrorSafe(logger);
        }

        public async Task<IErrorSafeResponse> ExecuteAsync(Func<Task> action)
        {
            try
            {
                await action.Invoke();

                return ErrorSafeResponse.Succeed();
            }
            catch (Exception e)
            {
                logger?.Error(e,e.Message);

                return ErrorSafeResponse.Failed();
            }
        }
        public async Task<IErrorSafeResponse<T>> ExecuteAsync<T>(Func<Task<T>> action)
        {
            try
            {
                var value = await action.Invoke();

                return ErrorSafeResponse.Succeed(value);
            }
            catch (Exception e)
            {
                logger?.Error(e, e.Message);
                return ErrorSafeResponse.Failed<T>();
            }
        }
    }
}